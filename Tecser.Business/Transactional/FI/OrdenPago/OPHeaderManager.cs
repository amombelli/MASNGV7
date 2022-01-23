using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.QM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.OrdenPago
{
    public class OPHeaderManager
    {
        public int NumeroOP { get; private set; }
        public int IdProveedor { get; private set; }
        public string Lx { get; private set; }
        public string Moneda { get; private set; }
        public decimal ImporteRetenciones { get; private set; }
        public decimal ImporteCreditos { get; private set; }
        public decimal ImporteEfectivo { get; private set; }
        public decimal ImporteCheques { get; private set; }
        public decimal ImporteOtros { get; private set; }
        public decimal ImporteOrdenPago { get; private set; }
        public decimal ImporteFacturas { get; private set; }
        public decimal ImporteTotalImputado { get; private set; }
        public decimal ImporteTotalNoImputado { get; private set; }
        public decimal ImporteSaldoImpago { get; private set; }
        public bool RequiereImputacion { get; private set; }
        public decimal TipoCambio { get; private set; }
        public DateTime FechaOP { get; private set; }
        public string Periodo { get; private set; }
        public int idCtaCte { get;private set; }
        public int Nas { get; private set; }
        public string TipoOPDoc { get; private set; }
        public decimal CreditoPendienteImputar { get; private set; }

        //Constructores
        public OPHeaderManager(int idOP)
        {
            NumeroOP = idOP;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0210_OrdenPagoHeader.SingleOrDefault(c => c.IdOP == idOP);
                IdProveedor = x.IdProveedor;
                Lx = x.Lx;
                Moneda = x.Moneda;
                ImporteRetenciones = x.ImporteRetencionens;
                ImporteCreditos = x.ImporteCreditosAplicados;
                ImporteEfectivo = x.ImporteEfectivo;
                ImporteCheques = x.ImporteCheques;
                ImporteOtros = x.ImporteOtros;
                ImporteOrdenPago = x.ImporteOP;
                ImporteFacturas = x.ImporteFacturas;
                ImporteSaldoImpago = x.SaldoSinAplicarOP;
                RequiereImputacion = false;
                TipoCambio = x.TC;
                FechaOP = x.Fecha;
                Periodo = x.Periodo;
                idCtaCte = x.IdCtaCte;
                Nas = x.Nas ?? -1;
                TipoOPDoc = x.TipoOPDoc;
                //
                ImporteTotalImputado = 0;   //Importe total imputado a facturas
                ImporteTotalNoImputado = 0; //Del total de OP Lo que resta imputar
                var imput = db.T0203_CTACTE_PROV_IMPU
                    .Where(c => c.NUMDOC == idOP.ToString() && c.TCODE.StartsWith("OP")).ToList();
                foreach (var impx in imput)
                {
                    if (impx.TCODE == "OPQ")
                    {
                        //Detalle de Imputacion de Credito.
                        //No se tiene en cuenta para la sumatoria
                    }

                    ImporteTotalImputado += impx.MONTO_IMPU;
                }

                ImporteTotalNoImputado = x.ImporteOP + x.ImporteCreditosAplicados - ImporteTotalImputado;


                //todo: armar una funcion para cargar los datos de aca abajo


            }
        }
        public OPHeaderManager(int idproveedor, string lx, DateTime fechaOP, string monedaOP, decimal tc)
        {
            Lx = lx;
            IdProveedor = idproveedor;
            NumeroOP = -1;
            FechaOP = fechaOP;
            Moneda = monedaOP;
            TipoCambio = tc;
            Periodo = new PeriodoConversion().GetPeriodo(fechaOP);
            Nas = -1;
            idCtaCte = -1;
        }

        private void ResetImportesHeader()
        {
            ImporteRetenciones = 0;
            ImporteCreditos = 0;
            ImporteOtros = 0;
            ImporteEfectivo = 0;
            ImporteOrdenPago = 0;
            ImporteFacturas = 0;
            ImporteTotalImputado = 0;
            ImporteTotalNoImputado = 0;
            RequiereImputacion = false;
        }
        public void SetImporteCredito(decimal importe)
        {
            ImporteCreditos += importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        public void RemoveImporteCredito(decimal importe)
        {
            ImporteCreditos -= importe;
            CreditoPendienteImputar -= importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        public void ResetCreditos()
        {
            ImporteCreditos = 0;
            CreditoPendienteImputar = 0;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        public void SetImporteRetenciones(decimal importe)
        {
            ImporteRetenciones += importe;
            ImporteOrdenPago += importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        public void RemoveImporteRetenciones(decimal importe)
        {
            ImporteRetenciones -= importe;
            ImporteOrdenPago -= importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        public void SetImportePagoCash(decimal importe)
        {
            ImporteEfectivo += importe;
            ImporteOrdenPago += importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }

        public void SetImportePagoCheque(decimal importe)
        {
            ImporteCheques += importe;
            ImporteOrdenPago += importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        
        public void RemoveImportePagoCash(decimal importe)
        {
            ImporteEfectivo -= importe;
            ImporteOrdenPago -= importe;
            RequiereImputacion = true;
            ImporteSaldoImpago=ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        public void RemoveImportePagoCheques(decimal importe)
        {
            ImporteCheques -= importe;
            ImporteOrdenPago -= importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        public void SetImportePagoOtros(decimal importe)
        {
            ImporteOtros += importe;
            ImporteOrdenPago += importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        public void RemoveImportePagoOtros(decimal importe)
        {
            ImporteOtros -= importe;
            ImporteOrdenPago -= importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago - ImporteCreditos;
        }
        public void SetImporteFactura(decimal importe)
        {
            ImporteFacturas += importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago-ImporteCreditos;
        }
        public void RemoveImporteFactura(decimal importe)
        {
            ImporteFacturas -= importe;
            RequiereImputacion = true;
            ImporteSaldoImpago = ImporteFacturas - ImporteOrdenPago-ImporteCreditos;

        }
        public void SetValoresImputacion(decimal imputado)
        {
            decimal disponibleImputar = ImporteOrdenPago + ImporteCreditos;
            ImporteTotalImputado = imputado;
            ImporteTotalNoImputado = disponibleImputar - imputado;
            ImporteSaldoImpago = ImporteFacturas - disponibleImputar;
            if (disponibleImputar > 0)
            {
                RequiereImputacion = true;
            }
            else
            {
                RequiereImputacion = false;
            }
        }
        public bool SetNumeroOP(int numero)
        {
            if (Lx == "L1" || Lx == "L2")
            {
                NumeroOP = numero;
                return true;
            }
            return false;
        }
        public void SetAsientoCtaCte(int numeroAsiento, int idctacte)
        {
            idCtaCte = idctacte;
            Nas = numeroAsiento;
        }
        public void SetImporteCreditoPendienteImputar(decimal importe)
        {
            CreditoPendienteImputar = Math.Abs(importe);
        }
        public void SetImporteCheques(decimal importe)
        {
            ImporteCheques = importe;
        }
        public void SetImporteEfectivo(decimal importe)
        {
            ImporteEfectivo = importe;
        }
        public void SetImporteOtros(decimal importe)
        {
            ImporteOtros = importe;
        }
}
}
