using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class StockOptimization : StockBase
    {

        /// <summary>
        /// Optimiza stock - Solo aplicable a estado LIBERADO/FE/RESTRINGIDO
        /// </summary>
        public void OptimizaStock(string material = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkdel = db.T0030_STOCK.Where(c => c.Stock == 0).ToList();
                var lineasRemove = stkdel.Count;
                db.T0030_STOCK.RemoveRange(stkdel);
                db.SaveChanges();

                var lst = new StockList().GetGroupByMaterialEstadoLoteUbicacion(material);
                foreach (var i in lst)
                {
                    if (i.Estado.ToUpper() == "LIBERADO" || i.Estado.ToUpper() == "FE" ||
                        i.Estado.ToUpper() == "RESTRINGIDO")
                    {
                        var stk = db.T0030_STOCK.Where(c => c.Material.ToUpper().Equals(i.Primario)
                                                            && c.Batch.Equals(i.Lote) &&
                                                            c.Estado.Equals(i.Estado) &&
                                                            c.SLOC.Equals(i.SLoc)).ToList();

                        if (stk.Count > 1)
                        {
                            stk[0].Stock = i.TotalKg;
                            for (var j = 1; j < stk.Count; j++)
                            {
                                db.T0030_STOCK.Remove(stk[j]);
                            }
                        }
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
