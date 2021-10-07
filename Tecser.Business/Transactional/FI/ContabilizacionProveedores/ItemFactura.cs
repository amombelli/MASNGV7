namespace Tecser.Business.Transactional.FI.ContabilizacionProveedores
{
    public partial class ItemFactura
    {
        public int Id63 { get; set; }
        public int NumeroItem { get; set; }
        public string Material { get; set; }
        public decimal TC { get; set; }
        public string NumeroRemito { get; set; }
        public decimal CantidadFacturar { get; set; }
        public decimal PrecioU_MonFact { get; set; }
        public decimal PrecioT_MonFact { get; set; }
        public decimal PrecioU_USD { get; set; }
        public bool IncluirEVP { get; set; }
        public string GL { get; set; }
        public bool IncluyeBaseImponible { get; set; }
        public string MonedaPrecioUc { get; set; }
        public decimal PrecioUnitarioUc { get; set; }
        public bool UpdatePrecioUc { get; set; }
    }
}
