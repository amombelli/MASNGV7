using System;

namespace TecserEF.Entity.DataStructure.MRP
{
    public class MRP2Struct
    {
        public string MaterialMP { get; set; }
        public decimal CantRequired { get; set; }
        public decimal StockTotal { get; set; } //Stock Liberado
        public decimal StockReservado { get; set; } //Stock Reserva
        public decimal StockDispProd { get; set; } //Stock Disponible Produccion
        public DateTime FechaHora { get; set; }
    }
}
