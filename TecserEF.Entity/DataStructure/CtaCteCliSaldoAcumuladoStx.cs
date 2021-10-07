using System;

namespace TecserEF.Entity.DataStructure
{
    /// <summary>
    /// Estructura para generar el reporte de saldo de cuentas corrientes
    /// Estilo 'Cliente' solicitao por Nicolas
    /// </summary>
    public partial class CtaCteCliSaldoAcumuladoStx
    {
        public int IdReg { get; set; }
        public DateTime FechaDoc { get; set; }
        public String TipoDoc { get; set; }
        public String Numero { get; set; }
        public String Lx { get; set; }
        public string Mon { get; set; }
        public decimal TC { get; set; }
        public decimal Importe { get; set; }
        public decimal SaldoAcc { get; set; }
        public decimal ImporteUSD { get; set; }

    }
}
