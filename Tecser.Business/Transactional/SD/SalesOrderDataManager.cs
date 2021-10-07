using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using Tecser.Business.Transactional.WM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class SalesOrderDataManager
    {
        public int InicializaSalesOrderDb(int idClienteT7, string status)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = new T0045_OV_HEADER
                {
                    CLIENTE = idClienteT7,
                    StatusOV = status,
                    LOG_FECHA = DateTime.Now,
                    LOG_USER = GlobalApp.AppUsername,
                    IDOV = db.T0045_OV_HEADER.Max(c => c.IDOV) + 1,
                };
                db.T0045_OV_HEADER.Add(data);
                if (db.SaveChanges() > 0)
                    return data.IDOV;
                return 0;
            }
        }
        public bool AgregaItemSalesOrder(T0046_OV_ITEM item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                item.CK = false;
                item.CKUPD = false;
                db.T0046_OV_ITEM.Add(item);
                return db.SaveChanges() > 0;
            }
        }
        public int EmiteSalesOrder(int idSO, DateTime fechaSalesOrder, string comentarioSalesOrder, string vendedor,
            string numeroOC, string metodoIngreso)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSO);
                if (h == null)
                    return -1;

                int itemsEmitidos = EmiteItems(idSO);
                if (itemsEmitidos > 0)
                {
                    var statusHeader = SalesOrderStatusManager.MapStatusHeaderFromText(h.StatusOV);
                    if (statusHeader == SalesOrderStatusManager.StatusHeader.Inicial)
                    {
                        h.FECHA_OV = fechaSalesOrder;
                        h.ObservacionesOV = comentarioSalesOrder;
                        h.Vendedor = vendedor;
                        h.NumeroOC = numeroOC;
                        h.MetodoIngreso = metodoIngreso;
                        h.StatusOV = SalesOrderStatusManager.StatusHeader.Emitida.ToString();
                    }
                    else
                    {
                        h.LogChDate = DateTime.Now;
                        h.LogChUser = GlobalApp.AppUsername;
                    }

                    db.SaveChanges();
                    return itemsEmitidos;
                }

                return 0;
            }
        }

        /// <summary>
        /// Emision de Items de Sales Order - Solo para Items con estado Inicial
        /// Setea el Item a 'Pendiente' y si corresponde activa el MRP --> PF
        /// </summary>
        private int EmiteItems(int idSO)
        {
            const string planta = "CERR";
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int i = 0;
                var items = db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).ToList();
                foreach (var item in items)
                {
                    if (item.StatusItem == SalesOrderStatusManager.StatusItem.Inicial.ToString())
                    {
                        i++;
                        item.StatusItem = SalesOrderStatusManager.StatusItem.Pendiente.ToString();
                        var kgFabricar = item.Cantidad - item.KGStockComprometido;
                        var urgente = item.PRIORIDAD == "URGENTE";
                        if (item.FechaCompromiso == null)
                            item.FechaCompromiso = DateTime.Today.AddDays(3);

                        if (kgFabricar > 0)
                        {
                            //activa MRP
                            var mrpResult = new MrpManager().AddMrpAuto(item.Material, kgFabricar,
                                item.FechaCompromiso.Value, item.ObservacionItem, planta, item.IDOV, urgente, false);
                            item.MRPAuto = mrpResult;
                        }
                    }
                    else
                    {
                        //aca no tengo nada para hacer po el momento porque solo activo
                        //con el item en INCIAL.
                    }
                }

                db.SaveChanges();
                return i;
            }
        }
        public List<T0046_OV_ITEM> GetDataItemsFromDb(int idSo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0046_OV_ITEM.Where(c => c.IDOV == idSo).ToList();
            }
        }
        public T0045_OV_HEADER GetDataHeaderFromDb(int idSo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSo);
            }
        }
        public T0046_OV_ITEM GetDataItemFromDb(int idSo, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSo && c.IDITEM == idItem);
            }
        }
        public bool UpdateItemData(T0046_OV_ITEM item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == item.IDOV && c.IDITEM == item.IDITEM);
                if (data == null)
                    return false;

                data.Cantidad = item.Cantidad;
                data.FechaCompromiso = item.FechaCompromiso;
                data.ObservacionItem = item.ObservacionItem;
                data.PRIORIDAD = item.PRIORIDAD;
                data.MODO = item.MODO;
                data.Material_Cli = item.Material_Cli;
                data.MonedaCotiz = item.MonedaCotiz;
                data.PRECIO1 = item.PRECIO1;
                data.PRECIO2 = item.PRECIO2;
                data.PrecioUnitario = item.PrecioUnitario;
                data.CK = false;
                data.CKUPD = true;
                return db.SaveChanges() > 0;
            }
        }
        public int GetNumberItemsNoEmitidos(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var it = db.T0046_OV_ITEM.Where(c =>
                    c.IDOV == idSO && c.StatusItem == SalesOrderStatusManager.StatusItem.Inicial.ToString()).ToList();
                return it.Count();
            }
        }
        public void RemoveSOTemporal(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var Header = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSO);
                if (Header == null)
                    return;
                db.T0045_OV_HEADER.Remove(Header);
                db.SaveChanges();
            }
        }
        public void RemoveItemsPendientes(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0046_OV_ITEM.Where(c =>
                    c.IDOV == idSO && c.StatusItem == SalesOrderStatusManager.StatusItem.Inicial.ToString()).ToList();

                foreach (var i in items)
                {
                    var stk = db.T0030_STOCK.Where(c =>
                        c.OV_Reserva == idSO && c.ReservaItem == i.IDITEM &&
                        c.Estado == StockStatusManager.EstadoLote.Comprometido.ToString()).ToList();
                    new CompromisoManager().FreeItemComprometidoByItemId(i.IDOV, i.IDITEM);
                    db.T0046_OV_ITEM.Remove(i);
                    db.SaveChanges();
                }
            }
        }
        public int GetNextItem(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var it = db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).ToList();
                if (it.Count == 0)
                    return 1;
                return db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).Max(c => c.IDITEM) + 1;
            }
        }

        public string GetCustomerFantasiaFromOrdenVenta(int ordenVenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == ordenVenta)
                        .T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_fantasia;
            }
        }
    }
}

