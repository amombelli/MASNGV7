using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    public class ColoresManagement
    {
        public List<T0013_COLORES> GetColoresList()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0013_COLORES.ToList();
            }
        }
    }
}
