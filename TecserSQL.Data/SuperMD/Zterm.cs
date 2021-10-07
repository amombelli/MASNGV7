using System.Linq;
using TecserEF.Entity;

namespace TecserSQL.Data.SuperMD
{
    public class Zterm
    {
        public Zterm(TecserData context)
        {
        }




        public bool Create_UpdateObject(T0019_ZTERM structure, string cnn)
        {
            using (var db = new TecserData(cnn))
            {
                var query = db.T0019_ZTERM.SingleOrDefault(c => c.ZTERM.Equals(structure.ZTERM));
                if (query == null)
                {
                    db.T0019_ZTERM.Add(structure);
                }
                else
                {
                    db.Entry(query).CurrentValues.SetValues(structure);
                }

                return db.SaveChanges() > 0;
            }
        }
    }
}


