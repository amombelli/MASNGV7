using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    public partial class DsCreditosOP
    {
        public int Id { get; set; }
        public string TDoc { get; set; }
        public string NumDoc { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public int IdCtaCte { get; set; }
        public decimal PendienteImputar { get; set; }
    }
}
