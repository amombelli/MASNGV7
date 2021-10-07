using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.PP
{
    public class AprobacionPlanificar
    {
        public void AprobarOF(int of, string tcode)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == of);
                data.AprobadoFabFecha = DateTime.Now;
                data.AprobadoFabTcode = tcode;
                data.AprobadoFabUser = GlobalApp.AppUsername;
                data.AprobadoFabricar = true;
                db.SaveChanges();
                PFLog.AddLog(of, data.STATUS + @"-Ok", @"Se ha Autorizado la OF");
            }
        }

        public bool GetStatusAprobacionOF(int of)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == of);
                return data.AprobadoFabricar;
            }
        }

        public void DesaprobarOF(int of, string tcode)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == of);
                data.AprobadoFabFecha = DateTime.Now;
                data.AprobadoFabTcode = tcode;
                data.AprobadoFabUser = GlobalApp.AppUsername;
                data.AprobadoFabricar = false;
                db.SaveChanges();
                PFLog.AddLog(of, data.STATUS + @"-NO", @"Se ha Desautorizado la OF");
            }
        }
    }
}
