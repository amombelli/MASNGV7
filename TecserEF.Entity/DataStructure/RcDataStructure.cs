using System;

namespace TecserEF.Entity.DataStructure
{
    public class RcDataStructure
    {
        public int IdRc { get; set; }
        public DateTime FechaRc { get; set; }
        public string Material { get; set; }
        public decimal KgRC { get; set; }
        public decimal KgAprodados { get; set; }
        public string StatusRc { get; set; }
        public int? IdOC { get; set; }
        public DateTime? FechaOC { get; set; }
        public string StatusOC { get; set; }
        public decimal? KgRecibidos { get; set; }
        public DateTime? FechaIc { get; set; }
        public string ObservacionItem { get; set; }
        public int? IdProv { get; set; }
        public string Proveedor { get; set; }
    }
}
