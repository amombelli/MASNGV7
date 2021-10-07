using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    public class Ubicaciones
    {
        public List<T0028_SLOC> GetUbicacionesStockDisponibleProduccion(string planta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0028_SLOC.Where(c => c.AllowProduction == true && c.ACTIVO == true && c.PLTN.ToUpper().Equals(planta.ToUpper())).ToList();
            }
        }

        public List<T0028_SLOC> GetUbicacionesStockDisponibleCompra(string planta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0028_SLOC.Where(c => c.AllowPurchase == true && c.ACTIVO == true && c.PLTN.ToUpper().Equals(planta.ToUpper())).ToList();
            }
        }

        public List<T0028_SLOC> GetUbicacionesStockDisponibleEntrega(string planta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0028_SLOC.Where(c => c.AllowDelivery == true && c.ACTIVO == true && c.PLTN.ToUpper().Equals(planta.ToUpper())).ToList();
            }
        }


        public List<T0028_SLOC> GetCompleteListSLOC()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0028_SLOC.ToList();
            }
        }

        public List<T0028_SLOC> GetCompleteListSloCbyPlant(string planta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0028_SLOC.Where(c => c.PLTN.ToUpper().Equals(planta.ToUpper())).ToList();
            }
        }

        public bool IsSlocAvailable(string sloc, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x =
                    db.T0028_SLOC.SingleOrDefault(
                        c => c.SLOC.ToUpper().Equals(sloc.ToUpper()) && c.PLTN.ToUpper().Equals(planta.ToUpper()));

                if (x == null)
                    return false;
                return true;
            }
        }

    }
}
