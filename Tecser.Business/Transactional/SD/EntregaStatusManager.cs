using System;

namespace Tecser.Business.Transactional.SD
{
    public static class EntregaStatusManager
    {
        public enum Status
        {
            SinAsignar,
            EnRuta,
            Finalizado,
            Cancelado,
        }
        public static Status MapStatusFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = Status.SinAsignar.ToString();

            try
            {
                return (Status)Enum.Parse(typeof(Status), status, true);
            }
            catch (Exception)
            {
                return Status.SinAsignar;
                throw;
            }
        }
    }
}
