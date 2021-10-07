using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class PFFixKgTemporales
    {
        public static bool FixKgTemporalesIngresados(int idplan, decimal kg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idplan);
                if (result != null)
                {
                    result.KG_Fabricados = kg;
                }
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
    }
}
