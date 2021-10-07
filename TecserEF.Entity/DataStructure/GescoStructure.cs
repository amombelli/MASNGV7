using System;

namespace TecserEF.Entity.DataStructure
{
    /// <summary>
    /// Estructura utilizada para GESCO02
    /// </summary>
    public class GescoStructure
    {
        public string ClienteRs { get; set; }
        public string ClienteFantasia { get; set; }
        public int IdCliente { get; set; }
        public decimal SaldoL1 { get; set; }
        public decimal SaldoL2 { get; set; }
        public decimal SaldoTotal { get; set; }
        public decimal? LimiteCredito { get; set; }
        public int DocumentosImpagos { get; set; }
        public bool ConciliarCtaRequest { get; set; }
        public bool CallRequest { get; set; }
        public DateTime? ProximaLlamada { get; set; }
        public DateTime? UltimaLlamada { get; set; }
        public DateTime? FechaPago { get; set; }
        public DateTime? PL { get; set; }
        public bool ClienteActivo { get; set; }
        public bool ClienteBloqueado { get; set; }
    }
}
