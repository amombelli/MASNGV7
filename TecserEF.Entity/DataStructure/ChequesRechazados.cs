using System;

namespace TecserEF.Entity.DataStructure
{
    public partial class TsChequesRechazados
    {
        public int Idcheque { get; set; }
        public DateTime FechaAcreditacion { get; set; }
        public String Numero { get; set; }
        public String BancoShort { get; set; }
        public decimal Importe { get; set; }
        public String ClienteRs { get; set; }
        public DateTime FechaRechazo { get; set; }
        public String MotivoRechazo { get; set; }
        public String TipoLx { get; set; }
        public String NumeroNd { get; set; }
        public int? IdT400 { get; set; }
        public int? IdCtaCte { get; set; }
        public decimal? SaldoNd { get; set; }
        public bool Entregado { get; set; }
        public string EntregadoPor { get; set; }
        public DateTime? FechaEntregado { get; set; }

    }

}
