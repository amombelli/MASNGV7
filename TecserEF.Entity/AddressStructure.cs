using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity
{
    public class AddressStructure
    {
        public int IdProvincia { get; set; }
        public int IdPartiado { get; set; }
        public int IdLocalidad { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Partido { get; set; }
        public string Localidad { get; set; }
    }


}
