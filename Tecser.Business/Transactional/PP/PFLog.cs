using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.PP
{
    public class PFLog
    {
        public static void AddLog(int idPlan, string statusOF, string comentario)
        {
            if (string.IsNullOrEmpty(comentario))
            {
                comentario = $@"Se ha pasdo la Orden a estado {statusOF}";
            }
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var history = db.T0074_PFLOG.Where(c => c.idPlan == idPlan).ToList();
                var xid = history.Count() + 1;
                var table = new T0074_PFLOG()
                {
                    LogDate = DateTime.Now,
                    LogUser = GlobalApp.AppUsername,
                    idPlan = idPlan,
                    PlanStatus = statusOF,
                    Comentario = comentario,
                    idOrden = xid
                };
                db.T0074_PFLOG.Add(table);
                db.SaveChanges();
            }
        }
    }
}
