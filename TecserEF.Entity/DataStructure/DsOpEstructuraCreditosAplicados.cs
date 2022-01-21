using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    public class DsOpEstructuraCreditosAplicados
    {
        public string Tdoc { get; set; }
        public string NumeroDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public decimal Importe { get; set; }
    }
}
