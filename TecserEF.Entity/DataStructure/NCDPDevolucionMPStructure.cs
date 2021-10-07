using System;

namespace TecserEF.Entity.DataStructure
{
    public class NcdpDevolucionMPStructure
    {
        public int id403 { get; set; }
        public int id404 { get; set; }
        public int IdProveedeor { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Item { get; set; }
        public string MonedaDoc { get; set; }
        public string MonedaItem { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? TCConta { get; set; }
        public decimal? PUnitArs { get; set; }
        public decimal? PUnitUsd { get; set; }
        public string GL { get; set; }
    }
}
