using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{

    /// <summary>
    /// Estructura para reporte raffone cierre Ventas
    /// </summary>
    public class DsCierreVentas
    {
        public int IdFactura { get; set; }
        public int IdCtaCte { get; set; }
        public string Periodo { get; set; }
        public DateTime Fecha { get; set; }
        public string Tdoc { get; set; }
        public string NumeroDoc { get; set; }
        public string NumeroRemito { get; set; }
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public decimal ImporteBruto { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal ImporteIva21 { get; set; }
        public decimal ImportePercArba { get; set; }
        public decimal AlicuotaArba { get; set; }
        public decimal ImporteNeto { get; set; }
        public string CaeNumero { get; set; }
        public DateTime? CaeVencimiento { get; set; }
        public decimal KgVendidos { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Lx { get; set; }
    }
}
