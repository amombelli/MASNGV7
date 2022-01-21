using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.OrdenPago
{
    public class OrdenPagoValidaGenerar
    {
        private readonly OrdenPagoCreateNew _op;

        public OrdenPagoValidaGenerar(OrdenPagoCreateNew op)
        {
            _op = op;
        }

        public ListaValidacion ValidacionGenerar()
        {
            ListaValidacion rtn = new ListaValidacion {IsAllOkGenerar = true};
            
            if (_op.Header.ImporteOrdenPago > 0)
            {
                rtn.ImporteOk = true;
                //tiene al menos items de pago o retenciones
            }
            else
            {
                rtn.IsAllOkGenerar = false;
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //valida facturas en OP sigan estando con el mismo saldo pendiente de pago
                rtn.FacturasPendientesDisponibles = true;
                foreach (var fac in _op.FacturasOP)
                {
                    var cta = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == fac.IdCtaCte);
                    if (cta.SALDOFACTURA != fac.SaldoAdeudado)
                        rtn.FacturasPendientesDisponibles = false;
                }
                if (rtn.FacturasPendientesDisponibles == false)
                    rtn.IsAllOkGenerar = false;

                //valida si tiene cheques (no propios) que sigan estando disponibles en sistema
                rtn.ChequesDisponiblesSistema = true;
                foreach (var cheque in _op.ItemsPagoOP.Where(c=>c.EsCheque && c.ChIdCartera>0))
                {
                    var che = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == cheque.ChIdCartera);
                    if (che.DISPONIBLE == false)
                        rtn.ChequesDisponiblesSistema = false;
                }
                if (rtn.ChequesDisponiblesSistema == false)
                    rtn.IsAllOkGenerar = false;

                //valida creditos sigan estando disponibles con mismos valores
                rtn.CreditosDisponibles = true;
                foreach (var credit in _op.Creditos)
                {
                    var cre = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == credit.IdCtaCte);
                    if (cre == null)
                        rtn.CreditosDisponibles = false;
                    if (Math.Abs(cre.SALDOFACTURA) != Math.Abs(credit.Importe))
                    {
                        rtn.CreditosDisponibles = false;
                    }
                }
            }
            return rtn;
        }
    }

    public class ListaValidacion
    {
        //clase con definiciones de validacion
        public ListaValidacion()
        {
            IsAllOkGenerar = false;
            ImporteOk = false;
            FacturasPendientesDisponibles = false;
            ChequesDisponiblesSistema = false;
            CreditosDisponibles = false;

        }
        public bool ImporteOk { get; set; }
        public bool IsAllOkGenerar { get; set; }
        public bool FacturasPendientesDisponibles { get; set; }
        public bool ChequesDisponiblesSistema { get; set; }
        public bool CreditosDisponibles { get; set; }
    }


}
