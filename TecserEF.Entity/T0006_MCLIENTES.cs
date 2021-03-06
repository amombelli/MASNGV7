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
    
    public partial class T0006_MCLIENTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0006_MCLIENTES()
        {
            this.T0007_CLI_ENTREGA = new HashSet<T0007_CLI_ENTREGA>();
            this.T0201_CTACTE = new HashSet<T0201_CTACTE>();
            this.T0202_CTACTESALDOS = new HashSet<T0202_CTACTESALDOS>();
            this.T0208_COB_NO_APLICADA = new HashSet<T0208_COB_NO_APLICADA>();
            this.T0205_COBRANZA_H = new HashSet<T0205_COBRANZA_H>();
            this.T0300_NCD_H = new HashSet<T0300_NCD_H>();
            this.T0400_FACTURA_H = new HashSet<T0400_FACTURA_H>();
        }
    
        public int IDCLIENTE { get; set; }
        public string cli_rsocial { get; set; }
        public string cli_fantasia { get; set; }
        public string CUIT { get; set; }
        public string Direccion_facturacion { get; set; }
        public string Direfactu_Localidad { get; set; }
        public string Direfactu_Provincia { get; set; }
        public string Telefono_Venta { get; set; }
        public string Direfactu_Zona { get; set; }
        public string Pais { get; set; }
        public string Fax { get; set; }
        public string ZIP { get; set; }
        public string TELEFONO_COB { get; set; }
        public string CONTACTO_VTA { get; set; }
        public string CONTACTO_COB { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public Nullable<System.DateTime> Ultimo_Movimiento { get; set; }
        public Nullable<int> Limite_credito { get; set; }
        public Nullable<int> ZTERM { get; set; }
        public bool SCCL2 { get; set; }
        public string EMAIL_FACTU { get; set; }
        public string EMAIL_COBR { get; set; }
        public string COBRADOR { get; set; }
        public Nullable<int> DM_IDTAS { get; set; }
        public bool ACTIVO { get; set; }
        public string DIRECCION_COBRO_ALT { get; set; }
        public string DIA_HORARIO_COBRO { get; set; }
        public string TTAX { get; set; }
        public bool UNTIPO { get; set; }
        public bool GC { get; set; }
        public bool GCADMIN { get; set; }
        public Nullable<int> MAX_CH_DIAS { get; set; }
        public bool BLK_PEDIDO { get; set; }
        public bool BLK_DELIVERY { get; set; }
        public string ZTERML1 { get; set; }
        public string ZTERML2 { get; set; }
        public string Direfactu_Partido { get; set; }
        public string DireFactu_Num { get; set; }
        public string P_IIBB { get; set; }
        public Nullable<double> P_IIBBALIC { get; set; }
        public Nullable<System.DateTime> P_UPD { get; set; }
        public Nullable<int> IdLocalidadAddress { get; set; }
        public Nullable<double> Descuento { get; set; }
        public string Comentario { get; set; }
        public string NombreAnterior { get; set; }
        public Nullable<bool> AllowL1 { get; set; }
        public Nullable<bool> AllowL2 { get; set; }
        public Nullable<bool> AllowL5 { get; set; }
        public string LogCreadoPor { get; set; }
        public string LogModificadoPor { get; set; }
        public Nullable<System.DateTime> LogModoficadoEn { get; set; }
        public string MotivoDescuento { get; set; }
        public string ClienteRubro { get; set; }
        public string DireccionGoogleMaps { get; set; }
        public bool AutoCreditLimit { get; set; }
        public int AutoCreditLimitDays { get; set; }
        public string TelefonoCobranza2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0007_CLI_ENTREGA> T0007_CLI_ENTREGA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0201_CTACTE> T0201_CTACTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0202_CTACTESALDOS> T0202_CTACTESALDOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0208_COB_NO_APLICADA> T0208_COB_NO_APLICADA { get; set; }
        public virtual T0230_GescoHeader T0230_GescoHeader { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0205_COBRANZA_H> T0205_COBRANZA_H { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0300_NCD_H> T0300_NCD_H { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0400_FACTURA_H> T0400_FACTURA_H { get; set; }
    }
}
