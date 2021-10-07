using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.SuperMD
{
    public class StockEstadoManager
    {
        public List<T0029_ESTADO_STOCK> GetListOfEstados()
        {
            return new TecserData(GlobalApp.CnnApp).T0029_ESTADO_STOCK.ToList();
        }
        public List<T0029_ESTADO_STOCK> GetListEstadoDisponibleIc()
        {
            return
                new Repository<T0029_ESTADO_STOCK>(new TecserData(GlobalApp.CnnApp)).Find(c => c.AvailableStateForIC == true).ToList();
        }

        public List<T0029_ESTADO_STOCK> GetListEstadoDisponibleEs()
        {
            return new TecserData(GlobalApp.CnnApp).T0029_ESTADO_STOCK.Where(c => c.AvailableStateForIP).ToList();
        }
        public string GetEstadoDefaultProduccion()
        {
            var x = new TecserData(GlobalApp.CnnApp).T0029_ESTADO_STOCK.Where(c => c.DefaultStateIP).ToList();
            return x[0].ESTADO;

        }

    }
}
