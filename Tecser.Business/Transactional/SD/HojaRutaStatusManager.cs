using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class HojaRutaStatusManager
    {
        public enum StatusHeader
        {
            Pendiente,
            EnRuta,
            Finalizado,
            Incompleto,
            Cancelada,
        }
        public enum StatusItem
        {
            EntregadoOk,
            NoEntregado,
            EnRutaOK,
        }
        public static StatusHeader MapStatusHeaderFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = StatusHeader.Pendiente.ToString();

            try
            {
                return (StatusHeader)Enum.Parse(typeof(StatusHeader), status, true);
            }
            catch (Exception)
            {
                return StatusHeader.Pendiente;
                throw;
            }
        }
        public static StatusItem MapStatusItemFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = StatusItem.NoEntregado.ToString();

            try
            {
                return (StatusItem)Enum.Parse(typeof(StatusItem), status, true);
            }
            catch (Exception)
            {
                return StatusItem.NoEntregado;
                throw;
            }
        }
        public void SetItemNoEntegado(int idRuta, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var HRItem = db.T0059_HOJARUTA_I.SingleOrDefault(c => c.IdRuta == idRuta && c.IdItem == idItem);
                HRItem.StatusEntrega = StatusItem.NoEntregado.ToString();

                var DataEntrega = db.T0059_ENTREGAS.SingleOrDefault(c => c.idRemito == HRItem.IdRemito);
                DataEntrega.StatusEntrega = EntregaStatusManager.Status.SinAsignar.ToString();

                db.SaveChanges();
            }
        }
        public void SetItemEntregado(int idRuta, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var HRItem = db.T0059_HOJARUTA_I.SingleOrDefault(c => c.IdRuta == idRuta && c.IdItem == idItem);
                HRItem.StatusEntrega = StatusItem.EntregadoOk.ToString();

                var DataEntrega = db.T0059_ENTREGAS.SingleOrDefault(c => c.idRemito == HRItem.IdRemito);
                DataEntrega.StatusEntrega = EntregaStatusManager.Status.Finalizado.ToString();

                db.SaveChanges();
            }
        }
    }
}
