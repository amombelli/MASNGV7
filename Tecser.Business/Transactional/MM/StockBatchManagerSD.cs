using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class StockBatchManagerSD
    {
        public bool ConsolidaStockReservado(int idStockConsolidador, int idStockSecundario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataConsolidador = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStockConsolidador);
                var dataSecundario = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStockSecundario);

                if ((dataConsolidador.Material == dataSecundario.Material) && (dataConsolidador.Batch ==
                                                                               dataSecundario.Batch))
                {
                    dataConsolidador.Stock = dataConsolidador.Stock + dataSecundario.Stock;
                }
                db.T0030_STOCK.Remove(dataSecundario);
                return db.SaveChanges() > 0;
            }
        }

        public void ReservaStockRemitoByRemitoGUID(int idStock, decimal kgATomar, string remitodGuid, int numeroSO, int numeroItemSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                new StockManager().TomaLineaStock(idStock, kgATomar, StockStatusManager.EstadoLote.ReservaRE,
                    remitoGuid: remitodGuid, reservadoOV: numeroSO, reservaItem: numeroItemSO);
            }
        }
        public void ReservaStockRemito(int idStock, decimal kgATomar, int idRemito, int idItemRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                new StockManager().TomaLineaStock(idStock, kgATomar, StockStatusManager.EstadoLote.ReservaRE,
                    reservaId: idRemito, reservaItem: idItemRemito);

                new RemitoItemManager().UpdateItemRemitoReservaLote(idRemito, idItemRemito, idStock, kgATomar);
            }
        }
        public void LiberaStockReservadoRemitoGUID(string numeroRemitoGUID)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var xdel = db.T0030_STOCK.Where(c => c.ReservaGUID.ToString() == numeroRemitoGUID).ToList();
                foreach (var item in xdel)
                {
                    item.ReservaGUID = null;
                    if (string.IsNullOrEmpty(item.EstadoAnteriorReserva) == false)
                    {
                        item.Estado = item.EstadoAnteriorReserva;
                    }
                    else
                    {
                        item.Estado = "Liberado";
                    }
                }
                db.SaveChanges();
            }
        }

        public int ReservaStockRemitoXLote(int idRemito, int idRemitoItem, string material, decimal kgATomar, string loteAReservar)
        {
            new StockManager().OptimizaStockLiberado(material);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x =
                    db.T0030_STOCK.Where(c => c.Material == material && c.Batch == loteAReservar && c.Stock >= kgATomar)
                        .OrderBy(c => c.Stock)
                        .ToList();

                if (x.Count > 0)
                {
                    new StockManager().TomaLineaStock(x[0].IDStock, kgATomar, StockStatusManager.EstadoLote.ReservaRE,
                        reservaId: idRemito, reservaItem: idRemitoItem);
                }
                return x[0].IDStock;
            }
        }
        //Funcion usada al generar/agregar un item de remito a la DB. Al generar el remito ID/ RemitoItem reemplaza
        //si existirea la reserva temporal GUID por el ID del remito + ID item.
        public void ReemplazaRemitoGUIDRemitoId(int idStockComprometido, int idRemito, int idItem, int numeroOVItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStockComprometido);
                if (stk != null)
                {
                    if (stk.Estado != "ReservaRE")
                    {
                        throw new Exception("El Estado del Remito no se corresponde con la reserva ID");
                    }
                    else
                    {
                        if (stk.ReservaGUID != null)
                        {
                            stk.ReservaGUID = null;
                            stk.ReservaID = idRemito;
                            stk.ReservaItem = idItem;
                            stk.OV_Reserva = numeroOVItem;
                        }
                        else
                        {
                            //no hace nada porque se esta tratando de un remito L2/L5 que fue liberado en la parte L1.
                        }
                    }
                }
                db.SaveChanges();
            }
        }


    }
}
