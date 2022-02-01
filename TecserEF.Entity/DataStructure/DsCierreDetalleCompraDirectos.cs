using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    public class DsCierreDetalleCompraDirectos
    {
        public string periodo { get; set; }
        public int IdProv { get; set; }
        public string RazonSocial { get; set; }
        public string TipoProveedor { get; set; }
        public DateTime FechaConta { get; set; }
        public string  TD { get; set; }
        public string NumeroDoc { get; set; }
        public string  Material { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioU { get; set; }
        public decimal PrecioTotal { get; set; }
        public string GLI { get; set; }
        public string GLAP { get; set; }
    }
}
