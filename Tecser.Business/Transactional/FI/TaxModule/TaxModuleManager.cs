using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.TaxModule
{
    public class TaxModuleManager
    {

        public List<T0016_TaxModuleDefinition> GetListaTax()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0016_TaxModuleDefinition.ToList();
            }
        }
        public T0016_TaxModuleDefinition GetTaxId(string taxid)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0016_TaxModuleDefinition.SingleOrDefault(c => c.IdTax.ToUpper().Equals(taxid.ToUpper()));
            }
        }
        public void SaveData(T0016_TaxModuleDefinition data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0016_TaxModuleDefinition.SingleOrDefault(c => c.IdTax == data.IdTax);
                if (x == null)
                {
                    db.T0016_TaxModuleDefinition.Add(data);
                }
                else
                {
                    db.Entry(x).CurrentValues.SetValues(data);
                }
                db.SaveChanges();
            }
        }
    }
}
