using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Vendor
{
    public class ValidacionVendorDocument
    {
        public bool CheckIfDocumentAlreadyExist(int vendorId, string numeroDocumento, string tipoLx, string tipoDoc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x =
                    db.T0403_VENDOR_FACT_H.Where(c => c.IDPROV == vendorId && c.NFACTURA == numeroDocumento && c.TIPO == tipoLx && c.TFACTURA == tipoDoc).ToList();
                return x.Count != 0;
            }
        }
    }
}
