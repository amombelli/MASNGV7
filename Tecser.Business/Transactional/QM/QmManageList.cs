using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.QM
{
    public class QmManageList
    {
        public List<T0810_QMHeaderData> GetListQm()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0810_QMHeaderData.OrderByDescending(c => c.IDI).ToList();
            }
        }

        public T0810_QMHeaderData GetQmHeader(int idQm)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0810_QMHeaderData.SingleOrDefault(c => c.IDI == idQm);
            }

        }

        public List<T0811_QMDetailData> GetQmIpList(int idQm)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0811_QMDetailData.Where(c => c.IDPI == idQm).ToList();
            }
        }

        public T0811_QMDetailData GetInspectionDetail(int idQm, int counter)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0811_QMDetailData.SingleOrDefault(c => c.IDPI == idQm && c.COUNTER == counter);
            }
        }

        public T0800_QMMetodosInspeccion GetMetodo(string IdMetodoodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0800_QMMetodosInspeccion.SingleOrDefault(c => c.IdMetodo == IdMetodoodo);
            }
        }

        public List<T0800_QMMetodosInspeccion> GetMetodosInspAvailableToAddToInspection(int idQm)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaMetodos = db.T0800_QMMetodosInspeccion.ToList();
                var metodosAdded = db.T0811_QMDetailData.Where(c => c.IDPI == idQm).ToList();
                foreach (var x in metodosAdded)
                {
                    var mfind = listaMetodos.Find(c => c.IdMetodo == x.METODO);
                    listaMetodos.Remove(mfind);
                }
                return listaMetodos.ToList();
            }
        }

    }
}
