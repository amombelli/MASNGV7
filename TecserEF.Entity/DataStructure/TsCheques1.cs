using System;

namespace TecserEF.Entity.DataStructure
{
    /// <summary>
    /// Estructura de datos de cheques para reporte
    /// </summary>
    public partial class TsCheques1
    {
        public int Idcheque { get; set; }
        public decimal Importe { get; set; }
        public String Numero { get; set; }
        public String BancoShort { get; set; }
        public String ClienteRs { get; set; }
        public bool Disponible { get; set; }
        public String Tipo { get; set; }
        public DateTime FechaAcreditacion { get; set; }
        public DateTime FechaRecibido { get; set; }
        public DateTime? FechaEntregado { get; set; }
        public string Comentario { get; set; }
        public String BancoId { get; set; }
        public bool Interior { get; set; }
        public string EntregadoA { get; set; }
        public string DocumentoSalida { get; set; }
        public string TipoSalida { get; set; }
        public bool Rechazado { get; set; }
        public bool IsEcheque { get; set; }

    }
}
