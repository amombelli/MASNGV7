using System;
using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure.SD_CRM
{
    public class CRMSalesOrder
    {
        public int IdSO { get; set; }
        public string RazonSocial { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaSO { get; set; }
        public string EstadoSO { get; set; }
        public string MaterialAKA { get; set; }
        public string MaterialPrimario { get; set; }
        public string EstadoItem { get; set; }
        public string Moneda { get; set; }
        public decimal Precio1 { get; set; }
        public decimal Precio2 { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal KgPedido { get; set; }
        public decimal KgDespachado { get; set; }
        public decimal KgRestante { get; set; }
        public string LX { get; set; }
        public decimal DescuentoP { get; set; }
    }
    public class CRMSalesOrderDataMng
    {
        public List<CRMSalesOrder> GetData(DateTime fechaD, DateTime fechaH, string globalAppCnn,
            int cantidadRecords = 250, string materialAKA = null, int? idClienteRs = null)
        {
            using (var db = new TecserData(globalAppCnn))
            {
                //sin filtro de cliente
                if (idClienteRs == 0 || idClienteRs == null)
                {
                    if (string.IsNullOrEmpty(materialAKA))
                    {
                        var q = (from h in db.T0045_OV_HEADER
                                 where (h.FECHA_OV >= fechaD && h.FECHA_OV <= fechaH)
                                 join i in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = i.IDOV }
                                 select new CRMSalesOrder()
                                 {
                                     IdSO = h.IDOV,
                                     RazonSocial = h.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                     IdCliente = h.CLIENTE.Value,
                                     FechaSO = h.FECHA_OV.Value,
                                     EstadoSO = h.StatusOV,
                                     MaterialAKA = i.Material,
                                     MaterialPrimario = i.materialPrimario,
                                     EstadoItem = i.StatusItem,
                                     Moneda = i.MonedaCotiz,
                                     Precio1 = i.PRECIO1,
                                     Precio2 = i.PRECIO2,
                                     PrecioTotal = i.PRECIO1 + i.PRECIO2,
                                     KgPedido = i.Cantidad,
                                     KgDespachado = i.KGStockDespachados,
                                     KgRestante = i.Cantidad - i.KGStockDespachados,
                                     LX = i.MODO,
                                     DescuentoP = i.DescuentoPorcentaje ?? 0
                                 }).OrderByDescending(c => c.IdSO).Take(cantidadRecords).ToList();
                        return q;
                    }
                    else
                    {
                        var q = (from h in db.T0045_OV_HEADER
                                 where (h.FECHA_OV >= fechaD && h.FECHA_OV <= fechaH)
                                 join i in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = i.IDOV }
                                 where i.Material.Contains(materialAKA)
                                 select new CRMSalesOrder()
                                 {
                                     IdSO = h.IDOV,
                                     RazonSocial = h.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                     IdCliente = h.CLIENTE.Value,
                                     FechaSO = h.FECHA_OV.Value,
                                     EstadoSO = h.StatusOV,
                                     MaterialAKA = i.Material,
                                     MaterialPrimario = i.materialPrimario,
                                     EstadoItem = i.StatusItem,
                                     Moneda = i.MonedaCotiz,
                                     Precio1 = i.PRECIO1,
                                     Precio2 = i.PRECIO2,
                                     PrecioTotal = i.PRECIO1 + i.PRECIO2,
                                     KgPedido = i.Cantidad,
                                     KgDespachado = i.KGStockDespachados,
                                     KgRestante = i.Cantidad - i.KGStockDespachados,
                                     LX = i.MODO,
                                     DescuentoP = i.DescuentoPorcentaje ?? 0
                                 }).OrderByDescending(c => c.IdSO).Take(cantidadRecords).ToList();
                        return q;
                    }
                }
                else
                {
                    //con filtro de cliente
                    if (string.IsNullOrEmpty(materialAKA))
                    {
                        var q = (from h in db.T0045_OV_HEADER
                                 where (h.FECHA_OV >= fechaD && h.FECHA_OV <= fechaH)
                                 join i in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = i.IDOV }
                                 where i.ClienteRZ == idClienteRs
                                 select new CRMSalesOrder()
                                 {
                                     IdSO = h.IDOV,
                                     RazonSocial = h.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                     IdCliente = h.CLIENTE.Value,
                                     FechaSO = h.FECHA_OV.Value,
                                     EstadoSO = h.StatusOV,
                                     MaterialAKA = i.Material,
                                     MaterialPrimario = i.materialPrimario,
                                     EstadoItem = i.StatusItem,
                                     Moneda = i.MonedaCotiz,
                                     Precio1 = i.PRECIO1,
                                     Precio2 = i.PRECIO2,
                                     PrecioTotal = i.PRECIO1 + i.PRECIO2,
                                     KgPedido = i.Cantidad,
                                     KgDespachado = i.KGStockDespachados,
                                     KgRestante = i.Cantidad - i.KGStockDespachados,
                                     LX = i.MODO,
                                     DescuentoP = i.DescuentoPorcentaje ?? 0
                                 }).OrderByDescending(c => c.IdSO).Take(cantidadRecords).ToList();
                        return q;
                    }
                    else
                    {
                        var q = (from h in db.T0045_OV_HEADER
                                 where (h.FECHA_OV >= fechaD && h.FECHA_OV <= fechaH)
                                 join i in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = i.IDOV }
                                 where i.Material.Contains(materialAKA) && i.ClienteRZ == idClienteRs
                                 select new CRMSalesOrder()
                                 {
                                     IdSO = h.IDOV,
                                     RazonSocial = h.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                     IdCliente = h.CLIENTE.Value,
                                     FechaSO = h.FECHA_OV.Value,
                                     EstadoSO = h.StatusOV,
                                     MaterialAKA = i.Material,
                                     MaterialPrimario = i.materialPrimario,
                                     EstadoItem = i.StatusItem,
                                     Moneda = i.MonedaCotiz,
                                     Precio1 = i.PRECIO1,
                                     Precio2 = i.PRECIO2,
                                     PrecioTotal = i.PRECIO1 + i.PRECIO2,
                                     KgPedido = i.Cantidad,
                                     KgDespachado = i.KGStockDespachados,
                                     KgRestante = i.Cantidad - i.KGStockDespachados,
                                     LX = i.MODO,
                                     DescuentoP = i.DescuentoPorcentaje ?? 0
                                 }).OrderByDescending(c => c.IdSO).Take(cantidadRecords).ToList();
                        return q;
                    }
                }
            }
        }
    }
}
