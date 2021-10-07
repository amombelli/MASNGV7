using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.HR
{
    //clase vieja
    public class SyjDataManager
    {
        public List<T0518_ConceptosHR> GetConceptos()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0518_ConceptosHR.OrderBy(c => c.IdConceptoHR).ToList();
            }
        }

        public List<T0518_ConceptosHR> GetConceptoAdelanto()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0518_ConceptosHR.Where(c => c.IdConceptoHR == "ADELANTO").OrderBy(c => c.IdConceptoHR).ToList();
            }
        }

        public int CreateSyJHeader(DateTime fechaConta, string comentario, string lx, decimal importeTotal = 0, decimal importePagado = 0, bool aProbado = false, DateTime? fechaAprobacion = null, string aprobadoPor = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int idSyj = 1;
                if (db.T0519_SYJHeader.Any())
                {
                    idSyj = db.T0519_SYJHeader.Max(c => c.idH) + 1;
                }
                var data = new T0519_SYJHeader()
                {
                    idH = idSyj,
                    Moneda = "ARS",
                    LogUser = GlobalApp.AppUsername,
                    LogDate = DateTime.Today,
                    Lx = lx,
                    Descripcion = comentario,
                    Aprobado = aProbado,
                    FechaConta = fechaConta,
                    ImportePagado = importePagado,
                    ImporteTotal = importeTotal,
                    AprobadoEn = fechaAprobacion,
                    AprobadoPor = aprobadoPor,
                    Periodo = new PeriodoConversion().GetPeriodo(fechaConta)

                };


                return db.SaveChanges();
            }
        }
    }
}
