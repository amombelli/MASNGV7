using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class NcdSeleccionItemsKg
    {
        public List<T0401_FACTURA_I> GetItemList(int idCliente, string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                   db.T0401_FACTURA_I.Where(
                        c => c.T0400_FACTURA_H.Cliente == idCliente && c.T0400_FACTURA_H.TIPOFACT == tipoLx)
                        .OrderByDescending(c => c.IDFactura)
                        .ToList();
            }
        }
        public T0401_FACTURA_I GetDatosFacturaItem(int idFactura, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0401_FACTURA_I.SingleOrDefault(c => c.IDFactura == idFactura && c.IDITEM == idItem);
            }

        }
    }
}
