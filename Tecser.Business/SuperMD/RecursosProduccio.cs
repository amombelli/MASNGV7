using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    public class RecursosProduccion
    {

        public List<T0032_RECURSOS> GetListRecursosProduccion(string planta = "CERR")
        {
            return
                new TecserData(GlobalApp.CnnApp).T0032_RECURSOS.Where(c => c.PLTN.Equals(planta)).OrderBy(c => c.DescRecurso).ToList();

        }

        public T0032_RECURSOS GetDetallesRecursoProduccion(int idrecurso)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0032_RECURSOS.SingleOrDefault(c => c.IdRecurso == idrecurso);
            }
        }

    }
}
