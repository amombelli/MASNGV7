using System;

namespace Tecser.Business.Transactional.MM
{
    public class StockStatusManager
    {
        public enum EstadoLote
        {
            Liberado,
            Restringido,
            FE,
            Comprometido,
            Reservado,
            ReservaPF,
            ReservaRE
        };

        public static EstadoLote MapStatusFromText(string status)
        {
            //Manejo de defaults
            if (status == "LIBERADO")
                status = EstadoLote.Liberado.ToString();

            if (string.IsNullOrEmpty(status))
                status = EstadoLote.Liberado.ToString();

            try
            {
                return (EstadoLote)Enum.Parse(typeof(EstadoLote), status, true);
            }
            catch (Exception)
            {
                return EstadoLote.FE;
                throw;
            }
        }

        public StockStatusManager.EstadoLote MapeaStringToType(string estado)
        {
            switch (estado.ToUpper())
            {
                case "LIBERADO":
                    return MM.StockStatusManager.EstadoLote.Liberado;
                case "COMPROMETIDO":
                    return MM.StockStatusManager.EstadoLote.Comprometido;
                case "FE":
                    return MM.StockStatusManager.EstadoLote.FE;
                case "RESERVAPF":
                    return MM.StockStatusManager.EstadoLote.ReservaPF;
                case "RESERVADO":
                    return MM.StockStatusManager.EstadoLote.Reservado;
                case "RESTRINGIDO":
                    return MM.StockStatusManager.EstadoLote.Restringido;
                case "RESERVARE":
                    return EstadoLote.ReservaRE;
                default:
                    return MM.StockStatusManager.EstadoLote.FE;
            }

        }

    }
}