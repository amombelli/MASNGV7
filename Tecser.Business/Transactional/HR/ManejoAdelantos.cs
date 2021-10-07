using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.HR
{
    public class ManejoAdelantos
    {
        public List<T0525_SueldoAdelanto> GetListado()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0525_SueldoAdelanto.OrderByDescending(c => c.idAdelanto).ToList();
            }
        }

        public T0525_SueldoAdelanto GetAdelanto(int idAd)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0525_SueldoAdelanto.SingleOrDefault(c => c.idAdelanto == idAd);
            }
        }

        public void PagarAdelantoAEmplpeado(int idAd, decimal importePagar, string cuentaPago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var reg = db.T0525_SueldoAdelanto.SingleOrDefault(c => c.idAdelanto == idAd);
                reg.MontoAbonado += importePagar;
                reg.FechaPago = DateTime.Today;
                reg.MontoAdeudado += importePagar;
                db.SaveChanges();

                //
                //agregar aca registro SYJ
                //

            }
        }

        public void GrabaNuevaSolicitud(string empleado, decimal monto, DateTime fechaSolicitud, string acuerdoPago, string comentario = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int idAd = 1;
                if (db.T0525_SueldoAdelanto.Any())
                {
                    idAd = db.T0525_SueldoAdelanto.Max(c => c.idAdelanto) + 1;
                }

                var data = new T0525_SueldoAdelanto
                {
                    idAdelanto = idAd,
                    Shortname = empleado,
                    MontoSolicitado = monto,
                    MontoAbonado = 0,
                    FechaSolicitud = fechaSolicitud,
                    AcuerdoDePago = acuerdoPago,
                    Comentario = comentario,
                    MontoAdeudado = 0
                };
                db.T0525_SueldoAdelanto.Add(data);
                db.SaveChanges();
            }

        }

    }
}
