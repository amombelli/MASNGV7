using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.ContabilizacionProveedores
{
    public class InterfazItemsIngresados
    {
        public List<string> GetListaRemitosByVendor(int idVendor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var remitosDisponibles =
                    db.T0063_ITEMS_OC_INGRESADOS.Where(c => c.PROVEEDOR == idVendor && c.CONTA.Value == false)
                        .OrderBy(c => c.FECHA_IN).ToList();
                return remitosDisponibles.Where(c => c.NREMITO != null).Select(c => c.NREMITO).Distinct().ToList();
            }
        }

        public List<T0063_ITEMS_OC_INGRESADOS> GetListOfItemsByVendorRemito(int idVendor, string numeroRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0063_ITEMS_OC_INGRESADOS.Where(
                        c => c.PROVEEDOR == idVendor && c.CONTA == false && c.NREMITO.Equals(numeroRemito)).ToList();
            }
        }

        public T0063_ITEMS_OC_INGRESADOS GetSpecificRecord(int idT063)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0063_ITEMS_OC_INGRESADOS.SingleOrDefault(c => c.ID == idT063);
            }
        }
    }
}
