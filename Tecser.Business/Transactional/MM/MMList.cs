using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class MMList
    {


        public List<T0040_MAT_MOVIMIENTOS> GetCompleteListWithDate(DateTime dateI, DateTime? dateF = null,
            int maxRecord = 500)
        {
            DateTime dateFinal;
            if (dateF == null)
            {
                dateFinal = DateTime.Today;
            }
            else
            {
                dateFinal = (DateTime)dateF;
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d =
                    db.T0040_MAT_MOVIMIENTOS.Where(c => c.FECHAMOV >= dateI && c.FECHAMOV <= dateFinal)
                        .Take(maxRecord)
                        .OrderByDescending(c => c.IDMOVIMIENTO);
                return d.ToList();
            }
        }

        public List<T0040_MAT_MOVIMIENTOS> GetCompleteListWithDateMaterial(string idMaterial, DateTime dateI,
            DateTime? dateF = null, int maxRecord = 500)
        {
            DateTime dateFinal;
            if (dateF == null)
            {
                dateFinal = DateTime.Today;
            }
            else
            {
                dateFinal = (DateTime)dateF;
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d =
                    db.T0040_MAT_MOVIMIENTOS.Where(
                        c =>
                            c.IDMATERIAL.ToUpper() == idMaterial.ToUpper() && c.FECHAMOV >= dateI &&
                            c.FECHAMOV <= dateFinal)
                        .Take(maxRecord)
                        .OrderByDescending(c => c.IDMOVIMIENTO);
                return d.ToList();
            }
        }
    }
}
