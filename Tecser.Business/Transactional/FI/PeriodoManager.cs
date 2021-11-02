using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class PeriodoManager
    {
        public bool checkPeriodoIsOpen(string periodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
            return true;
        }

        public bool OpenPeriodo(string periodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
            return true;
        }

        public bool ClosePeriodo(string periodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
            return true;
        }
    }
}
