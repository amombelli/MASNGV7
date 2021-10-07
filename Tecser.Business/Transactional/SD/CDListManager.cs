using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.SD
{
    /// <summary>
    /// Estructura de Resumen de Stock
    /// </summary>
    public class ResumenStock
    {
        public string Material { get; set; }
        public decimal Stock { get; set; }
        public decimal PendienteEntregaTecser { get; set; }
    }
    public class StockDisponibleManager
    {
        private readonly string _planta;
        public StockDisponibleManager(string planta = "CERR")
        {
            _planta = planta;
        }

        private List<ResumenStock> ListaStockDisponible = new List<ResumenStock>();
        /// <summary>
        /// Actualiza la lista 'ListatockDisponible' con el stock disponible y el pendiente de entrega
        /// si el kgPedido ==0 no actualiza los KG pedidos sino que solo devuelve el valor 
        /// </summary>
        public ResumenStock GetValue(string material, decimal kgPedido = 0)
        {
            var stockEncontrado = ListaStockDisponible.Find(c => c.Material == material);
            if (stockEncontrado == null)
            {
                var xitem = new ResumenStock
                {
                    Material = material,
                    Stock = StockList.GetKgStockTotalByMaterial(material, _planta),
                    PendienteEntregaTecser = kgPedido,
                };
                ListaStockDisponible.Add(xitem);
                return xitem;
            }
            else
            {
                if (kgPedido > 0)
                {
                    stockEncontrado.PendienteEntregaTecser += kgPedido;
                }
                return stockEncontrado;
            }
        }
    }

    public class CDListManager
    {
        private List<CDStructure> _cd = new List<CDStructure>();
        //Parcial
        //Cancelado
        //INICIAL
        //Despachado
        //NULL
        //CERRADO_M
        //Pendiente



        /// <summary>
        /// 20201907 - Permite traer a todos los clientes ingresando id6=null
        /// </summary>
        /// <returns></returns>
        public List<CDStructure> GetListPendientesDespachoCliente(int? id6, bool withStock = true)
        {
            var listaResultado = new List<CDStructure>();
            var y = new List<T0046_OV_ITEM>();
            var MngrStock = new StockDisponibleManager("CERR");
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (id6 == null)
                {
                    y =
                        db.T0046_OV_ITEM.Where(
                            c => (c.StatusItem.ToUpper().Equals(SalesOrderStatusManager.StatusItem.Inicial.ToString().ToUpper()) ||
                                c.StatusItem.ToUpper().Equals(SalesOrderStatusManager.StatusItem.Parcial.ToString().ToUpper()) ||
                                c.StatusItem.ToUpper().Equals(SalesOrderStatusManager.StatusItem.Pendiente.ToString().ToUpper())))
                            .ToList();
                }
                else
                {
                    y =
                        db.T0046_OV_ITEM.Where(
                            c => c.T0045_OV_HEADER.T0007_CLI_ENTREGA.IDCLIENTE == id6 && (
                                c.StatusItem.ToUpper().Equals(SalesOrderStatusManager.StatusItem.Inicial.ToString().ToUpper()) ||
                                c.StatusItem.ToUpper().Equals(SalesOrderStatusManager.StatusItem.Parcial.ToString().ToUpper()) ||
                                c.StatusItem.ToUpper().Equals(SalesOrderStatusManager.StatusItem.Pendiente.ToString().ToUpper())))
                            .ToList();
                }

                foreach (var ix in y)
                {
                    var item = new CDStructure
                    {
                        Aka = ix.Material,
                        Primario = ix.materialPrimario,
                        FechaOV = ix.T0045_OV_HEADER.FECHA_OV,
                        FechaCompromiso = ix.FechaCompromiso,
                        FantasiaC7 = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.ClienteEntregaDesc,
                        RazonSocialC7 = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                        IdC6 = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.IDCLIENTE,
                        IdC7 = ix.T0045_OV_HEADER.CLIENTE.Value,
                        IdOv = ix.T0045_OV_HEADER.IDOV,
                        StatusOv = ix.T0045_OV_HEADER.StatusOV,
                        StatusItem = ix.StatusItem,
                        KgPedidos = ix.Cantidad,
                        KgDespachados = ix.KGStockDespachados,
                        KgPendientes = (ix.Cantidad - (decimal)ix.KGStockDespachados),
                        KgComprometidos = ix.KGStockComprometido,
                        KgStockTotal = MngrStock.GetValue(ix.materialPrimario, ix.Cantidad - (decimal)ix.KGStockDespachados).Stock,
                        DireccionEntrega = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.Direccion_Entrega,
                        LocalidadEntrega = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.DireEntre_Localidad,
                        ZonaEntrega = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.DireEntre_Zona,
                        LX = ix.MODO,
                        IdItem = ix.IDITEM,
                        BoolCompromiso = ix.FlagStockComprometido,
                        StatusStock = "N/A",
                        StatusPedido = "N/A",
                        KgPedidosPendientes = (decimal)99999.99,
                        ObservacionItem = ix.ObservacionItem
                    };
                    listaResultado.Add(item);
                }


                //Chequea por Pedido si está all complete o Parcial
                var listaOVDistinct = listaResultado.Select(c => c.IdOv).Distinct().ToList();
                foreach (var ovUnica in listaOVDistinct)
                {
                    bool indicadorPedidoCompleto = true;
                    bool indicadorPedidoCompletoOK = true;
                    var itemsCadaOV = listaResultado.Where(c => c.IdOv == ovUnica).ToList();
                    foreach (var itemOv in itemsCadaOV)
                    {
                        var resp = MngrStock.GetValue(itemOv.Primario);
                        if (itemOv.KgPendientes > resp.Stock)
                        {
                            indicadorPedidoCompleto = false;
                        }
                        itemOv.KgPedidosPendientes = resp.PendienteEntregaTecser; //Se muestra el total pendiente de entrega TS por linea

                        if (itemOv.KgStockTotal == 0)
                        {
                            itemOv.StatusStock = "0"; //No Stock
                        }
                        else
                        {
                            //hay algo de stock
                            if (itemOv.KgPendientes > itemOv.KgStockTotal)
                            {
                                itemOv.StatusStock = "1"; //Stock Parcial
                            }
                            else
                            {
                                //hay stock para entregar esta linea al menos
                                if (itemOv.KgPedidosPendientes > itemOv.KgStockTotal)
                                {
                                    itemOv.StatusStock = "2"; //Stock OK pero no para todos
                                    indicadorPedidoCompletoOK = false;
                                }
                                else
                                {
                                    itemOv.StatusStock = "3"; //Stock OK para todos
                                }
                            }
                        }
                    }

                    //Recorrido final por cada item de cada OV-Distinct
                    //StatusStock:  0 = "No Stock" , 1: Parcial , 2 
                    foreach (var itemOv in itemsCadaOV)
                    {
                        if (indicadorPedidoCompleto == true)
                        {
                            if (indicadorPedidoCompletoOK)
                            {
                                itemOv.StatusPedido = "CompletoOK";
                            }
                            else
                            {
                                itemOv.StatusPedido = "CompletoP";
                            }
                        }
                        else
                        {
                            itemOv.StatusPedido = "Incompleto";
                            //if (itemOv.StatusStock == "0")
                            //{
                            //    itemOv.StatusPedido = "Nulo";
                            //}
                            //else
                            //{
                            //    itemOv.StatusPedido = "Incompleto";
                            //}
                        }
                    }
                }
            }
            return listaResultado.OrderBy(c => c.RazonSocialC7).ThenBy(c => c.IdOv).ToList();
        }
    }
}
