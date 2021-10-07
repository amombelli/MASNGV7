using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    /// <summary>
    /// Actualizacion de Stocks Total en T0072 + Liberacion de Asignaciones de Lotes y Reservas
    /// </summary>

    public class StockBatchManagerOF
    {

        public void ActualizaStockDisponibleT0072(int idOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var planta = "";
                planta = PlanProduccionListManager.GetOFData(idOF).PLTN ?? "CERR";

                var data = db.T0072_FORMULA_TEMP.Where(c => c.OF == idOF).ToList();
                {
                    foreach (var item in data)
                    {
                        item.STKLiberado = new StockList().GetKgStockDisponibleProduccion(item.Primario, planta);
                        item.STKTotal = StockList.GetKgStockTotalByMaterial(item.Primario, planta);
                    }
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Libera individualmente un item reservado en una OF.
        /// </summary>
        /// <returns></returns>
        public bool LiberacionLoteOrdenFabricacionIndividual(int idplan, int iditem)
        {
            //Funcion modificado poruqe si se necesita liberar un item en el ES que fue agregado, el mismo no se encuentra
            //en la formula impresa (T73) por lo tanto lo hace en 2 tandas

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t72 = db.T0072_FORMULA_TEMP.SingleOrDefault(c => c.OF == idplan && c.idItemFormula == iditem);
                if (t72 == null)
                    return false;

                var stk1 = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == t72.idStockReservado);
                if (stk1 == null)
                    return false;

                if (t72.Primario != stk1.Material)
                    return false;
                //libera en T30 y en T72
                stk1.Estado = "Liberado";
                stk1.ReservaOF = null;

                t72.BatchNumber = null;
                t72.idStockReservado = null;

                var upd = db.SaveChanges();

                var t73 = db.T0073_FORMULA_PRINT.SingleOrDefault(c => c.OF == idplan && c.idItemFormula == iditem);
                if (t73 != null)
                {
                    t73.BatchNumber = null;
                    t73.idStockReservado = null;
                    upd = upd + db.SaveChanges();
                }

                if (upd > 0)
                {
                    new StockManager().OptimizaStockLiberado(stk1.Material);
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Reserva una linea especifica de stock.
        /// </summary>
        /// <returns>
        /// true = reservo ok
        /// false = no reservo por algun error
        /// </returns>
        public bool ReservaLoteOrdenFabricacionIndividual(int idstock, int idplan, int iditem, decimal kgRequeridos)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stock = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                if (stock == null) return false;

                var t72 = db.T0072_FORMULA_TEMP.SingleOrDefault(c => c.OF == idplan && c.idItemFormula == iditem);
                if (t72 == null) return false;

                var t73 = db.T0073_FORMULA_PRINT.SingleOrDefault(c => c.OF == idplan && c.idItemFormula == iditem);
                if (t73 == null) return false;

                //Toma linea stock
                new StockManager().TomaLineaStock(idstock, kgRequeridos, StockStatusManager.EstadoLote.ReservaPF, reservadoOF: idplan);

                t72.BatchNumber = stock.Batch;
                t72.idStockReservado = idstock;

                t73.BatchNumber = stock.Batch;
                t73.idStockReservado = idstock;

                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// propone un lote para OrdenFabricacion >> Lo guarda en T0072
        /// Si la planta no esta en T0072 - Asigna por default "CERR"
        /// El lote lo reserva en T0030.-
        /// </summary>
        public void ReservaLoteOrdenFabricacionCompleta(int idplan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var planta = PlanProduccionListManager.GetOFData(idplan).PLTN ?? "CERR";

                var pf = db.T0072_FORMULA_TEMP.Where(c => c.OF == idplan).ToList();
                {
                    foreach (var ipf in pf)
                    {
                        if ((ipf.MaterialExtra == false || ipf.Modificado == false) && ipf.CantidadKG > 0 && string.IsNullOrEmpty(ipf.BatchNumber))
                        {
                            //El material no es ni agregado ni modificado, tiene cantidad >0 y no tiene lote.
                            var idStock = ProponeLoteAutomaticoReservaProduccion(ipf.Primario, ipf.CantidadKG.Value, planta);
                            if (idStock > 0)
                            {
                                //Si encuentra un lote disponible lo asigna automaticamente
                                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                                ipf.BatchNumber = stk.Batch;
                                ipf.idStockReservado = stk.IDStock;
                                //
                                new StockManager().TomaLineaStock(idStock, decimal.Round(ipf.CantidadKG.Value, 2),
                                    StockStatusManager.EstadoLote.ReservaPF, reservadoOF: idplan);
                            }
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
        //Aux en ReservaAutomaticaLoteOrdenFabricacion
        private static int ProponeLoteAutomaticoReservaProduccion(string material, decimal kgRequeridos, string planta = "CERR")
        {
            new StockManager().OptimizaStockLiberado(material); //Optimiza Stock

            var posibleStock = new StockList().GetAllByMaterial_DisponibleProduccion(material, planta);
            var asignar = posibleStock.Where(c => c.Stock >= kgRequeridos).OrderBy(c => c.Stock).ToList();

            if (asignar.Count > 0)
                return asignar[0].IDStock;
            return -1;
        }
        public void AsignaLoteReservadoMateriaPrimaEnOF(int idplan, int iditem, int idstock)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stock = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                if (stock == null) return;

                var t72 = db.T0072_FORMULA_TEMP.SingleOrDefault(c => c.OF == idplan && c.idItemFormula == iditem);
                if (t72 == null) return;

                t72.BatchNumber = stock.Batch;
                t72.idStockReservado = idstock;

                db.SaveChanges();
            }
        }


    }
}
