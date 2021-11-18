using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Imputacion
{
    public class ManageVendorImputacionDocumentos
    {
        public void GeneraImputacionDesdeOP(int numeroOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ip = db.T0213_OP_FACT.Where(c => c.IDOP == numeroOP).ToList();
                var IdctacteOP = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.DOC_INTERNO == numeroOP.ToString()).IDCTACTE;
                var opH = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == numeroOP);
                foreach (var i in ip)
                {
                    GeneraMovimientoImputacion(i.IdCtaCte.Value, IdctacteOP, null, "OPX", opH.NAS.Value);
                }
            }
        }
        public bool GeneraMovimientoImputacion(int idCtaCteFacturaImputar, int idCtaCteMovimientoPago, string glPago, string tcode, int nAsientoPago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var docAImputar = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCteFacturaImputar);
                var docDePago = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCteMovimientoPago);

                if (docAImputar == null)
                    return false;

                if (docDePago == null)
                    return false;

                //if (docDePago.IMPORTE_ORI <0)
                var importe = Math.Abs(docDePago.IMPORTE_ORI);

                var x = new T0203_CTACTE_PROV_IMPU()
                {
                    CTACTE1 = idCtaCteFacturaImputar,
                    CTACTE2 = idCtaCteMovimientoPago,
                    IDPROV = docAImputar.IDPROV,
                    LogDate = DateTime.Now,
                    LogUser = Environment.UserName,
                    NUMDOC = docAImputar.NUMDOC,
                    MONTO_IMPU = importe,
                    GLPAGO = glPago,
                    TDOC = docDePago.TDOC,
                    TCODE = tcode,
                    NAS_PAGO = nAsientoPago
                };
                db.T0203_CTACTE_PROV_IMPU.Add(x);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
    }
}
