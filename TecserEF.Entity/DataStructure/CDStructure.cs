using System;

namespace TecserEF.Entity.DataStructure
{
    public class CDStructure
    {
        public int IdOv { get; set; }
        public int IdC7 { get; set; }
        public int IdC6 { get; set; }
        public string FantasiaC7 { get; set; }
        public string RazonSocialC7 { get; set; }
        public DateTime? FechaCompromiso { get; set; }
        public string Aka { get; set; }
        public string Primario { get; set; }
        public decimal KgPedidos { get; set; }
        public decimal KgDespachados { get; set; }
        public decimal KgPendientes { get; set; }
        public decimal KgComprometidos { get; set; }
        public decimal KgStockTotal { get; set; }
        public string StatusOv { get; set; }
        public string StatusItem { get; set; }
        public string DireccionEntrega { get; set; }
        public string LocalidadEntrega { get; set; }
        public string ZonaEntrega { get; set; }
        public string LX { get; set; }
        public int IdItem { get; set; }
        public string StatusStock { get; set; }
        public bool BoolCompromiso { get; set; }
        public DateTime? FechaOV { get; set; }
        public string StatusPedido { get; set; }
        public decimal KgPedidosPendientes { get; set; }
        public string ObservacionItem { get; set; }
    }
}
