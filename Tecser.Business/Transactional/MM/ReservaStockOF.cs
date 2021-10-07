using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    /// <summary>
    /// Reserva Y Liberacion de un STOCK para una OF
    /// </summary>
    public class ReservaStockOF
    {
        public int GetIdStockReservadoOrdenFabricacion(string material, int numeroOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0030_STOCK.Where(c => c.Material.ToUpper().Equals(material.ToUpper()) && c.ReservaOF == numeroOF)
                        .ToList();
                if (data.Count == 0)
                    return -1;
                return data.First().IDStock;
            }
        }

        public int LiberaStockReservadoOF(string material, int numeroOF, string loteALiberar)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0030_STOCK.Where(
                        c =>
                            c.Material.ToUpper().Equals(material.ToUpper()) && c.ReservaOF == numeroOF &&
                            c.Batch.ToUpper().Equals(loteALiberar.ToUpper())).ToList();
                foreach (var item in data)
                {
                    item.ReservaOF = null;
                    item.Estado = StockStatusManager.EstadoLote.Liberado.ToString();
                }
                return db.SaveChanges();
            }
        }

        public int LiberaStockReservadoOF(string material, int numeroOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0030_STOCK.Where(
                    c => c.Material.ToUpper().Equals(material.ToUpper()) && c.ReservaOF == numeroOF)
                    .ToList();
                foreach (var item in data)
                {
                    if (item.EstadoAnteriorReserva == null)
                    {
                        item.Estado = StockStatusManager.EstadoLote.Liberado.ToString();
                    }
                    else
                    {
                        item.Estado = item.EstadoAnteriorReserva;
                    }
                    var t72 = db.T0072_FORMULA_TEMP.SingleOrDefault(c => c.idStockReservado == item.IDStock);
                    if (t72 != null)
                    {
                        t72.BatchNumber = null;
                        t72.idStockReservado = null;
                    }
                    var t73 = db.T0073_FORMULA_PRINT.SingleOrDefault(c => c.idStockReservado == item.IDStock);
                    if (t73 != null)
                    {
                        t73.BatchNumber = null;
                        t73.idStockReservado = null;
                    }
                    item.ReservaOF = null;
                }
                return db.SaveChanges();
            }
        }

        //Actualizacion de Funcionalidad *
        //Elimina all in Stock T0030 asociado a una OF
        //Si el Opcional clean7273 esta activado lleva la limpieza de datos hacia tablas T0072 y T0073
        //Esta funcionalidad es opcional para poder utilizar esta funciona al cerrar una OF y liberar si por error quedo algo reservado 'colgado'072/T0073]
        public int LiberaStockReservadoOF(int numeroOrdenFabricacion, bool limpiaT0072_73)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0030_STOCK.Where(c => c.ReservaOF == numeroOrdenFabricacion).ToList();
                foreach (var i in data)
                {
                    i.ReservaOF = null;
                    i.Estado = i.EstadoAnteriorReserva ?? StockStatusManager.EstadoLote.Liberado.ToString();
                }
                var ri = db.SaveChanges();

                if (limpiaT0072_73)
                {
                    var ofx = db.T0072_FORMULA_TEMP.Where(c => c.OF == numeroOrdenFabricacion).ToList();
                    foreach (var data1 in ofx)
                    {
                        data1.BatchNumber = null;
                        data1.idStockReservado = null;
                    }
                    db.SaveChanges();
                    //
                    var ofp = db.T0073_FORMULA_PRINT.Where(c => c.OF == numeroOrdenFabricacion).ToList();
                    foreach (var data2 in ofp)
                    {
                        data2.BatchNumber = null;
                        data2.idStockReservado = null;
                    }
                    db.SaveChanges();
                }
                return ri;
            }
        }

        /// <summary>
        /// Liberacion de un ITEM especifico desde el DGV --> Hacia tabla T0030
        /// </summary>
        public bool LiberaStockReservadoOF(int numeroOrdenFabricacion, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d72 =
                    db.T0072_FORMULA_TEMP.SingleOrDefault(
                        c => c.OF == numeroOrdenFabricacion && c.idItemFormula == idItem);

                if (d72 == null)
                    return false;

                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == d72.idStockReservado.Value);
                if (stk != null)
                {
                    if (stk.Material == d72.Primario)
                    {
                        if (stk.EstadoAnteriorReserva == null)
                        {
                            stk.ReservaOF = null;
                            stk.Estado = StockStatusManager.EstadoLote.Liberado.ToString();
                        }
                        else
                        {
                            stk.ReservaOF = null;
                            stk.Estado = stk.EstadoAnteriorReserva;
                        }
                    }
                }
                else
                {
                    return false;
                }

                d72.BatchNumber = null;
                d72.idStockReservado = null;

                var d73 =
                    db.T0073_FORMULA_PRINT.SingleOrDefault(
                        c => c.OF == numeroOrdenFabricacion && c.idItemFormula == idItem);

                if (d73 != null)
                {
                    d73.BatchNumber = null;
                    d73.idStockReservado = null;
                }
                db.SaveChanges();
                new StockManager().OptimizaStockLiberado(stk.Material);
                return true;
            }
        }
        public void ReservarStockOF(int idstock, int numeroOrdenFabricacion, decimal cantidadKg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);

                if (stk.Stock > cantidadKg)
                {
                    //Split en linea stock
                    new StockManager().DuplicaLineaStock(idstock, decimal.Round(stk.Stock - cantidadKg, 2));
                    stk.Stock = cantidadKg;
                }
                else
                {
                    //En esta funcion tiene que ser igual!
                }

                stk.Estado = "ReservaPF";
                stk.ReservaOF = numeroOrdenFabricacion;
                db.SaveChanges();
            }
        }
    }
}
