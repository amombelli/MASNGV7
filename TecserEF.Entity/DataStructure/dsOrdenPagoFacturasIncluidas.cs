using System;

namespace TecserEF.Entity.DataStructure
{
    /// <summary>
    /// Esta clase la cree para OP incluir estos campos sin modificar la estructura de la tabla
    /// </summary>
    public class DsOrdenPagoFacturasIncluidas : T0213_OP_FACT
    {
        public string Tdoc { get; set; }
        public DateTime FechaDoc { get; set; }
    }
}
