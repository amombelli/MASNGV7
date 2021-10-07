using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    public class StorageLocationManager
    {

        public List<T0028_SLOC> ListOfLocAvailableToIC(bool onlyActive = true, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                {
                    var lista = db.T0028_SLOC.Where(c => c.ACTIVO && c.PLTN == planta && c.AllowPurchase).ToList();
                    return lista;
                }
                return db.T0028_SLOC.Where(c => c.PLTN == planta && c.AllowPurchase).ToList();
            }
        }

        public List<T0028_SLOC> ListOfLoc(bool onlyActive = true, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                {
                    var lista = db.T0028_SLOC.Where(c => c.ACTIVO && c.PLTN == planta).ToList();
                    return lista;
                }
                return db.T0028_SLOC.Where(c => c.PLTN == planta).ToList();
            }
        }

        public static string GetSlocDescription(string sloc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0028_SLOC.SingleOrDefault(c => c.SLOC.ToUpper().Equals(sloc.ToUpper()));
                if (x == null)
                    return "SLOC NO ENCONTRADA";
                return x.SLOC_DESC;
            }
        }

        public static string GetPlantaFromSloc(string sloc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var plt = db.T0028_SLOC.SingleOrDefault(c => c.SLOC == sloc);
                if (plt == null)
                    return "CERR";
                return plt.PLTN;
            }
        }
    }
}
