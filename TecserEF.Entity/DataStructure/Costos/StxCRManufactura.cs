using System;

namespace TecserEF.Entity.DataStructure.Costos
{
    public class StxCrManufactura
    {
        public string Material { get; set; }
        public string Origen { get; set; }
        public string Tipo { get; set; }
        public int FCost { get; set; }
        public string Moneda { get; set; }
        public decimal StdArs { get; set; }
        public decimal StdUsd { get; set; }
        public decimal StdArsA { get; set; }
        public decimal StdUsdA { get; set; }
        public decimal RepoArs { get; set; }
        public decimal RepoUsd { get; set; }
        public decimal VarRepoStdUsd { get; set; }
        public decimal VarRepoStdArs { get; set; }
        public DateTime FechaCostoRepo { get; set; }
        public DateTime FechaCostoStdA { get; set; }
        public bool ManualUpd { get; set; }
        public int LevelMax { get; set; }

    }
}
