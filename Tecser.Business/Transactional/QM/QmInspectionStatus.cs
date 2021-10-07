using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.QM
{
    public class QmInspectionStatus
    {
        public enum StatusIRecord
        {
            SinIniciar,
            Comenzado,
            Aprobado,
            Rechazado,
            Cancelado,
        }

        public StatusIRecord MapFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                return StatusIRecord.SinIniciar;
            try
            {
                return (StatusIRecord)Enum.Parse(typeof(StatusIRecord), status, true);
            }
            catch (Exception)
            {
                return StatusIRecord.SinIniciar;
                throw;

            }
        }

        public void SetAprobadoDudoso(int idRecord, int idCounterH2, string observacionesH2)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataH2 =
                    db.T0806_QMIRecordH2.SingleOrDefault(c => c.IdRec == idRecord && c.IdCounter == idCounterH2);

                dataH2.AprobadoDudoso = true;
                dataH2.AprobadoOk = true;
                dataH2.EstadoInspeccion = QmInspectionStatus.StatusIRecord.Aprobado.ToString();
                dataH2.ComentarioH2 = observacionesH2;
                db.SaveChanges();
            }
        }

        public void UpdateStatusH2Normal(int idRecord, int idCounterH2, StatusIRecord status)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataH2 =
                    db.T0806_QMIRecordH2.SingleOrDefault(c => c.IdRec == idRecord && c.IdCounter == idCounterH2);
                dataH2.EstadoInspeccion = status.ToString();

                switch (status)
                {
                    case StatusIRecord.SinIniciar:
                        dataH2.AprobadoOk = false;
                        dataH2.AprobadoDudoso = false;
                        dataH2.FechaCierre = null;
                        break;
                    case StatusIRecord.Comenzado:
                        dataH2.AprobadoOk = false;
                        dataH2.AprobadoDudoso = false;
                        dataH2.FechaCierre = null;
                        break;
                    case StatusIRecord.Aprobado:
                        dataH2.AprobadoOk = true;
                        dataH2.AprobadoDudoso = false;
                        dataH2.FechaCierre = DateTime.Today;
                        break;
                    case StatusIRecord.Rechazado:
                        dataH2.AprobadoOk = false;
                        dataH2.AprobadoDudoso = false;
                        dataH2.FechaCierre = DateTime.Today;
                        break;
                    case StatusIRecord.Cancelado:
                        dataH2.AprobadoOk = false;
                        dataH2.AprobadoDudoso = false;
                        dataH2.FechaCierre = DateTime.Today;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(status), status, null);
                }
                db.SaveChanges();
            }

        }
    }
}
