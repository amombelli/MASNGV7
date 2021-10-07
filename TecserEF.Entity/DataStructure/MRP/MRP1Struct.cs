namespace TecserEF.Entity.DataStructure.MRP
{
    public class MRP1Struct
    {
        public string MaterialMP { get; set; }
        public decimal CantRequired { get; set; }
        public int OrdenFab { get; set; }
        public string StatusOF { get; set; }
        public string MaterialFab { get; set; }
        public decimal KgFab { get; set; }
        public decimal StockDispProd { get; set; }
        public decimal StockTotal { get; set; }
        public string StockStatus { get; set; }
        public string LoteAsignado { get; set; }
        public decimal StockReservado { get; set; }
    }
    //public class CRMSalesOrderDataMng
    //{
    //    public List<CRMSalesOrder> GetData(DateTime fechaD, DateTime fechaH, string globalAppCnn,
    //        int cantidadRecords = 250, string materialAKA = null, int? idClienteRs = null)
    //    {
    //        using (var db = new TecserData(globalAppCnn))
    //        {
    //            //sin filtro de cliente
    //            if (idClienteRs == 0 || idClienteRs == null)
    //            {
    //                if (string.IsNullOrEmpty(materialAKA))
    //                {
    //                    var q = (from h in db.T0045_OV_HEADER
    //                             where (h.FECHA_OV >= fechaD && h.FECHA_OV <= fechaH)
    //                             join i in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = i.IDOV }
    //                             select new CRMSalesOrder()
    //                             {
    //                                 IdSO = h.IDOV,
    //                                 RazonSocial = h.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
    //                                 IdCliente = h.CLIENTE.Value,
    //                                 FechaSO = h.FECHA_OV.Value,
    //                                 EstadoSO = h.StatusOV,
    //                                 MaterialAKA = i.Material,
    //                                 MaterialPrimario = i.materialPrimario,
    //                                 EstadoItem = i.StatusItem,
    //                                 Moneda = i.MonedaCotiz,
    //                                 Precio1 = i.PRECIO1.Value,
    //                                 Precio2 = i.PRECIO2.Value,
    //                                 PrecioTotal = i.PRECIO1.Value + i.PRECIO2.Value,
    //                                 KgPedido = i.Cantidad,
    //                                 KgDespachado = i.KGStockDespachados.Value,
    //                                 KgRestante = i.Cantidad - i.KGStockDespachados.Value,
    //                                 LX = i.MODO,
    //                                 DescuentoP = i.DescuentoPorcentaje ?? 0
    //                             }).OrderByDescending(c => c.IdSO).Take(cantidadRecords).ToList();
    //                    return q;
    //                }
    //                else
    //                {
    //                    var q = (from h in db.T0045_OV_HEADER
    //                             where (h.FECHA_OV >= fechaD && h.FECHA_OV <= fechaH)
    //                             join i in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = i.IDOV }
    //                             where i.Material.Contains(materialAKA)
    //                             select new CRMSalesOrder()
    //                             {
    //                                 IdSO = h.IDOV,
    //                                 RazonSocial = h.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
    //                                 IdCliente = h.CLIENTE.Value,
    //                                 FechaSO = h.FECHA_OV.Value,
    //                                 EstadoSO = h.StatusOV,
    //                                 MaterialAKA = i.Material,
    //                                 MaterialPrimario = i.materialPrimario,
    //                                 EstadoItem = i.StatusItem,
    //                                 Moneda = i.MonedaCotiz,
    //                                 Precio1 = i.PRECIO1.Value,
    //                                 Precio2 = i.PRECIO2.Value,
    //                                 PrecioTotal = i.PRECIO1.Value + i.PRECIO2.Value,
    //                                 KgPedido = i.Cantidad,
    //                                 KgDespachado = i.KGStockDespachados.Value,
    //                                 KgRestante = i.Cantidad - i.KGStockDespachados.Value,
    //                                 LX = i.MODO,
    //                                 DescuentoP = i.DescuentoPorcentaje ?? 0
    //                             }).OrderByDescending(c => c.IdSO).Take(cantidadRecords).ToList();
    //                    return q;
    //                }
    //            }
    //            else
    //            {
    //                //con filtro de cliente
    //                if (string.IsNullOrEmpty(materialAKA))
    //                {
    //                    var q = (from h in db.T0045_OV_HEADER
    //                             where (h.FECHA_OV >= fechaD && h.FECHA_OV <= fechaH)
    //                             join i in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = i.IDOV }
    //                             where i.ClienteRZ == idClienteRs
    //                             select new CRMSalesOrder()
    //                             {
    //                                 IdSO = h.IDOV,
    //                                 RazonSocial = h.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
    //                                 IdCliente = h.CLIENTE.Value,
    //                                 FechaSO = h.FECHA_OV.Value,
    //                                 EstadoSO = h.StatusOV,
    //                                 MaterialAKA = i.Material,
    //                                 MaterialPrimario = i.materialPrimario,
    //                                 EstadoItem = i.StatusItem,
    //                                 Moneda = i.MonedaCotiz,
    //                                 Precio1 = i.PRECIO1.Value,
    //                                 Precio2 = i.PRECIO2.Value,
    //                                 PrecioTotal = i.PRECIO1.Value + i.PRECIO2.Value,
    //                                 KgPedido = i.Cantidad,
    //                                 KgDespachado = i.KGStockDespachados.Value,
    //                                 KgRestante = i.Cantidad - i.KGStockDespachados.Value,
    //                                 LX = i.MODO,
    //                                 DescuentoP = i.DescuentoPorcentaje ?? 0
    //                             }).OrderByDescending(c => c.IdSO).Take(cantidadRecords).ToList();
    //                    return q;
    //                }
    //                else
    //                {
    //                    var q = (from h in db.T0045_OV_HEADER
    //                             where (h.FECHA_OV >= fechaD && h.FECHA_OV <= fechaH)
    //                             join i in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = i.IDOV }
    //                             where i.Material.Contains(materialAKA) && i.ClienteRZ == idClienteRs
    //                             select new CRMSalesOrder()
    //                             {
    //                                 IdSO = h.IDOV,
    //                                 RazonSocial = h.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
    //                                 IdCliente = h.CLIENTE.Value,
    //                                 FechaSO = h.FECHA_OV.Value,
    //                                 EstadoSO = h.StatusOV,
    //                                 MaterialAKA = i.Material,
    //                                 MaterialPrimario = i.materialPrimario,
    //                                 EstadoItem = i.StatusItem,
    //                                 Moneda = i.MonedaCotiz,
    //                                 Precio1 = i.PRECIO1.Value,
    //                                 Precio2 = i.PRECIO2.Value,
    //                                 PrecioTotal = i.PRECIO1.Value + i.PRECIO2.Value,
    //                                 KgPedido = i.Cantidad,
    //                                 KgDespachado = i.KGStockDespachados.Value,
    //                                 KgRestante = i.Cantidad - i.KGStockDespachados.Value,
    //                                 LX = i.MODO,
    //                                 DescuentoP = i.DescuentoPorcentaje ?? 0
    //                             }).OrderByDescending(c => c.IdSO).Take(cantidadRecords).ToList();
    //                    return q;
    //                }
    //            }
    //        }
    //    }
    //}
}
