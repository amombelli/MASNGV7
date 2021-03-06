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
    
    public partial class T0154_CHEQUES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0154_CHEQUES()
        {
            this.T0158_CHRTRACKER = new HashSet<T0158_CHRTRACKER>();
        }
    
        public int IDCHEQUE { get; set; }
        public string MONEDA { get; set; }
        public Nullable<decimal> IMPORTE { get; set; }
        public string CHE_NUMERO { get; set; }
        public string CHE_BANCO { get; set; }
        public Nullable<bool> CHE_INTERIOR { get; set; }
        public System.DateTime CHE_FECHA { get; set; }
        public string CHE_CUIT { get; set; }
        public string CHE_TITULAR { get; set; }
        public string CLIENTE { get; set; }
        public System.DateTime FECHA_RECIBIDO { get; set; }
        public Nullable<System.DateTime> FECHA_ENTREGADO { get; set; }
        public string RECIBON { get; set; }
        public string PROVEEDOR { get; set; }
        public bool DISPONIBLE { get; set; }
        public string OP { get; set; }
        public string TIPO { get; set; }
        public string TIPO_REC { get; set; }
        public string OP_GN { get; set; }
        public bool CH_RECH { get; set; }
        public Nullable<int> CH_IDR { get; set; }
        public string CALIFICACION { get; set; }
        public string COMENTARIO { get; set; }
        public Nullable<int> ASENT { get; set; }
        public Nullable<int> ASSAL { get; set; }
        public string TIPOSAL { get; set; }
        public Nullable<int> IdClienteRecibido { get; set; }
        public string CodigoPostal { get; set; }
        public string CuentaTx { get; set; }
        public Nullable<int> IdCobranza { get; set; }
        public Nullable<int> IdProveedorSalida { get; set; }
        public string StatusCheque { get; set; }
        public bool Acreditado { get; set; }
        public bool Echeque { get; set; }
        public string EchequeBancoGL { get; set; }
    
        public virtual T0160_BANCOS T0160_BANCOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0158_CHRTRACKER> T0158_CHRTRACKER { get; set; }
    }
}
