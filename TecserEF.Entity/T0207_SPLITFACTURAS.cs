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
    
    public partial class T0207_SPLITFACTURAS
    {
        public int INTDOC { get; set; }
        public string TDOC { get; set; }
        public int IDCTACTE { get; set; }
        public Nullable<int> IDDOC { get; set; }
        public string NDOC { get; set; }
        public int FACTSPLIT { get; set; }
        public string FACT_MONEDA { get; set; }
        public decimal ImporteDocumento { get; set; }
        public decimal ImporteAImputar { get; set; }
        public decimal MontoImputado { get; set; }
        public string TIPO { get; set; }
        public int CLIENTE { get; set; }
        public System.DateTime FECHA_FACT { get; set; }
        public Nullable<System.DateTime> FECHA_VENC { get; set; }
        public Nullable<int> DIAS_VENC { get; set; }
        public string NRECIBO { get; set; }
        public Nullable<System.DateTime> PFECHA { get; set; }
        public string XCOMENTARIO { get; set; }
        public Nullable<int> ZTERM { get; set; }
        public Nullable<int> IDCOB { get; set; }
        public Nullable<int> IDNC { get; set; }
        public string NumeroDoc { get; set; }
        public string TipoDocCancel { get; set; }
        public Nullable<int> DiasPPCob { get; set; }
        public Nullable<int> DiasImpu { get; set; }
        public Nullable<decimal> USDImpu { get; set; }
    }
}
