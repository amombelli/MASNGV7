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
    
    public partial class T0525_SueldoAdelanto
    {
        public int idAdelanto { get; set; }
        public System.DateTime FechaSolicitud { get; set; }
        public string Shortname { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal MontoAbonado { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public string Comentario { get; set; }
        public Nullable<int> SYJHeaderId { get; set; }
        public Nullable<int> SYJItemId { get; set; }
        public string AcuerdoDePago { get; set; }
        public decimal MontoAdeudado { get; set; }
    }
}
