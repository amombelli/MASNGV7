using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    public class DsCierreCobranzasxCliente
    {
        public string Periodo { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public int IdCliente { get; set; }
        public string Lx { get; set; }
        public decimal Cobrado { get; set; }
        public int CantidadRegistros { get; set; }
    }
}
