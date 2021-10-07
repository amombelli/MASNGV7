using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable
{
    public class ManageFB01
    {

        public T0601_DOCU_H RetornaHeader(int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == numeroAsiento);
            }
        }
        public List<T0602_DOCU_S> RetornaSegnmentos(int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0602_DOCU_S.Where(c => c.IDDOCU == numeroAsiento).ToList();
            }
        }
        public T0602_DOCU_S GetSegmento(int numeroAsiento, int idSegmento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0602_DOCU_S.SingleOrDefault(c => c.IDDOCU == numeroAsiento && c.IDSEG == idSegmento);
            }
        }

        public void UpdateGL_Segmento(int numeroAsiento, int idSegmento, string newGL)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0602_DOCU_S.SingleOrDefault(c => c.IDDOCU == numeroAsiento && c.IDSEG == idSegmento);
                data.GLORI = data.GL;
                data.GL = newGL;
                data.UPDUSER = GlobalApp.AppUsername;
                data.ST = "M"; //Modificado
                db.SaveChanges();

            }
        }

    }
}
