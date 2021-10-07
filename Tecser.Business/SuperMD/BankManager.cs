using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    public class BankManager
    {
        public List<T0160_BANCOS> GetBankList(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return onlyActive ? db.T0160_BANCOS.Where(c => c.ACTIVO.Value).ToList() : db.T0160_BANCOS.ToList();
            }
        }
        public T0160_BANCOS GetBankData(string banco)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0160_BANCOS.SingleOrDefault(c => c.ID_BANCO == banco);
            }
        }
        public T0160_BANCOS GetBankDatabyShortname(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0160_BANCOS.SingleOrDefault(c => c.BCO_SHORTDESC == shortname);
            }
        }
        public T0160_BANCOS GetBankDataNombreCuenta(string banco)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0160_BANCOS.SingleOrDefault(c => c.BANCO == banco);
            }
        }
    }
}
