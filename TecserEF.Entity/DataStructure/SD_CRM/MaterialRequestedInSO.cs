using System;

namespace TecserEF.Entity.DataStructure.SD_CRM
{
    public class MaterialRequestedInSO
    {
        public int IdSO { get; set; }
        public DateTime FechaSO { get; set; }
        public int IdCliente { get; set; }
        public string Material { get; set; }
        public string ClienteRs { get; set; }
        public decimal KgRequested { get; set; }
        public decimal KgComprometidos { get; set; }
        public decimal KgRestantes { get; set; }
        public string StatusOV { get; set; }
        public string StatusItem { get; set; }
    }
}
