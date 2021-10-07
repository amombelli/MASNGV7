using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class CustomerDocumentSearch
    {
        public T0400_FACTURA_H GetHeaderData(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
            }
        }
        public List<T0401_FACTURA_I> GetItemData(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
            }
        }
        public List<T0400_FACTURA_H> GetListDocument(int? idCustomer)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idCustomer == null)
                {
                    return db.T0400_FACTURA_H.OrderByDescending(c => c.IDFACTURA).ToList();
                }
                else
                {
                    return
                        db.T0400_FACTURA_H.Where(c => c.Cliente == idCustomer)
                            .OrderByDescending(c => c.IDFACTURA)
                            .ToList();
                }
            }
        }
        public int GetIdFacturaFromIdCtaCte(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                return x?.IDDOC ?? 0;
            }
        }
    }
}
