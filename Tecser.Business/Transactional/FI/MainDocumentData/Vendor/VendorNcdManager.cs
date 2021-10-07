using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Vendor
{
    public class VendorNcdManager
    {


        public void RemoveFromNcdp(int idh)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var itemData = db.T0311_NCDP_I.Where(c => c.IDH == idh).ToList();
                db.T0311_NCDP_I.RemoveRange(itemData);
                db.SaveChanges();
                var h = db.T0310_NCDP_H.SingleOrDefault(c => c.IDH == idh);
                db.T0310_NCDP_H.Remove(h);
                db.SaveChanges();
            }
        }
    }
}
