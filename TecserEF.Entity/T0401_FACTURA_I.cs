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
    
    public partial class T0401_FACTURA_I
    {
        public int IDFactura { get; set; }
        public int IDITEM { get; set; }
        public string NUMFACTURA { get; set; }
        public string ITEM { get; set; }
        public string DESC_REMITO { get; set; }
        public Nullable<decimal> KGDESPACHADOS_R { get; set; }
        public string MONEDA_FACT { get; set; }
        public decimal TC { get; set; }
        public bool IVA21 { get; set; }
        public Nullable<int> NAS { get; set; }
        public Nullable<int> NASSEG { get; set; }
        public Nullable<int> IDFACTURAX { get; set; }
        public string MONEDA_COTIZ { get; set; }
        public decimal PRECIOU_COTIZ { get; set; }
        public decimal PRECIOT_COTIZ { get; set; }
        public decimal PRECIOU_FACT_ARS { get; set; }
        public decimal PRECIOT_FACT_ARS { get; set; }
        public decimal PRECIOU_FACT_USD { get; set; }
        public decimal PRECIOT_FACT_USD { get; set; }
        public string GLV { get; set; }
        public string GLI { get; set; }
        public Nullable<int> FsrOV { get; set; }
        public Nullable<int> FsrOVItem { get; set; }
        public decimal CostoStd { get; set; }
    
        public virtual T0400_FACTURA_H T0400_FACTURA_H { get; set; }
    }
}
