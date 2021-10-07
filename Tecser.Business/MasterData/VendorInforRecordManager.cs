using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData
{
    public class VendorInforRecordManager
    {
        public T0066_ITEMS_PROVEEDOR_OC GetInfoRecord(int idProveedor, string item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0066_ITEMS_PROVEEDOR_OC.SingleOrDefault(c => c.PROVEEDOR == idProveedor && c.ITEM == item);
            }
        }

        public void MantieneInforecordProveedorMaterial(int idProveedor, string item, string moneda, decimal precioUnitario, string GL, bool recuerdaPrecio)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0066_ITEMS_PROVEEDOR_OC.SingleOrDefault(
                        c => c.PROVEEDOR == idProveedor && c.ITEM.ToUpper().Equals(item.ToUpper()));

                if (data != null)
                {
                    db.T0066_ITEMS_PROVEEDOR_OC.Remove(data);
                    db.SaveChanges();
                }

                var xitem = new T0066_ITEMS_PROVEEDOR_OC()
                {
                    PROVEEDOR = idProveedor,
                    GL = GL,
                    ITEM = item,
                    MON = moneda,
                    PRECIO_U = precioUnitario,
                    RECUERDA_PRECIO = recuerdaPrecio,
                    LOGUSER = Environment.UserDomainName,
                    LOGDATE = DateTime.Now,
                };
                db.T0066_ITEMS_PROVEEDOR_OC.Add(xitem);
                db.SaveChanges();
            }
        }
    }
}
