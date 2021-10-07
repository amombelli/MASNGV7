using System.Linq;
using TecserEF.Entity;

namespace TecserSQL.Data.TransactionalData
{
    public class OrdenPago
    {
        public OrdenPago(string con)
        {
            GlobalApp.CnnApp = con;
        }

        private static class GlobalApp
        {
            public static string CnnApp;
        }

        public bool RemoveFacturaT405Retenciones(int numeroOP, int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0405_FACTURAS_RETENCIONES.FirstOrDefault(
                        c => c.NumeroOP == numeroOP && c.IDFacturaProveedor == idFactura);
                if (data != null)
                {
                    db.T0405_FACTURAS_RETENCIONES.Remove(data);
                    return db.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool SaveOrdenPagoHeader(T0210_OP_H header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == header.IDOP);
                if (result == null)
                {
                    var data = db.T0210_OP_H.Add(header);
                }
                else
                {
                    db.Entry(result).CurrentValues.SetValues(header);
                }
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool SaveOrdenPagoFactura(T0213_OP_FACT factu)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0213_OP_FACT.Add(factu);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool SaveOrdenPagoItemPago(T0212_OP_ITEM item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0212_OP_ITEM.Add(item);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool RemoveFacturaOP(int idItem, int numeroOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0213_OP_FACT.FirstOrDefault(c => c.IDOP == numeroOP && c.IDITEM == idItem);
                if (data != null)
                {
                    db.T0213_OP_FACT.Remove(data);
                    return db.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool RemoveItemOP(int idItem, int numeroOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0212_OP_ITEM.FirstOrDefault(c => c.IDOP == numeroOP && c.IDITEM == idItem);
                if (data != null)
                {
                    db.T0212_OP_ITEM.Remove(data);
                    return db.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
        }


        private int GetNextIdPago()
        {
            return new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Max(c => c.IDITEM) + 1;
        }


        public int AltaItemPago(T0212_OP_ITEM item)
        {
            item.IDITEM = GetNextIdPago();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0212_OP_ITEM.Add(item);
                if (db.SaveChanges() > 0)
                {
                    return data.IDITEM;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int AltaOrdenPago(T0212_OP_ITEM item)
        {
            item.IDITEM = GetNextIdPago();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0212_OP_ITEM.Add(item);
                if (db.SaveChanges() > 0)
                {
                    return data.IDITEM;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
