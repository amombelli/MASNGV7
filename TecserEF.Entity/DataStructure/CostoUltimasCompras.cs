using System;

namespace TecserEF.Entity.DataStructure
{
    public class CostoUltimasCompras
    {
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string Material { get; set; }
        public DateTime FechaFactura { get; set; }
        public string MonedaCotizacion { get; set; }
        public int NumeroOC { get; set; }
        public decimal KgCompra { get; set; }
        public decimal PrecioARS { get; set; }
        public decimal PrecioUSD { get; set; }
        public decimal TC { get; set; }
    }
}
