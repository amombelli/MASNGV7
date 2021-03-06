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
    
    public partial class T0030_STOCK
    {
        public int IDStock { get; set; }
        public string Material { get; set; }
        public string Batch { get; set; }
        public decimal Stock { get; set; }
        public string Estado { get; set; }
        public string Documento { get; set; }
        public Nullable<int> OV_Reserva { get; set; }
        public Nullable<System.DateTime> UltimoMovimiento { get; set; }
        public Nullable<int> Despacho { get; set; }
        public string SLOC { get; set; }
        public string PLTN { get; set; }
        public Nullable<int> ReservaOF { get; set; }
        public Nullable<int> ReservaID { get; set; }
        public Nullable<int> ReservaItem { get; set; }
        public Nullable<System.Guid> ReservaGUID { get; set; }
        public string EstadoAnteriorReserva { get; set; }
    
        public virtual T0010_MATERIALES T0010_MATERIALES { get; set; }
        public virtual T0028_SLOC T0028_SLOC { get; set; }
        public virtual T0029_ESTADO_STOCK T0029_ESTADO_STOCK { get; set; }
    }
}
