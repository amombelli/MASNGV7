using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class FasonExternoMng
    {
        public int SaveData(T0077_FASONEXT_H h)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (h.IDF == 0)
                {
                    int idx = db.T0077_FASONEXT_H.Max(i => (int?)i.IDF) ?? 0;
                    idx++;
                    h.IDF = idx;
                    h.StatusFason = FasonExternoStatusManager.Status.Generada.ToString();
                    db.T0077_FASONEXT_H.Add(h);
                    var x = new SalesOrderStatusManager();
                }
                else
                {
                    var exist = db.T0077_FASONEXT_H.SingleOrDefault(c => c.IDF == h.IDF);
                    {

                    }
                }
                db.SaveChanges();
                return h.IDF;
            }
        }
    }
}
