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
    
    public partial class T0016_TaxModuleDefinition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0016_TaxModuleDefinition()
        {
            this.T0017_TaxModuleAssign = new HashSet<T0017_TaxModuleAssign>();
        }
    
        public string IdTax { get; set; }
        public string TaxDescription { get; set; }
        public decimal Alicuota { get; set; }
        public string ModuloAplica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0017_TaxModuleAssign> T0017_TaxModuleAssign { get; set; }
    }
}
