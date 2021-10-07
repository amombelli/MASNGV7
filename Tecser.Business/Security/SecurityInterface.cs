using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Security
{
    public class SecurityInterface
    {

        public int AddNewAppUser(TSecUsr user)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                db.TSecUsr.Add(user);
                if (db.SaveChanges() > 0)
                    return 1;
                return 0;

            }
        }
    }
}
