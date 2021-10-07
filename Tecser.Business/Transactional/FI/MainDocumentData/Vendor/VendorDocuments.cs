using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Vendor
{
    public class VendorDocuments
    {
        public List<T0403_VENDOR_FACT_H> GetVendorDocuments(int vendorId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0403_VENDOR_FACT_H.Where(c => c.IDPROV == vendorId).OrderByDescending(c => c.FECHA).ToList();
            }
        }

        public T0403_VENDOR_FACT_H GetDocument(int id403)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0403_VENDOR_FACT_H.FirstOrDefault(c => c.IDINT == id403);
            }
        }

        public List<T0404_VENDOR_FACT_I> GetDocumentItems(int id403)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0404_VENDOR_FACT_I.Where(c => c.IDINT == id403).ToList();
            }
        }

        public List<T0203_CTACTE_PROV_IMPU> GetImputacionDocumento(int idDoc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0203_CTACTE_PROV_IMPU.Where(c => c.CTACTE1 == idDoc).ToList();
            }
        }
    }
}
