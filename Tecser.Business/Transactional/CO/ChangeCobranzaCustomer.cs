using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    public class ChangeCobranzaCustomer
    {

        public void ChangeCobranzaToAnotherCustomer(int idCobranza, int nuevoCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataCobranza = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCobranza);
                int idClienteOriginal = dataCobranza.IdCliente.Value;
                dataCobranza.IdCliente = nuevoCliente;
                string numeroRecibo = dataCobranza.NRECIBO;
                string sidCobranza = idCobranza.ToString();
                var t201 = db.T0201_CTACTE.SingleOrDefault(c => c.TDOC == "CO" && c.IDT2 == idCobranza);
                t201.IDCLI = nuevoCliente;

                //Update Saldos (suma a cliente original -- resta a nuevo cliente)
                var ctaOri = new CtaCteCustomer(idClienteOriginal);
                ctaOri.UpdateSaldoCtaCteResumen(dataCobranza.CUENTA, dataCobranza.Monto, dataCobranza.MON, dataCobranza.TC);


                //var ctacteOri = new CustomerCtaCte(idClienteOriginal, dataCobranza.CUENTA);
                //ctacteOri.UpdateImporteCtaCte(dataCobranza.MON, dataCobranza.Monto.Value, dataCobranza.TC.Value);

                var ctaNew = new CtaCteCustomer(nuevoCliente);
                ctaNew.UpdateSaldoCtaCteResumen(dataCobranza.CUENTA, dataCobranza.Monto * -1, dataCobranza.MON,
                    dataCobranza.TC);

                //var ctacteNew = new CustomerCtaCte(nuevoCliente, dataCobranza.CUENTA).UpdateImporteCtaCte(dataCobranza.MON,
                //    dataCobranza.Monto.Value*-1, dataCobranza.TC.Value);


                var t208 = db.T0208_COB_NO_APLICADA.Where(c => c.IDRECIBO == idCobranza).ToList();
                foreach (var ix in t208)
                {
                    ix.CLIENTE = nuevoCliente;
                }
                db.SaveChanges();
                new AsientoContableManager().ChangeAsientoCobranzaCustomer(numeroRecibo, nuevoCliente);
                ChangeChequeCustomerToAnotherCustomer(idCobranza, nuevoCliente);
            }
        }

        private bool ChangeChequeCustomerToAnotherCustomer(int idCobranza, int newCustomer)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var numeroRecibo = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCobranza).NRECIBO;
                var listaChequesRecibo = db.T0154_CHEQUES.Where(c => c.RECIBON.Equals(numeroRecibo)).ToList();
                foreach (var ch in listaChequesRecibo)
                {
                    ch.CLIENTE = newCustomer.ToString();
                    ch.COMENTARIO = ch.COMENTARIO + " COB_CHG_CUST";
                }

                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

    }
}
