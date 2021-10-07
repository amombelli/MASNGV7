using System;
using System.Drawing;

namespace Tecser.Business.Transactional.FI
{
    public static class OrdenPagoStatus
    {
        public enum StatusOP
        {
            Inicial,
            Proceso,
            Generada,
            Finalizada,
            Cancelada
        };
        public static StatusOP MapStatusFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                return OrdenPagoStatus.StatusOP.Inicial;

            //Mapeo to fix errores
            if (status.ToUpper().Equals("@@") || status.ToUpper().Equals("@@@"))
                return OrdenPagoStatus.StatusOP.Inicial;

            if (status.ToUpper().Equals("IMPRESO"))
                return OrdenPagoStatus.StatusOP.Generada;


            try
            {
                return (StatusOP)Enum.Parse(typeof(StatusOP), status, true);
            }
            catch (Exception)
            {
                return StatusOP.Inicial;
                throw;
            }
        }
        public static Color GetColorBackForStatus(StatusOP estadoOP)
        {
            switch (estadoOP)
            {
                case StatusOP.Inicial:
                    return Color.Yellow;
                case StatusOP.Cancelada:
                    return Color.Red;
                case StatusOP.Finalizada:
                    return Color.LimeGreen;
                case StatusOP.Proceso:
                    return Color.DodgerBlue;
                case StatusOP.Generada:
                    return Color.DarkSlateGray;
                default:
                    return Color.White;
            }
        }
    }

}
