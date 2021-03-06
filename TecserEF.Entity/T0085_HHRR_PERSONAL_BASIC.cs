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
    
    public partial class T0085_HHRR_PERSONAL_BASIC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0085_HHRR_PERSONAL_BASIC()
        {
            this.T0551_HHRR_SYJ_Items = new HashSet<T0551_HHRR_SYJ_Items>();
            this.T0552_HHRR_SYJ_Payments = new HashSet<T0552_HHRR_SYJ_Payments>();
            this.T0092_HHRR_COMBOASSIGN = new HashSet<T0092_HHRR_COMBOASSIGN>();
        }
    
        public string Shortname { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string LegajoRaf { get; set; }
        public Nullable<int> GLSubfix { get; set; }
        public bool Activo { get; set; }
        public Nullable<decimal> Documento { get; set; }
        public string CUIL { get; set; }
        public bool BitQuincena { get; set; }
        public bool BitMensual { get; set; }
        public Nullable<int> VendorId { get; set; }
        public Nullable<int> PosicionID { get; set; }
        public string GLAP { get; set; }
        public decimal SumaExtra { get; set; }
        public byte[] Foto { get; set; }
    
        public virtual T0086_HHRR_POSICIONES T0086_HHRR_POSICIONES { get; set; }
        public virtual T0087_HHRR_DISPONIBILIDAD T0087_HHRR_DISPONIBILIDAD { get; set; }
        public virtual T0088_HHRR_DatosPersonales T0088_HHRR_DatosPersonales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0551_HHRR_SYJ_Items> T0551_HHRR_SYJ_Items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0552_HHRR_SYJ_Payments> T0552_HHRR_SYJ_Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0092_HHRR_COMBOASSIGN> T0092_HHRR_COMBOASSIGN { get; set; }
    }
}
