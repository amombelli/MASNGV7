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
    
    public partial class T0320_MensajeClientes
    {
        public int idRecord { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int IdCliente { get; set; }
        public string Nota { get; set; }
        public byte[] Imagen { get; set; }
        public bool Privado { get; set; }
        public bool PopupNP { get; set; }
        public bool PopupRE { get; set; }
        public bool PopupCO { get; set; }
        public string LogUser { get; set; }
        public bool Activo { get; set; }
    }
}
