using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    /// <summary>
    /// Estructura para Dgv en MOP - Remitos y NCD no mapeados en T0140
    /// </summary>
    public class StxDocumentosNotInOperaciones
    {
        public int idRemito { get; set; }
        public int idFactura { get; set; }
        public string tipoLx { get; set; }
        public string numeroRemito { get; set; }
        public string numeroDocumento { get; set; }
        public string tipoDocumento { get; set; }
        public DateTime fechaRemito { get; set; }
        public DateTime? fechaDocumento { get; set; }
        public string item { get; set; }
        public int idItem { get; set; }
        public string moneda { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioU { get; set; }
        public decimal precioT { get; set; }
        public int idCliente { get; set; }
        public string RazonSocial { get; set; }
    }
}
