namespace TecserEF.Entity.DataStructure.BOM
{
    public class StxBomHeaderWithCost : T0020_FORMULA_H
    {
        public decimal MfgCostUsd { get; set; }
        public decimal MfgCostArs { get; set; }
        public int Complex { get; set; }
    }
}
