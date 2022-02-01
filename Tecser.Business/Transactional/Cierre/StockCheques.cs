using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.Cierre
{
    public class StockCheques
    {

        public List<TsCheques1> GetAvailableOnDate(DateTime fechaMaxima,string lx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                
                //Genera la tabla base
                var x = new ChequesManager().GetListaChequesFiltrada(lx, true, false, fechaRecibidoFinal: fechaMaxima);
                var l2 = new ChequesManager().GetListaChequesFiltrada(lx, false, true, fechaRecibidoFinal: fechaMaxima)
                    .Where(c => c.FechaEntregado > fechaMaxima).ToList();
                x.AddRange(l2);
                return x.ToList();
            }
        }
    }
}
