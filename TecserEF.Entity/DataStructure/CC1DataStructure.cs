using System;

namespace TecserEF.Entity.DataStructure
{
    public class Cc1DataStructure
    {
        public int IdCtaCte { get; set; }
        public int? IdFactura400 { get; set; }
        public string Td { get; set; }
        public string NumeroDoc { get; set; }
        public DateTime Fecha { get; set; }
        public string Moneda { get; set; }
        public decimal Importe { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string LX { get; set; }
        public string Usuario { get; set; }
        public string ClienteRS { get; set; }
        public int IdCliente { get; set; }
        public string NumeroRemito { get; set; }
    }
    public class Cc1AnalisisDiferenciaStructure
    {
        public int IdCliente { get; set; }
        public string RazonSocial { get; set; }
        public string TipoLx { get; set; }
        public decimal Saldo202 { get; set; }
        public decimal Saldo201 { get; set; }
        public decimal Saldo207 { get; set; }
        public decimal SaldoNI { get; set; }
        public decimal Dif202201 { get; set; }
        public decimal Dif202207 { get; set; }
        public decimal Dif201207 { get; set; }
        public string Observacion { get; set; }
    }
}

