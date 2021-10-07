using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    public class PeriodoAvailability
    {
        public DateTime FechaPeriodo { get; private set; }
        public bool CheckPeriodoOpenFI(DateTime fechaOperacion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = new PeriodoConversion().GetPeriodo(fechaOperacion);
                var data = db.T0138_PERIODOS.SingleOrDefault(c => c.PERIODO == r);
                if (data == null)
                    return false;

                if (data.PERMITE_FI == true)
                    return true;
                return false;
            }
        }
        public bool OpenPeriodoFI(string yyyymm)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0138_PERIODOS.SingleOrDefault(c => c.PERIODO == yyyymm);
                if (data == null)
                    return false;

                data.PERMITE_FI = true;
                return db.SaveChanges() > 0;
            }
        }
        public bool ClosePeriodoFI(string yyyymm)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0138_PERIODOS.SingleOrDefault(c => c.PERIODO == yyyymm);
                if (data == null)
                    return false;

                data.PERMITE_FI = false;
                return db.SaveChanges() > 0;
            }
        }




    }
}
