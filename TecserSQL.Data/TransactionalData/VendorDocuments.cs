using System.Linq;
using TecserEF.Entity;


namespace TecserSQL.Data.TransactionalData
{
    public class VendorDocuments
    {
        public VendorDocuments(string conn)
        {
            GlobalApp.CnnApp = conn;
        }
        private static class GlobalApp
        {
            public static string CnnApp;
        }

        public bool FixBaseImponibleFacturasAPagar(int idFactura, decimal baseImponible)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == idFactura);
                if (data != null) data.BaseImponible = baseImponible;
                return db.SaveChanges() > 1;
            }

        }



        public bool AltaDocumentoTablaRetenciones(T0405_FACTURAS_RETENCIONES fp)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                db.T0405_FACTURAS_RETENCIONES.Add(fp);
                return db.SaveChanges() > 0;
            }
        }

        public bool UpdateDocumentoTablaRetenciones(T0405_FACTURAS_RETENCIONES fp)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0405_FACTURAS_RETENCIONES.SingleOrDefault(
                        c => c.IDFacturaProveedor == fp.IDFacturaProveedor && c.NumeroOP == fp.NumeroOP);

                db.Entry(data).CurrentValues.SetValues(fp);
                return (db.SaveChanges() > 0);
            }
        }
    }
}
