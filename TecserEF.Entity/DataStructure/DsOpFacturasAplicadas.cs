using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{

    //Estructura para mostrar datos de todas las facturas aplicadas a una orden de Pago
    public class DsOpFacturasAplicadas
    {
        public int IdCtaCte { get; set; }
        public int IdFactura { get; set; }
        public string Tdoc { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ImporteOri { get; set; }
        public decimal ImporteAdeudadoAnterior { get; set; }
        public decimal ImporteAplicado { get; set; }
        public decimal SaldoAdeudado { get; set; }
    }
}
