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
    
    public partial class T0010_MATERIALES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0010_MATERIALES()
        {
            this.T0011_MATERIALES_AKA = new HashSet<T0011_MATERIALES_AKA>();
            this.T0020_FORMULA_H = new HashSet<T0020_FORMULA_H>();
            this.T0020_FORMULA_H1 = new HashSet<T0020_FORMULA_H>();
            this.T0021_FORMULA_I = new HashSet<T0021_FORMULA_I>();
            this.T0030_STOCK = new HashSet<T0030_STOCK>();
            this.T0050_REQUISICION = new HashSet<T0050_REQUISICION>();
            this.T0065_MATERIAL_PROVEEDOR = new HashSet<T0065_MATERIAL_PROVEEDOR>();
            this.T0070_PLANPRODUCCION = new HashSet<T0070_PLANPRODUCCION>();
            this.T0061_OCOMPRA_I = new HashSet<T0061_OCOMPRA_I>();
        }
    
        public string IDMATERIAL { get; set; }
        public string DescripcionFormulacion { get; set; }
        public string DescripcionTecnicaLab { get; set; }
        public string MAT_DESC { get; set; }
        public string MAT_DESC2 { get; set; }
        public string MAT_DESC_L5 { get; set; }
        public string COLOR { get; set; }
        public string COMPUESTO_BASE { get; set; }
        public string TIPO_MATERIAL { get; set; }
        public string ORIGEN { get; set; }
        public string UNIDAD { get; set; }
        public bool BATCHMNG { get; set; }
        public string MAT_GRP1 { get; set; }
        public string MAT_GRP2 { get; set; }
        public bool ACTIVO { get; set; }
        public string MATERIAL_STATUS { get; set; }
        public Nullable<int> TiempoReposicion { get; set; }
        public Nullable<int> StockMinimo { get; set; }
        public Nullable<decimal> CONCENTRACION { get; set; }
        public Nullable<int> FORM_COSTO { get; set; }
        public string IP { get; set; }
        public string Status { get; set; }
        public string GL { get; set; }
        public string GLI { get; set; }
        public Nullable<decimal> Dureza { get; set; }
        public string StockABC { get; set; }
        public Nullable<int> NEL { get; set; }
        public string DesarrolladoPara { get; set; }
        public string MonedaCosto { get; set; }
        public string LogUpdateUser { get; set; }
        public Nullable<System.DateTime> LogUpdateDate { get; set; }
        public string LogCreadoUser { get; set; }
        public System.DateTime LogCreadoFecha { get; set; }
        public string MaintainedViews { get; set; }
        public string EmpaqueDefault { get; set; }
        public Nullable<decimal> PesoNetoStandard { get; set; }
        public string SlocSpecific { get; set; }
    
        public virtual T0009_MATERIALSPEC T0009_MATERIALSPEC { get; set; }
        public virtual T0011_MaterialType T0011_MaterialType { get; set; }
        public virtual T0013_COLORES T0013_COLORES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0011_MATERIALES_AKA> T0011_MATERIALES_AKA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0020_FORMULA_H> T0020_FORMULA_H { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0020_FORMULA_H> T0020_FORMULA_H1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0021_FORMULA_I> T0021_FORMULA_I { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0030_STOCK> T0030_STOCK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0050_REQUISICION> T0050_REQUISICION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0065_MATERIAL_PROVEEDOR> T0065_MATERIAL_PROVEEDOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0070_PLANPRODUCCION> T0070_PLANPRODUCCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0061_OCOMPRA_I> T0061_OCOMPRA_I { get; set; }
        public virtual T0035_CostRoll T0035_CostRoll { get; set; }
    }
}
