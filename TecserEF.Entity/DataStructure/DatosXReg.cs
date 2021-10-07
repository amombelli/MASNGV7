using System;

namespace TecserEF.Entity.DataStructure
{
    public partial class DatosXReg
    {
        public int IDINT { get; set; }
        public int IDITEM { get; set; }
        public String CUENTA_O { get; set; }
        public String CUENTA_D { get; set; }
        public bool CH { get; set; }
        public int CHID { get; set; }
        public string BCO { get; set; }
        public string BANCO { get; set; }
        public string CUENTA { get; set; }
        public string MONEDA { get; set; }
        public decimal IMPORTE_O { get; set; }
        public decimal IMPORTE_D { get; set; }
        public decimal IMPORTE_ARS { get; set; }
        public bool CONTABILIZADO { get; set; }
        public string GLO { get; set; }
        public string GLD { get; set; }
        public string CHTIPO { get; set; }
    }
}
