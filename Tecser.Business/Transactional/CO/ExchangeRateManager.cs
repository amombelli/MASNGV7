using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    public class ExchangeRateManager
    {

        public List<T0102_EXCHANGE> GetXrateList()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0102_EXCHANGE.OrderByDescending(c => c.Fecha).ToList();
            }
        }

        public bool CheckDateExist(DateTime date)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0102_EXCHANGE.SingleOrDefault(c => c.Fecha == date);
                return data != null;
            }
        }

        public void SetValues(DateTime date, decimal xrateFactu, decimal xrateFactu2, decimal xrateCobranza)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0102_EXCHANGE.SingleOrDefault(c => c.Fecha == date);
                if (data == null)
                {
                    var x = new T0102_EXCHANGE()
                    {
                        Fecha = date,
                        CotizacionFactu = xrateFactu,
                        CotizacionCobra = xrateCobranza,
                        CotizacionFactuL2 = xrateFactu2,
                        LDATE = DateTime.Now,
                        LUSER = GlobalApp.AppUsername
                    };
                    db.T0102_EXCHANGE.Add(x);
                    db.SaveChanges();
                }
                else
                {
                    data.CotizacionCobra = xrateCobranza;
                    data.CotizacionFactu = xrateFactu;
                    data.CotizacionFactuL2 = xrateFactu2;
                    data.LDATE = DateTime.Now;
                    data.LUSER = GlobalApp.AppUsername;
                    db.SaveChanges();
                }
            }
        }

        public decimal GetExchangeRate(DateTime date)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0102_EXCHANGE.SingleOrDefault(c => c.Fecha == date);
                if (x == null)
                {
                    var x2 = db.T0102_EXCHANGE.Where(c => c.Fecha < date)
                        .OrderByDescending(c => c.Fecha)
                        .FirstOrDefault();
                    if (x2 == null)
                    {
                        return 9999;
                    }
                    else
                    {
                        return x2.CotizacionFactu.Value;
                    }
                }
                else
                {
                    return x.CotizacionFactu.Value;
                }
            }
        }
    }
}
