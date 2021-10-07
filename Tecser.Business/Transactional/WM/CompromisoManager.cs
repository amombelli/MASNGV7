using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.WM
{
    public class CompromisoManager
    {
        public List<CqStockStructure> CompletaEstructuraCompromiso()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from stk in db.T0030_STOCK
                            join ovh in db.T0045_OV_HEADER on stk.OV_Reserva equals ovh.IDOV
                            select new CqStockStructure()
                            {
                                Idstock = stk.IDStock,
                                Material = stk.Material,
                                Estado = stk.Estado,
                                Lote = stk.Batch,
                                SLOC = stk.SLOC,
                                TotalKg = stk.Stock,
                                ClienteReserva = ovh.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                DocumentoReserva = stk.ReservaOF == 0 ? null : stk.ReservaOF,
                                IdOrdenVentaReserva = stk.OV_Reserva == 0 ? null : stk.OV_Reserva,
                                MaterialType = stk.T0010_MATERIALES.TIPO_MATERIAL
                            };
                var lista = query.ToList();
                return query.ToList();
            }
        }

        public bool isItemComprometido(int idOV, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.Where(c =>
                    c.Estado == StockStatusManager.EstadoLote.Comprometido.ToString() && c.OV_Reserva == idOV &&
                    c.ReservaItem == idItem).ToList();

                return stk.Any();
            }
        }
        /// <summary>
        /// Sirve para liberar una compromiso de Stock cuando se compromete y no se agrega el item
        /// </summary>
        public void FreeItemComprometidoByItemId(int idOV, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.Where(c =>
                    c.Estado == StockStatusManager.EstadoLote.Comprometido.ToString() && c.OV_Reserva == idOV &&
                    c.ReservaItem == idItem).ToList();
                foreach (var stkItem in stk)
                {
                    FreeStockComprometidoByIdstock(stkItem.IDStock, false);
                }
            }
        }
        public void ComprometeStock(int idStock, decimal kgATomar, int idSalesOrder, int idItemSalesOrder)
        {
            new StockManager().TomaLineaStock(idStock, kgATomar, StockStatusManager.EstadoLote.Comprometido, idSalesOrder, reservaItem: idItemSalesOrder);
        }
        public decimal GetKgComprometidosPorSalesOrder(int salesOrder, int itemSalesOrder)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0030_STOCK.Where(
                        c =>
                            c.Estado == StockStatusManager.EstadoLote.Comprometido.ToString() &&
                            c.OV_Reserva == salesOrder && c.ReservaItem == itemSalesOrder);

                decimal Kg = 0;
                foreach (var dx in data)
                {
                    Kg += dx.Stock;
                }
                return Kg;
            }
        }
        /// <summary>
        /// 2020-07-14 Nueva funcion para liberar stock comprometido con opcion (casi mandatoria) de limpiar
        /// datos y actualizar stock comprometido en la OV
        /// </summary>
        public bool FreeStockComprometidoByIdstock(int idStockReservado, bool clearSalesOrder)
        {
            var records = 0;
            int idOv = 0;
            int idOvItem = 0;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stock = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStockReservado);
                if (stock != null)
                {
                    stock.Estado = string.IsNullOrEmpty(stock.EstadoAnteriorReserva) == true
                        ? "Liberado"
                        : stock.EstadoAnteriorReserva;

                    if (stock.Estado == "Comprometido")
                        stock.Estado = "Liberado";

                    if (clearSalesOrder)
                    {
                        if (stock.OV_Reserva != null)
                            idOv = stock.OV_Reserva.Value;

                        if (stock.ReservaItem != null)
                            idOvItem = stock.ReservaItem.Value;

                        var ov = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idOv && c.IDITEM == idOvItem);
                        if (ov != null)
                        {
                            ov.OBSERVACIONES += " - Compromiso Liberado";
                            var xcompro = ov.KGStockComprometido - stock.Stock;
                            if (xcompro <= 0)
                            {
                                ov.KGStockComprometido = 0;
                                ov.FlagStockComprometido = false;
                            }
                            else
                            {
                                ov.KGStockComprometido = xcompro;
                                ov.FlagStockComprometido = true;
                            }
                        }
                        else
                        {
                            //no se encontro el item/ov asi que continua sin erro

                        }
                    }
                    stock.OV_Reserva = null;
                    stock.ReservaGUID = null;
                    stock.ReservaID = null;
                    stock.ReservaItem = null;
                    records = db.SaveChanges();
                    new StockManager().OptimizaStockLiberado(stock.Material);
                }
                return records > 0;
            }
        }
        public bool CheckIfExistReservaRE(Guid? myGuid)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = new List<T0030_STOCK>();
                if (myGuid == null)
                {
                    stk = db.T0030_STOCK.Where(c =>
                        c.Estado == StockStatusManager.EstadoLote.ReservaRE.ToString() && c.ReservaGUID != null).ToList();
                }
                else
                {
                    stk = db.T0030_STOCK.Where(c =>
                        c.Estado == StockStatusManager.EstadoLote.ReservaRE.ToString() && c.ReservaGUID != myGuid).ToList();
                }

                if (stk.Any())
                    return true;
                return false;
            }
        }

        public bool FreeReservaRE(int idStock)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (x == null)
                    return false;

                x.Estado = StockStatusManager.EstadoLote.Liberado.ToString();
                x.UltimoMovimiento = DateTime.Today;
                x.Despacho = 0;
                x.ReservaOF = null;
                x.ReservaGUID = null;
                x.ReservaItem = null;
                x.ReservaID = null;
                x.EstadoAnteriorReserva = StockStatusManager.EstadoLote.ReservaRE.ToString();
                return db.SaveChanges() > 0;
            }
        }
    }
}
