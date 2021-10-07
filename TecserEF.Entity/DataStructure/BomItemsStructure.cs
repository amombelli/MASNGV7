namespace TecserEF.Entity.DataStructure
{
    public class BomItemsStructure
    {
        public int IdFormula { get; set; }
        public int IdItem { get; set; }
        public string Item { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CantidadPorcentaje { get; set; }
        public string UoM { get; set; }
        public int? Secuencia { get; set; }
        public string DescripcionMaterial { get; set; }
        public string DescripcionLaboratorio { get; set; }
        public bool Explota { get; set; }
        public int? ExplotaVersion { get; set; }
    }
}
