using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    //Estructura para generar por Factura el listado de como se ha pagado
    //preparado para las estadisticas de pago DPP, etc.
    public class DsOpDetalleImputacionPorFactura
    {
        public int IdCtaCteFacturaImputada { get; set; }
        public int IdFacturaImputada { get; set; }
        public string TdocFacturaImputada { get; set; }
        public string NumeroFacturaImputada { get; set; }
        public decimal TCFacturaImputada { get; set; }
        public DateTime FechaEmisionFacturaImputada { get; set; }
        public decimal ImporteEmisionFacturaImputada { get; set; }
        public decimal ImporteImputado { get; set; }
        public DateTime? FechaImputacion { get; set; }
        public string TdocImputacion { get; set; }
        public string NumeroDocImputacion { get; set; }
        public int? IdCtaCteImputacion { get; set; }
        public decimal? TcImputacion { get; set; }
        public int? DiasImputacion { get; set; }
        public int? DiasPromedioPago { get; set; }
        public string GlImputacion { get; set; }

    }
}
