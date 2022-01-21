using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    public partial class DsFacturasOP
    {
        public int IdCtaCte { get; set; }
        public int IdFactura { get; set; }
        public string TDoc { get; set; }
        public string NumDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public string Moneda { get; set; }
        public decimal TC { get; set; }
        public decimal ImporteOri { get; set; }
        public decimal ImporteArs { get; set; }
        public decimal SaldoPendiente { get; set; }
        public decimal Imputado { get; set; }
    }
}
