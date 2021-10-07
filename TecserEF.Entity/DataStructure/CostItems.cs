using System;

namespace TecserEF.Entity.DataStructure
{
    public class CostItems
    {
        public string MaterialF { get; set; }
        public string ItemMP { get; set; }
        public string Moneda { get; set; }
        public decimal CostoUnit { get; set; }
        public decimal Prop { get; set; }
        public decimal CostoProp { get; set; }
        public bool CostoFound { get; set; }
    }

    public class CostHeader
    {
        public string Origen { get; set; }
        public int? Fcost { get; set; }
        public string Moneda { get; set; }
        public decimal CostoUsd { get; set; }
        public string Material { get; set; }
        public bool CalculoOk { get; set; }
        public DateTime FechaCosto { get; set; }
        public int LevelMax { get; set; }

    }
}
