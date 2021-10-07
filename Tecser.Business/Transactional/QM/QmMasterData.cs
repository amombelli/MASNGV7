using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.QM
{
    public class QmMasterData
    {
        /// <summary>
        /// Get List QM Master Data (all)
        /// </summary>
        public List<T0801_QMMasterIPHeader> GetPlanHeaderList()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0801_QMMasterIPHeader.ToList();
            }
        }


        public bool DeleteMetodoToInspeccionId(int idQM, string IdMetodoodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var inspectionData = db.T0811_QMDetailData.SingleOrDefault(c => c.IDPI == idQM && c.METODO == IdMetodoodo);
                if (inspectionData.MetodoAdded)
                {
                    db.T0811_QMDetailData.Remove(inspectionData);
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }

        public void UpdateInspeccionId(int idQm, int idCounter, string medicion, string status, DateTime? fechaInsp,
            string responsable, string observaciones)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var inspectionData =
                    db.T0811_QMDetailData.SingleOrDefault(c => c.IDPI == idQm && c.COUNTER == idCounter);
                inspectionData.COMENTARIO = observaciones;
                inspectionData.VALORCQ = medicion;
                inspectionData.RESULTADOCQ = status;
                if (status.ToUpper() == "APROBADO")
                {
                    inspectionData.ControlOK = true;
                }
                else
                {
                    inspectionData.ControlOK = false;
                }

                if (fechaInsp == null)
                {
                    inspectionData.FechaControl = DateTime.Today;
                }
                else
                {
                    inspectionData.FechaControl = fechaInsp;
                }

                inspectionData.UserControl = responsable;

                db.SaveChanges();

            }
        }






    }
}
