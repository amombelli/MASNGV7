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
    
    public partial class T0210_OrdenPagoHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0210_OrdenPagoHeader()
        {
            this.T0211_OrdenPagoItems = new HashSet<T0211_OrdenPagoItems>();
            this.T0212_OrdenPagoDocumentos = new HashSet<T0212_OrdenPagoDocumentos>();
            this.T0213_OrdenPagoRetenciones = new HashSet<T0213_OrdenPagoRetenciones>();
        }
    
        public int IdOP { get; set; }
        public System.DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }
        public string Moneda { get; set; }
        public bool Temp { get; set; }
        public string Status { get; set; }
        public string Lx { get; set; }
        public string Observacion { get; set; }
        public string LogUser { get; set; }
        public System.DateTime LogDate { get; set; }
        public bool Finalizado { get; set; }
        public int IdCtaCte { get; set; }
        public Nullable<int> Nas { get; set; }
        public Nullable<int> DiasPPFactura { get; set; }
        public Nullable<int> DiasPPItemsPago { get; set; }
        public decimal TC { get; set; }
        public string Periodo { get; set; }
        public string LogPreparo { get; set; }
        public string LogGenero { get; set; }
        public bool AplicaCredito { get; set; }
        public decimal ImporteOP { get; set; }
        public decimal ImporteCheques { get; set; }
        public decimal ImporteEfectivo { get; set; }
        public decimal ImporteOtros { get; set; }
        public decimal ImporteCreditosAplicados { get; set; }
        public decimal ImporteFacturas { get; set; }
        public decimal SaldoSinAplicarOP { get; set; }
        public string TipoOPDoc { get; set; }
        public decimal ImporteRetencionens { get; set; }
    
        public virtual T0005_MPROVEEDORES T0005_MPROVEEDORES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0211_OrdenPagoItems> T0211_OrdenPagoItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0212_OrdenPagoDocumentos> T0212_OrdenPagoDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0213_OrdenPagoRetenciones> T0213_OrdenPagoRetenciones { get; set; }
    }
}
