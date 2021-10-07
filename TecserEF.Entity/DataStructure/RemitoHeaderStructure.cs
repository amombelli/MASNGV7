using System;


namespace TecserEF.Entity.DataStructure
{
    public class RemitoHeaderStructureCF
    {
        public int IdRemito { get; set; }
        public string NumRemito { get; set; }
        public DateTime? FechaRemito { get; set; }
        public string RazonSocial { get; set; }
        public string DescripcionEntrega { get; set; }
        public string StatusRemito { get; set; }
        public bool RemitoImpreso { get; set; }
        public bool Facturado { get; set; }
        public string NumeroFactura { get; set; }
        public int? FleteId { get; set; }
        public string LX { get; set; }
        public bool L5 { get; set; }
        public int? Rlink { get; set; }
        public int idClienteT6 { get; set; }



    }
}
