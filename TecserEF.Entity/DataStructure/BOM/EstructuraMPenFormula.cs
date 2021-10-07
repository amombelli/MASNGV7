using System;

namespace TecserEF.Entity.DataStructure.BOM
{
    public class EstructuraMPenFormula
    {
        public string Componente { get; set; }
        public string MaterialFabricar { get; set; }
        public int IdFormula { get; set; }
        public string DescripcionFormula { get; set; }
        public DateTime? UltimoUso { get; set; }
        public bool FormulaActiva { get; set; }
        public string Version { get; set; }

    }
}
