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
    
    public partial class T0605_DOCUCONFIG
    {
        public string IDDOC { get; set; }
        public string SHORTNAME { get; set; }
        public string DESCRIPTION { get; set; }
        public bool L1 { get; set; }
        public bool L2 { get; set; }
        public string DOCUMENTACION { get; set; }
        public string CODIGOAFIP { get; set; }
        public Nullable<int> SIGNCONTABILIZACION { get; set; }
        public string DescripcionDocumento { get; set; }
        public string DESCRIPCION_ENUM { get; set; }
        public Nullable<bool> ModuloVendor { get; set; }
        public Nullable<bool> ModuloCustomer { get; set; }
        public string TdocSystem { get; set; }
    
        public virtual T0606_DOCUCONTACLI T0606_DOCUCONTACLI { get; set; }
    }
}
