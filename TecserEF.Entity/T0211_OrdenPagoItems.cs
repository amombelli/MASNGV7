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
    
    public partial class T0211_OrdenPagoItems
    {
        public int IdOP { get; set; }
        public int IdItem { get; set; }
        public string CuentaItem { get; set; }
        public string MonedaItem { get; set; }
        public decimal ImporteItem { get; set; }
        public decimal ImporteOP { get; set; }
        public string GLCuenta { get; set; }
        public string TextoAlterno { get; set; }
        public bool EsCheque { get; set; }
        public bool ECheque { get; set; }
        public string ChNumero { get; set; }
        public Nullable<System.DateTime> ChFecha { get; set; }
        public string ChBanco { get; set; }
        public Nullable<int> ChIdCartera { get; set; }
    
        public virtual T0210_OrdenPagoHeader T0210_OrdenPagoHeader { get; set; }
    }
}
