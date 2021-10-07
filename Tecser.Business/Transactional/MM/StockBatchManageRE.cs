using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public enum ModoBusqueda
    {
        ChicoGrande,
        GrandeChico,
        Completo
    }

    public class StockBatchManageRE
    {
        //--------------------------------------------------------------------------------
        private List<T0056_REMITO_I> _itemList = new List<T0056_REMITO_I>();


        //--------------------------------------------------------------------------------

        public List<T0056_REMITO_I> AsignaLoteAutomatico(T0056_REMITO_I itemR)
        {
            var a = new List<T0056_REMITO_I>();

            return a;
        }

        /// <summary>
        /// Toma una linea de stock y la reserva para un remito
        /// </summary>
        private void ReservaStockRemito(int idstock, Guid guidId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                stk.EstadoAnteriorReserva = stk.Estado;
                stk.Estado = StockStatusManager.EstadoLote.ReservaRE.ToString();
                stk.ReservaGUID = guidId;
                db.SaveChanges();
            }
        }
        public void LiberaStockEnReservaRE(Guid guidId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkLst = db.T0030_STOCK.Where(c => c.ReservaGUID == guidId).ToList();
                foreach (var item in stkLst)
                {
                    item.ReservaGUID = null;
                    item.Estado = item.EstadoAnteriorReserva;
                    item.EstadoAnteriorReserva = null;
                }
                db.SaveChanges();
            }
        }
        public List<T0056_REMITO_I> AsignaLoteComprometido(T0056_REMITO_I itemR)
        {
            //dado un item de Remito asigna si puede un lote comprometido - Sino deja Batch =Null
            //retorna lista por si hizo split.
            var lst = new List<T0056_REMITO_I> { itemR };

            var keepGoing = true;
            while (keepGoing)
            {
                keepGoing = false;
                //Recorre la lista de punta a punta intentando asignar un lote reservado
                //recorre actuando sobre batch en null.
                for (var i = 0; i < lst.Count; i++)
                {
                    if (String.IsNullOrEmpty(lst[i].BATCH))
                    {
                        var lstRetorno = SearchAndAssignLoteComprometido(lst[i]);
                        lst[i].KGDESPACHADOS = lstRetorno[0].KGDESPACHADOS;
                        lst[i].BATCH = lstRetorno[0].BATCH;
                        lst[i].idStockComprometido = lstRetorno[0].idStockComprometido;
                        if (lstRetorno.Count > 1)
                        {
                            keepGoing = true;
                            for (int j = 1; j < lstRetorno.Count; j++)
                            {
                                lst.Add(lstRetorno[j]);
                            }
                        }
                    }
                }
            }
            return lst;
        }
        private List<T0056_REMITO_I> SearchAndAssignLoteComprometido(T0056_REMITO_I itemR)
        {
            var lst = new List<T0056_REMITO_I> { itemR };
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string materialPrimario = MaterialMasterManager.GetPrimario(itemR.MATERIAL);

                var data =
                    db.T0030_STOCK.Where(
                        c =>
                            c.OV_Reserva == itemR.IDOV && c.Material == materialPrimario &&
                            c.Estado.ToUpper().Equals("COMPROMETIDO"))
                        .OrderByDescending(c => c.Stock).ToList();

                if (data.Any())
                {
                    decimal kgPendientes;
                    if (itemR.KGDESPACHADOS > data[0].Stock)
                    {
                        //split lista items
                        kgPendientes = itemR.KGINI - data[0].Stock;
                        lst[0].KGDESPACHADOS = data[0].Stock;
                        lst[0].KGDESPACHADOS_R = data[0].Stock;
                        lst[0].BATCH = data[0].Batch;
                        lst[0].BATCH_REMITO = data[0].Batch;
                        lst[0].idStockComprometido = data[0].IDStock;

                        new StockManager().TomaLineaStock(data[0].IDStock, data[0].Stock,
                            StockStatusManager.EstadoLote.ReservaRE, remitoGuid: itemR.NUMREMITO);

                        var tmpItem = new T0056_REMITO_I
                        {
                            KGINI = lst[0].KGINI,
                            BATCH = null,
                            BATCH_REMITO = null,
                            DESC_REMITO = lst[0].DESC_REMITO,
                            KGDESPACHADOS = kgPendientes,
                            KGDESPACHADOS_R = kgPendientes,
                            L5 = lst[0].L5,
                            NUMREMITO = lst[0].NUMREMITO,
                            GENERAR_REMITO = lst[0].GENERAR_REMITO,
                            IDITEM = 0,
                            IDOV = lst[0].IDOV,
                            IDOVITEM = lst[0].IDOVITEM,
                            MATERIAL = lst[0].MATERIAL,
                            MATERIALAKA = lst[0].MATERIALAKA,
                            LX = lst[0].LX
                        };
                        lst.Add(tmpItem);
                    }
                    else if (itemR.KGDESPACHADOS == data[0].Stock)
                    {
                        //lst[0].KGDESPACHADOS = itemR.KGINI;
                        //lst[0].KGDESPACHADOS_R = itemR.KGINI;
                        lst[0].BATCH = data[0].Batch;
                        lst[0].BATCH_REMITO = data[0].Batch;
                        lst[0].idStockComprometido = data[0].IDStock;
                        ReservaStockRemito(data[0].IDStock, new Guid(itemR.NUMREMITO));
                        kgPendientes = 0;
                    }
                    else
                    {
                        new StockManager().TomaLineaStock(data[0].IDStock, itemR.KGINI,
                            StockStatusManager.EstadoLote.ReservaRE, remitoGuid: itemR.NUMREMITO);
                        lst[0].KGDESPACHADOS = itemR.KGDESPACHADOS;
                        lst[0].KGDESPACHADOS_R = itemR.KGDESPACHADOS_R;
                        lst[0].BATCH = data[0].Batch;
                        lst[0].BATCH_REMITO = data[0].Batch;
                        lst[0].idStockComprometido = data[0].IDStock;
                        //split stock t30
                    }
                }
            }
            //tiene que devolver una lista de T0056 por si hizo split.!
            return lst;
        }
        private List<T0056_REMITO_I> SearchAndAssignLoteLiberado(T0056_REMITO_I itemR,
            ModoBusqueda modo = ModoBusqueda.ChicoGrande)
        {
            var lst = new List<T0056_REMITO_I> { itemR };
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0030_STOCK.Where(c => c.Material.ToUpper().Equals(itemR.MATERIAL.ToUpper()) &&
                                              c.Estado.ToUpper().Equals("LIBERADO") && c.T0028_SLOC.AllowDelivery)
                        .OrderByDescending(c => c.Stock)
                        .ToList();

                if (!data.Any())
                    //no encontro nada - devuelve lista con el mismo item ingresado (batch ==null)
                    return lst;

                decimal kgPendientesAsignacion = itemR.KGDESPACHADOS;

                if (itemR.KGDESPACHADOS > data[0].Stock)
                {
                    //Split lista CostItems remito y asigna toda la linea de STOCK
                    kgPendientesAsignacion = kgPendientesAsignacion - data[0].Stock;
                    lst[0].KGDESPACHADOS = data[0].Stock;
                    lst[0].KGDESPACHADOS_R = data[0].Stock;
                    lst[0].BATCH = data[0].Batch;
                    lst[0].BATCH_REMITO = data[0].Batch;
                    lst[0].idStockComprometido = data[0].IDStock;
                    lst[0].SLOC = data[0].SLOC;

                    new StockManager().TomaLineaStock(data[0].IDStock, data[0].Stock,
                        StockStatusManager.EstadoLote.ReservaRE, remitoGuid: itemR.NUMREMITO, reservadoOV: lst[0].IDOV, reservaItem: lst[0].IDOVITEM);

                    var tmpItem = new T0056_REMITO_I
                    {
                        KGINI = lst[0].KGINI,
                        BATCH = null,
                        BATCH_REMITO = null,
                        DESC_REMITO = lst[0].DESC_REMITO,
                        KGDESPACHADOS = kgPendientesAsignacion,
                        KGDESPACHADOS_R = kgPendientesAsignacion,
                        L5 = lst[0].L5,
                        NUMREMITO = lst[0].NUMREMITO,
                        GENERAR_REMITO = lst[0].GENERAR_REMITO,
                        IDITEM = 0,
                        IDOV = lst[0].IDOV,
                        IDOVITEM = lst[0].IDOVITEM,
                        MATERIAL = lst[0].MATERIAL,
                        MATERIALAKA = lst[0].MATERIALAKA,
                        LX = lst[0].LX,
                    };
                    lst.Add(tmpItem);
                }
                else
                {
                    if (itemR.KGDESPACHADOS < data[0].Stock)
                    {
                        //Split de lista de Stock T0033 y asigna la primera parte
                        new StockManager().TomaLineaStock(data[0].IDStock, itemR.KGDESPACHADOS,
                            StockStatusManager.EstadoLote.ReservaRE, remitoGuid: itemR.NUMREMITO, reservadoOV: lst[0].IDOV, reservaItem: lst[0].IDOVITEM);

                        lst[0].KGDESPACHADOS = itemR.KGDESPACHADOS;
                        lst[0].KGDESPACHADOS_R = itemR.KGDESPACHADOS_R;
                        lst[0].BATCH = data[0].Batch;
                        lst[0].BATCH_REMITO = data[0].Batch;
                        lst[0].idStockComprometido = data[0].IDStock;
                        lst[0].SLOC = data[0].SLOC;
                        kgPendientesAsignacion = 0;
                    }
                    else
                    {
                        //Asigna la linea completa - no hace nada mas
                        new StockManager().TomaLineaStock(data[0].IDStock, itemR.KGDESPACHADOS,
                            StockStatusManager.EstadoLote.ReservaRE, remitoGuid: itemR.NUMREMITO, reservadoOV: lst[0].IDOV, reservaItem: lst[0].IDOVITEM);

                        lst[0].KGDESPACHADOS = itemR.KGDESPACHADOS;
                        lst[0].KGDESPACHADOS_R = itemR.KGDESPACHADOS_R;
                        lst[0].BATCH = data[0].Batch;
                        lst[0].BATCH_REMITO = data[0].Batch;
                        lst[0].SLOC = data[0].SLOC;
                        lst[0].idStockComprometido = data[0].IDStock;
                    }
                }
            }
            //Ingrea un Item pero retorna una lista en caso que haya hecho split de stock
            return lst;
        }

        //Revision 2018.08.29
        public List<T0056_REMITO_I> ManageAsignaLoteLiberado(T0056_REMITO_I itemR,
            ModoBusqueda searchMode = ModoBusqueda.GrandeChico)
        {
            //Ingresa un Item Remito.---> Lo asigna a una Lista.
            var modoBusqueda = searchMode;
            var kgPendientesAsignacion = itemR.KGDESPACHADOS;
            var lst = new List<T0056_REMITO_I> { itemR };

#pragma warning disable CS0219 // The variable 'keepGoing' is assigned but its value is never used
            var keepGoing = true;
#pragma warning restore CS0219 // The variable 'keepGoing' is assigned but its value is never used

            if (kgPendientesAsignacion == 0)
            {
                return _itemList;
            }
            var listaRetorno = SearchAndAssignLoteLiberado(itemR, modoBusqueda);
            if (listaRetorno.Count == 1)
            {
                _itemList.Add(listaRetorno[0]);
                return _itemList;
            }

            for (var i = 0; i < listaRetorno.Count; i++)
            {
                if (listaRetorno[i].BATCH != null)
                {
                    _itemList.Add(listaRetorno[i]);
                }
                else
                {
                    ManageAsignaLoteLiberado(listaRetorno[i], modoBusqueda);
                }
            }
            return _itemList;
        }

        public List<T0030_STOCK> OptimizaLineasStockRemitoDb(Guid guidId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var itemList0 = db.T0030_STOCK.Where(c => c.ReservaGUID == guidId).ToList();
                foreach (var item in itemList0)
                {
                    var lista =
                        itemList0.FindAll(
                            c =>
                                c.Material == item.Material && c.Batch == item.Batch && c.SLOC == item.SLOC &&
                                c.OV_Reserva == item.OV_Reserva && c.ReservaItem == item.ReservaItem &&
                                c.Documento != "TMP").ToList();

                    if (lista.Count > 0)
                    {
                        decimal kg = 0;
                        for (int i = 0; i < lista.Count; i++)
                        {
                            kg += lista[i].Stock;
                            lista[i].Documento = "TMP";
                            if (i > 0)
                            {
                                db.T0030_STOCK.Remove(lista[i]);
                            }
                        }
                        lista[0].Stock = kg;
                        lista[0].Documento = null;
                        db.SaveChanges();
                    }
                }
                var stk = db.T0030_STOCK.Where(c => c.ReservaGUID == guidId && c.ReservaItem == 0).ToList();
                foreach (var ix in stk)
                {
                    ix.ReservaItem = null;
                }
                db.SaveChanges();

                return db.T0030_STOCK.Where(c => c.ReservaGUID == guidId).ToList();
            }
        }


    }
}





