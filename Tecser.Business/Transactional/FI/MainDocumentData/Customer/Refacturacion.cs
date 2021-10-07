using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Customer
{
    public class Refacturacion
    {
        public int GetIdFacturaFromRemito(string numeroRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0400_FACTURA_H.Where(c => c.Remito == numeroRemito).ToList();
                if (!data.Any())
                    return 0;

                if (data.Count > 1)
                    return -1;
                return data[0].IDFACTURA;
            }
        }


    }
}
