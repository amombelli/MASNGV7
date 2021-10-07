using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class ManageGeneracionRemitoFinal
    {
        public ManageGeneracionRemitoFinal(int idRemito)
        {
            _idRemito = idRemito;
        }
        private readonly int _idRemito;
        public bool CheckIfIsOkToGenerate()
        {
            //hacer todas las validaciones aca
            var flag = true;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == _idRemito);
                if (header.StatusRemito.ToUpper() != RemitoStatusManager.StatusHeader.Preparado.ToString().ToUpper())
                {
                    return false;
                }
                var items = db.T0056_REMITO_I.Where(c => c.IDREMITO == _idRemito).ToList();
                foreach (var ir in items)
                {
                    //1.Completa GL Venta + Descripcion Item de acuerdo al tipo de Remito + Orden Venta + Precio/Moneda
                    if (!CompleteItemData(_idRemito, ir.IDITEM))
                        flag = false;
                }
            }
            return flag;
        }
        public bool AllItemsAreCheckedToGenerate()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataRemitoItemList = db.T0056_REMITO_I.Where(c => c.IDREMITO == _idRemito && c.GENERAR_REMITO == false).ToList();
                return dataRemitoItemList.Count <= 0;
            }
        }

        /// <summary>
        /// Esta funcion hay que usarla primero validando si es OK para generar
        /// </summary>
        public bool Generacion()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataRemitoHeader = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == _idRemito);
                var dataRemitoItemList = db.T0056_REMITO_I.Where(c => c.IDREMITO == _idRemito && c.GENERAR_REMITO == true).ToList();
                var cantidadItemsToRemove = RemoveItemsNotChecked();
                var remitoLx = dataRemitoHeader.TIPO_REMITO; //L1 o L2
                var resultadoRemove = true;

                foreach (var item in dataRemitoItemList)
                {
                    var itemSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == item.IDOV.Value && c.IDITEM == item.IDOVITEM);
                    var tipoItemSO = itemSO.MODO; //Modo > L1,L2 o L5

                    if (tipoItemSO == "L5" && remitoLx == "L2")
                    {
                        //Parte 2 de un remito L5 - Se completa automaticamente con los KG_R al imprimir el remito
                        item.STATUSITEM = RemitoStatusManager.StatusItem.Confirmado.ToString();
                    }
                    else
                    {
                        resultadoRemove = new RemitoStockManager().RemoveStockLineRemito(item.IDREMITO, item.IDITEM); //remueve + log
                        if (resultadoRemove == false)
                        {
                            item.STATUSITEM = RemitoStatusManager.StatusItem.ErrorStock.ToString();
                            MessageBox.Show(
                                $@"Atencion ha ocurrido un error IDREMITO= {item.IDREMITO} - Item: {item.IDITEM} - Anote estos numeros y NOTIFIQUE con URGENCIA a Andres!",
                                @"Error en Remocion de Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            item.STATUSITEM = RemitoStatusManager.StatusItem.Despachado.ToString();
                            new SalesOrderDeliveryManager().UpdateDeliveryQty(item.IDOV.Value, item.IDOVITEM.Value, item.KGDESPACHADOS);
                            SalesOrderStatusManager.UpdateStatusItem(item.IDOV.Value, item.IDOVITEM.Value);
                            SalesOrderStatusManager.UpdateStatusHeaderFromStatusItem(item.IDOV.Value);
                        }
                    }
                }

                dataRemitoHeader.StatusRemito = resultadoRemove ? RemitoStatusManager.StatusHeader.Generado.ToString() : RemitoStatusManager.StatusHeader.Error.ToString();
                db.SaveChanges();
                return resultadoRemove;
            }
        }
        private bool CompleteItemData(int idRemito, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item = db.T0056_REMITO_I.SingleOrDefault(c => c.IDREMITO == idRemito && c.IDITEM == idItem);
                if (item == null)
                    return false;

                string tipoRemito = item.T0055_REMITO_H.TIPO_REMITO;
                //new SalesOrderDeliveryManager().FixPriceFromOldModel(item.IDOV.Value, item.IDOVITEM.Value); //
                var itemSO =
                    db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == item.IDOV.Value && c.IDITEM == item.IDOVITEM);

                string tipoItemSO = itemSO.MODO;
                item.GLV = GLAccountManagement.GetGLVentaMaterialMaster(item.MATERIALAKA);
                item.GL = GLAccountManagement.GetGLInventarioMaterialMaster(item.MATERIALAKA);
                item.DESC_REMITO = new MaterialMasterManager().GetDescripcionItemVenta(item.MATERIAL, tipoRemito,
                    tipoItemSO).Truncate(50);

                item.BATCH_REMITO = item.BATCH;
                item.KGDESPACHADOS_R = item.KGDESPACHADOS;
                item.VISIBLE_RE = true;
                item.VISIBLE_FA = true;
                item.MONEDA = itemSO.MonedaCotiz;

                var tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                item.TC_FACTU = tc;
                if (tipoRemito == "L1")
                {
                    item.PRECIOU = itemSO.PRECIO1;
                    item.PRECIOT = itemSO.PRECIO1 * item.KGDESPACHADOS;
                    item.IVA21 = true;
                }
                else
                {
                    item.IVA21 = false;
                    item.PRECIOU = itemSO.PRECIO2;
                    item.PRECIOT = itemSO.PRECIO2 * item.KGDESPACHADOS;
                }

                if (item.MONEDA == "ARS")
                {
                    item.PRECIOU_ARS = item.PRECIOU;
                    item.PRECIOT_ARS = item.PRECIOT;
                    item.PRECIOU_USD = item.PRECIOU / tc;
                    item.PRECIOT_USD = item.PRECIOT / tc;
                }
                else
                {
                    item.PRECIOU_ARS = item.PRECIOU * tc;
                    item.PRECIOT_ARS = item.PRECIOT * tc;
                    item.PRECIOU_USD = item.PRECIOU;
                    item.PRECIOT_USD = item.PRECIOT;
                }
                db.SaveChanges();
                return true;
            }
        }
        private int RemoveItemsNotChecked()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataRemitoItemList = db.T0056_REMITO_I.Where(c => c.IDREMITO == _idRemito && c.GENERAR_REMITO == false).ToList();
                var itemsToRemove = dataRemitoItemList.Count;

                if (itemsToRemove > 0)
                {
                    db.T0056_REMITO_I.RemoveRange(dataRemitoItemList);
                    db.SaveChanges();
                }
                return itemsToRemove;
            }
        }
    }
}