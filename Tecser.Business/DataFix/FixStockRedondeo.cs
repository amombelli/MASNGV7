using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class FixStockRedondeo
    {
        public void FixRedondeoStock()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0030_STOCK.ToList();
                foreach (var item in d)
                {
                    item.Stock = Math.Round(item.Stock, 2);
                    db.SaveChanges();
                }

                d = db.T0030_STOCK.Where(c => c.Stock < (decimal)0.1).ToList();
                {
                    db.T0030_STOCK.RemoveRange(d);
                    var rec = db.SaveChanges();
                    if (rec > 0)
                    {
                        MessageBox.Show($@"Se han eliminado {rec} registros!");
                    }
                }
                MessageBox.Show(@"Listo");
            }
        }
    }
}
