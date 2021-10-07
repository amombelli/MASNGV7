using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    public class PlantasManager
    {

        public List<T0016_PLANTAS> GetListActivePlant()
        {
            return new TecserData(GlobalApp.CnnApp).T0016_PLANTAS.Where(c => c.Activa == true).ToList();
        }
    }
}
