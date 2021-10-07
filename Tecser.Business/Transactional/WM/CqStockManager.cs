using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.WM
{
    public class CqStockManager
    {
        public List<GetStockDataSetCompleto_Result> GetCompleteCqList()
        {
            var b = new TecserData(GlobalApp.CnnApp).GetStockDataSetCompleto().ToList();
            return b;
        }

        public List<GetStockDataSetCompleto_Result> GetCompleteCqListFilterBySLOC(string sLoc)
        {
            //var a = new Repository<T0001_TRAN>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
            return new TecserData(GlobalApp.CnnApp).GetStockDataSetCompleto().Where(c => c.SLOC == sLoc).ToList();

        }

        public List<GetStockDataSetCompleto_Result> GetCQListMaterial_SLOC(string material, string sLoc)
        {

            return new TecserData(GlobalApp.CnnApp).GetStockDataSetCompleto().Where(c => c.Material == material && c.SLOC == sLoc).ToList();

        }
        public List<GetStockDataSetCompleto_Result> GetCqListByMaterial(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = db.GetStockDataSetCompleto().Where(c => c.Material == material).ToList();
                return result;
            }
        }

        public List<GetStockDataSetCompleto_Result> GetCqListByMaterialContains(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = db.GetStockDataSetCompleto().Where(c => c.Material.ToUpper().Contains(material.ToUpper())).ToList();
                return result;
            }
        }

        public List<GetStockDataSetCompleto_Result> GetCqListByLoteContains(string numeroLote)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = db.GetStockDataSetCompleto().Where(c => c.Lote.ToUpper().Contains(numeroLote.ToUpper())).ToList();
                return result;
            }
        }

    }
}
