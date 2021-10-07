using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public struct RetornoKgRemito
    {
        public decimal KgConLote { get; set; }
        public decimal KgTotales { get; set; }
    }
    public class RemitoItemManager
    {

        public static List<T0056_REMITO_I> GetRemitoItemlist(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
            }
        }

        public int AddRemitoItem(T0056_REMITO_I item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                item.IDITEM = GetNextIdRemitoItem();
                db.T0056_REMITO_I.Add(item);
                if (db.SaveChanges() > 0)
                {
                    if (item.idStockComprometido > 0)
                    {
                        new StockBatchManagerSD().ReemplazaRemitoGUIDRemitoId((int)item.idStockComprometido,
                            item.IDREMITO, item.IDITEM, item.IDOV.Value);
                    }
                    return item.IDITEM;
                }

                return 0;
            }
        }

        public void UpdateItemRemitoReservaLote(int idRemito, int idRemitoItem, int idStock, decimal kg, bool setGenerarAsFalse = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var remitoItem = db.T0056_REMITO_I.SingleOrDefault(c => c.IDREMITO == idRemito && c.IDITEM == idRemitoItem);
                if (remitoItem == null)
                    return;

                if (idStock == 0)
                {
                    remitoItem.idStockComprometido = null;
                    remitoItem.BATCH = null;
                    remitoItem.BATCH_REMITO = null;
                    remitoItem.SLOC = null;
                }
                else
                {
                    var stkSelected = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                    remitoItem.idStockComprometido = idStock;
                    remitoItem.BATCH = stkSelected.Batch;
                    remitoItem.BATCH_REMITO = stkSelected.Batch;
                    remitoItem.SLOC = stkSelected.SLOC;
                }
                remitoItem.KGDESPACHADOS = kg;
                remitoItem.STATUSITEM = RemitoStatusManager.StatusItem.SinAsignar.ToString();

                if (kg == 0 || setGenerarAsFalse)
                {
                    remitoItem.GENERAR_REMITO = false;
                }
                else
                {
                    remitoItem.GENERAR_REMITO = true;
                }

                db.SaveChanges();
            }
        }
        public int DuplicaRemitoItemDb(int idRemito, int idItemRemito, decimal newKg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var elemento = db.T0056_REMITO_I.SingleOrDefault(c => c.IDREMITO == idRemito && c.IDITEM == idItemRemito);
                if (elemento == null)
                    return 0;

                var item = new T0056_REMITO_I
                {
                    NUMREMITO = elemento.NUMREMITO,
                    IDREMITO = elemento.IDREMITO,
                    IDITEM = GetNextIdRemitoItem(),
                    IDOV = elemento.IDOV,
                    IDOVITEM = elemento.IDOVITEM,
                    MATERIAL = elemento.MATERIAL,
                    MATERIALAKA = elemento.MATERIALAKA,
                    KGINI = elemento.KGINI,
                    KGDESPACHADOS = newKg,
                    KGDESPACHADOS_R = newKg,
                    L5 = elemento.L5,
                    LX = elemento.LX,
                    DESC_REMITO = elemento.DESC_REMITO,
                    GENERAR_REMITO = false,
                    BATCH = null,
                    BATCH_REMITO = null,
                    GL = elemento.GL,
                    GLV = elemento.GLV,
                    KG_PENDIENTES = 0,
                    STATUSITEM = RemitoStatusManager.StatusItem.SinAsignar.ToString(),
                };
                db.T0056_REMITO_I.Add(item);
                return db.SaveChanges() > 0 ? item.IDITEM : 0;
            }
        }
        private static int GetNextIdRemitoItem()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0056_REMITO_I.Max(c => c.IDITEM) + 1;
            }
        }
        public void ConsolidaItemsRemito(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var itemList = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito);
                var newRemitoList = new List<T0056_REMITO_I>();

                foreach (var item in itemList.ToList())
                {
                    var consolida = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito &&
                                                                 c.MATERIAL == item.MATERIAL && c.BATCH == item.BATCH &&
                                                                 c.IDOV == item.IDOV &&
                                                                 c.IDOVITEM == item.IDOVITEM &&
                                                                 c.BATCH_REMITO != "@interno@").ToList();

                    if (consolida.Count > 1)
                    {
                        //Hay items para consolidar . -
                        var idPrimerItem = 0;
                        var idPrimerStockReservado = 0;
                        string loteAReservar = null;
                        decimal kgSumado = 0;

                        for (var i = 0; i < consolida.Count(); i++)
                        {
                            if (i == 0)
                            {
                                idPrimerItem = consolida[i].IDITEM;
                                loteAReservar = consolida[i].BATCH;
                                if (consolida[0].idStockComprometido != null)
                                    idPrimerStockReservado = consolida[0].idStockComprometido.Value;
                            }
                            else
                            {
                                consolida[i].BATCH_REMITO = "@interno@"; //Token Auxiliar
                                new StockBatchManagerSD().ConsolidaStockReservado(
                                    consolida[0].idStockComprometido.Value, consolida[i].idStockComprometido.Value);
                                consolida[i].idStockComprometido = null;
                            }

                            kgSumado += consolida[i].KGDESPACHADOS;
                            consolida[0].KGDESPACHADOS = kgSumado;
                        }
                        var stkData = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idPrimerStockReservado);
                        stkData.ReservaID = idRemito;
                        stkData.ReservaItem = idPrimerItem;
                        db.SaveChanges();
                    }
                }
                var lineDelete = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito && c.BATCH_REMITO == "@interno@").ToList();
                db.T0056_REMITO_I.RemoveRange(lineDelete);
                db.SaveChanges();
            }
        }
        public bool SetItemPreparacion(T0056_REMITO_I itemRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (itemRemito.idStockComprometido == null || itemRemito.idStockComprometido == 0)
                {
                    return false;
                }

                var numeroRemito = Guid.Parse(itemRemito.NUMREMITO);

                var stk =
                    db.T0030_STOCK.SingleOrDefault(
                        c => c.IDStock == itemRemito.idStockComprometido.Value && c.ReservaGUID == numeroRemito);

                if (stk == null)
                    return false;
                return true;
            }
        }
        public int CantidadItemsRemito(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var it = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
                return it.Count;
            }


        }
        public void ConsolidaItemsRemitoSinAsignar(int idRemito)
        {
            var newList = new List<T0056_REMITO_I>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var _itemList =
                    db.T0056_REMITO_I.Where(
                        c =>
                            c.IDREMITO == idRemito &&
                            c.STATUSITEM == RemitoStatusManager.StatusItem.SinAsignar.ToString()).ToList();

                foreach (var item in _itemList)
                {
                    var lista =
                        _itemList.FindAll(
                            c =>
                                c.MATERIALAKA == item.MATERIALAKA && c.BATCH == item.BATCH && c.IDOV == item.IDOV &&
                                c.IDOVITEM == item.IDOVITEM && item.STATUSITEM != "@INTERNO").ToList();

                    if (lista.Count > 0)
                    {
                        decimal kg = 0;
                        for (var i = 0; i < lista.Count; i++)
                        {
                            kg += lista[i].KGDESPACHADOS;
                            lista[i].STATUSITEM = "@INTERNO";
                        }
                        lista[0].KGDESPACHADOS = kg;
                        newList.Add(lista[0]);
                    }
                }

                foreach (var item in newList)
                {
                    item.STATUSITEM = RemitoStatusManager.StatusItem.SinAsignar.ToString();
                }

                db.T0056_REMITO_I.RemoveRange(_itemList);
                db.SaveChanges();
                db.T0056_REMITO_I.AddRange(newList);
                db.SaveChanges();
            }
        }

        public RetornoKgRemito CalculaKgRemito(int idRemito)
        {
            var retorno = new RetornoKgRemito() { KgConLote = 0, KgTotales = 0 };
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var it = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
                foreach (var i in it)
                {
                    retorno.KgTotales += i.KGDESPACHADOS;
                    if (i.STATUSITEM == RemitoStatusManager.StatusItem.ReservadoOK.ToString() ||
                        i.STATUSITEM == RemitoStatusManager.StatusItem.Despachado.ToString())
                    {
                        retorno.KgConLote += i.KGDESPACHADOS;
                    }
                }
            }
            return retorno;
        }

    }
}
