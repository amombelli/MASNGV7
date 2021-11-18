using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Vendor
{
    public class CancelVendorConta
    {

        public bool CancelDocumento(int id403)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fact = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == id403);
                var idctacte = fact.IDCTACTE.Value;
                var ctacte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idctacte);

                var xctacte = new CtaCteVendor(fact.IDPROV).UpdateSaldoCtaCteResumen(ctacte.TIPO,
                      ctacte.IMPORTE_ORI * -1, ctacte.MONEDA, ctacte.TC);

                db.T0203_CTACTE_PROV.Remove(ctacte);
                int asiento;
                if (fact.NASIENTO != null)
                {
                    asiento = fact.NASIENTO.Value;
                    var xi = db.T0602_DOCU_S.Where(c => c.IDDOCU == asiento).ToList();
                    var xh = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == asiento);
                    db.T0602_DOCU_S.RemoveRange(xi);
                    xh.StatusCancel = true;
                    xh.ST = "Cancelado";
                    //db.T0601_DOCU_H.Remove(xh);
                    db.SaveChanges();
                }

                var factItem = db.T0404_VENDOR_FACT_I.Where(c => c.IDINT == id403).ToList();
                db.T0404_VENDOR_FACT_I.RemoveRange(factItem);
                db.T0403_VENDOR_FACT_H.Remove(fact);
                db.SaveChanges();
                return true;



            }
        }


        public bool PermiteCancelar(int id403)
        {
            //para cancelar debe estar el documento impago
            //si esta pago no permite cancelar - hacer fx para despagar documento
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fact = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == id403);
                if (fact.StatusDocumento != "A Validar")
                    return false;

                var idctacte = fact.IDCTACTE.Value;
                var ctacte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idctacte);
                if (ctacte.SALDOFACTURA != ctacte.IMPORTE_ORI)
                    return false;

                var xctacte = new CtaCteVendor(fact.IDPROV).UpdateSaldoCtaCteResumen(ctacte.TIPO,
                    ctacte.IMPORTE_ORI * -1, ctacte.MONEDA, ctacte.TC);

                db.T0203_CTACTE_PROV.Remove(ctacte);
                int asiento;
                if (fact.NASIENTO != null)
                {
                    asiento = fact.NASIENTO.Value;
                    var xi = db.T0602_DOCU_S.Where(c => c.IDDOCU == asiento).ToList();
                    var xh = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == asiento);
                    db.T0602_DOCU_S.RemoveRange(xi);
                    xh.StatusCancel = true;
                    xh.ST = "Cancelado";
                    //db.T0601_DOCU_H.Remove(xh);
                    db.SaveChanges();
                }

                var factItem = db.T0404_VENDOR_FACT_I.Where(c => c.IDINT == id403).ToList();
                db.T0404_VENDOR_FACT_I.RemoveRange(factItem);
                db.T0403_VENDOR_FACT_H.Remove(fact);
                db.SaveChanges();
                return true;
            }
        }

    }
}
