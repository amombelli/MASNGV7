//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TecserEF.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class T0141_MargenVenta
    {
        public int IdFactura { get; set; }
        public int IdItemFactura { get; set; }
        public int IdCliente { get; set; }
        public string ClienteRs { get; set; }
        public System.DateTime FechaRemito { get; set; }
        public int IdRemito { get; set; }
        public decimal TC { get; set; }
        public string MonedaCosto { get; set; }
        public decimal CostoMfg { get; set; }
        public decimal CostoEstadistico { get; set; }
        public decimal CostoOperacionGlobal { get; set; }
        public decimal PrecioU1 { get; set; }
        public decimal PrecioU2 { get; set; }
        public decimal PrecioUTotal { get; set; }
        public string Material { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioTotalFactu { get; set; }
        public decimal MargenTotalVenta { get; set; }
        public decimal PorcentajeCob { get; set; }
        public decimal TCppp { get; set; }
        public int DiasCobro { get; set; }
        public decimal CostoAdicionalCobro { get; set; }
        public decimal MargenOperacionCobro { get; set; }
    }
}
