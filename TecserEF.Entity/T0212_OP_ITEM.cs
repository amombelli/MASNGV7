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
    
    public partial class T0212_OP_ITEM
    {
        public int IDOP { get; set; }
        public int IDITEM { get; set; }
        public Nullable<int> PROVEEDOR { get; set; }
        public string MON { get; set; }
        public decimal IMPORTE { get; set; }
        public Nullable<decimal> TC { get; set; }
        public string MON_OP { get; set; }
        public decimal IMPORTE_OP { get; set; }
        public string CUENTA_O { get; set; }
        public bool CH_CK { get; set; }
        public string CH_NUM { get; set; }
        public string CH_BCO { get; set; }
        public Nullable<int> CH_ID { get; set; }
        public bool CK_FIN { get; set; }
        public bool CK_CANCEL { get; set; }
        public Nullable<System.DateTime> ChequeFecha { get; set; }
        public string GL { get; set; }
        public bool IsEcheque { get; set; }
        public string TextoAlterno { get; set; }
    
        public virtual T0150_CUENTAS T0150_CUENTAS { get; set; }
        public virtual T0210_OP_H T0210_OP_H { get; set; }
    }
}
