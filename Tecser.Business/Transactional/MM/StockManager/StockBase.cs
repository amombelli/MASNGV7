using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.SuperMD;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{

    //Nueva clase 2018.04.22 A cargo de funciones basicas
    //Luego en heredadas hacen uso de estas basicas (ejemplo stockmovements)
    public abstract class StockBase
    {
        protected int StockLineConstructor(string material, string lote, decimal cantidad, StockStatusManager.EstadoLote estado, string sloc, int? reservaOF = null, int? reservaOV = null, int? despacho = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var s = new T0030_STOCK()
                {
                    IDStock = db.T0030_STOCK.Max(c => c.IDStock) + 1,
                    Material = material,
                    Batch = lote,
                    Stock = cantidad,
                    Estado = estado.ToString(),
                    OV_Reserva = reservaOV,
                    Despacho = despacho,
                    SLOC = sloc,
                    PLTN = StorageLocationManager.GetPlantaFromSloc(sloc),
                    ReservaOF = reservaOF,
                    //UltimoMovimiento
                    //Documento
                    //ReservaID
                    //ReservaItem
                    //ReservaGUID
                    //EstadoAnteriorReserva
                };
                db.T0030_STOCK.Add(s);
                return db.SaveChanges() > 0 ? s.IDStock : 0;
            }
        }
        protected bool UpdateStockLote(int idStock, string newLote)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkLine = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (stkLine == null)
                    throw new InvalidOperationException("La linea de Stock no existe");

                if (newLote != stkLine.Batch)
                {
                    stkLine.Batch = newLote;
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }
        protected bool UpdateStockCantidad(int idStock, decimal newCantidad)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkLine = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (stkLine == null)
                    throw new InvalidOperationException("La linea de Stock no existe");

                if (newCantidad != stkLine.Stock)
                {
                    stkLine.Stock = newCantidad;
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }
        protected bool UpdateStockEstado(int idStock, StockStatusManager.EstadoLote newEstado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkLine = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (stkLine == null)
                    throw new InvalidOperationException("La linea de Stock no existe");

                if (newEstado.ToString() != stkLine.Estado)
                {
                    stkLine.Estado = newEstado.ToString();
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }
        protected bool UpdateStockSloc(int idStock, string newSloc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkLine = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (stkLine == null)
                    throw new InvalidOperationException("La linea de Stock no existe");

                if (newSloc != stkLine.SLOC)
                {
                    stkLine.SLOC = newSloc;
                    stkLine.PLTN = StorageLocationManager.GetPlantaFromSloc(newSloc);
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }
        protected bool UpdateStockLoteNumber(int idStock, string newLote)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkLine = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (stkLine == null)
                    throw new InvalidOperationException("La linea de Stock no existe");

                if (newLote != stkLine.Batch)
                {
                    stkLine.Batch = newLote;
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }

        /// <summary>
        /// Actualiza la linea de stock con la nueva cantidad y genera una nueva linea con la diferencia
        /// </summary>
        protected int SplitStockLineCantidad(int idStock, decimal nuevaCantidad)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkLine = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (stkLine == null)
                    throw new InvalidOperationException("La linea de Stock no existe");

                if (nuevaCantidad > stkLine.Stock)
                    throw new InvalidOperationException("El nuevo stock supera la cantidad de la linea");

                if (nuevaCantidad < stkLine.Stock)
                {
                    var estado = StockStatusManager.MapStatusFromText(stkLine.Estado);
                    var newStockLine = this.StockLineConstructor(stkLine.Material, stkLine.Batch, stkLine.Stock - nuevaCantidad,
                        estado, stkLine.SLOC);

                    if (newStockLine > 0)
                    {
                        UpdateStockCantidad(idStock, nuevaCantidad);
                        return newStockLine;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    //la cantidad a tomar es igual al stock- no hace nada y retorna 0
                    return 0;
                }
            }
        }
        protected T0030_STOCK GetStockLine(int idstock)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                if (stk == null)
                    throw new InvalidOperationException("La linea de stock provista es inexistente *T0030");

                return stk;
            }
        }

    }
}
