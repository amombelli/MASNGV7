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
    
    public partial class T0049_FSR
    {
        public int IDFactura { get; set; }
        public int IDFacturaItem { get; set; }
        public int IDOV { get; set; }
        public int IDOVItem { get; set; }
        public string Material { get; set; }
        public decimal KGFacturado { get; set; }
        public string Moneda { get; set; }
        public decimal Precio { get; set; }
        public System.DateTime LogDate { get; set; }
        public string LogUser { get; set; }
    }
}
