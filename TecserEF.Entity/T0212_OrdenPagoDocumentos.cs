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
    
    public partial class T0212_OrdenPagoDocumentos
    {
        public int IdOP { get; set; }
        public int IdFactura { get; set; }
        public int IdCtaCte { get; set; }
        public string MonedaDoc { get; set; }
        public decimal ImporteOri { get; set; }
        public decimal ImporteOP { get; set; }
        public decimal TCDoc { get; set; }
        public decimal SaldoAdeudado { get; set; }
        public decimal ImputadoOP { get; set; }
        public string LX { get; set; }
    
        public virtual T0203_CTACTE_PROV T0203_CTACTE_PROV { get; set; }
        public virtual T0403_VENDOR_FACT_H T0403_VENDOR_FACT_H { get; set; }
        public virtual T0210_OrdenPagoHeader T0210_OrdenPagoHeader { get; set; }
    }
}
