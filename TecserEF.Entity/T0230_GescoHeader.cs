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
    
    public partial class T0230_GescoHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0230_GescoHeader()
        {
            this.T0231_GescoDetail = new HashSet<T0231_GescoDetail>();
        }
    
        public int IdCliente { get; set; }
        public Nullable<System.DateTime> UltimaLlamadaFecha { get; set; }
        public string UltimaLlamadaUser { get; set; }
        public Nullable<System.DateTime> NextCall { get; set; }
        public bool PagoConfirmado { get; set; }
        public Nullable<System.DateTime> FechaPagoConfirmado { get; set; }
        public bool PagoCanceladoModificado { get; set; }
        public string MensajePago { get; set; }
        public string MensajeInterno { get; set; }
        public bool RequestConciliation { get; set; }
        public Nullable<System.DateTime> RequestConciliationDate { get; set; }
        public bool ConcilitaionClienteOk { get; set; }
        public Nullable<System.DateTime> ConciliationClienteOkDate { get; set; }
        public bool RequestCall { get; set; }
        public string RequestCallUser { get; set; }
        public Nullable<System.DateTime> RequestCallDate { get; set; }
        public Nullable<System.DateTime> MensajeInternoDate { get; set; }
        public string MensajeInternoUser { get; set; }
        public Nullable<System.DateTime> UltimoPagoDate { get; set; }
    
        public virtual T0006_MCLIENTES T0006_MCLIENTES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0231_GescoDetail> T0231_GescoDetail { get; set; }
    }
}
