using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;

namespace TecserSQL.Data.SuperMD
{
    public class Address
    {
        public Address(string cnn)
        {
            GlobalApp.CnnApp = cnn;
        }

        private static class GlobalApp
        {
            public static string CnnApp;
        }


        public List<T0010_LOCALIDAD> GetAllLocalidadesFromSelectedProvincia(int idProvincia)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from partido in db.T0010_PARTIDO
                            join localidad in db.T0010_LOCALIDAD
                                on partido.Id equals localidad.IdPartido
                            where partido.IdProvincia == idProvincia
                            select localidad;
                return query.ToList();

                //return query.Cast<T0010_LOCALIDAD>().ToList();
            }
        }

    }
}

