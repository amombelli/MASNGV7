using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;
namespace TecserSQL.Data.TransactionalData
{
    public class AsientoContable
    {
        public AsientoContable(string con)
        {
            GlobalApp.CnnApp = con;
        }

        private static class GlobalApp
        {
            public static string CnnApp;
        }

        public bool GrabaAsientoCompleto(T0601_DOCU_H header, List<T0602_DOCU_S> items)
        {

            GrabaHeader(header);
            GrabaItems(items);
            return true;
        }

        protected virtual void GrabaItems(List<T0602_DOCU_S> items)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                int xidDoc = 0;
                int xidSeg = 0;

                for (var i = 0; i < items.Count; i++)
                {
                    xidDoc = items[i].IDDOCU;
                    xidSeg = items[i].IDSEG;

                    var dataI =
                        db.T0602_DOCU_S.SingleOrDefault(c => c.IDDOCU == xidDoc && c.IDSEG == xidSeg);
                    if (dataI == null)
                    {
                        //Nuevo Segmento >> Create
                        db.T0602_DOCU_S.Add(items[i]);
                    }
                    else
                    {
                        //Segmento Existente >> Update
                        db.Entry(dataI).CurrentValues.SetValues(items[i]);
                    }

                }
                db.SaveChanges();
            }
        }

        public bool GrabaHeader(T0601_DOCU_H header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataH = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == header.IDDOCU);
                if (dataH != null)
                {
                    //Header ya existe >> actualizo
                    db.Entry(dataH).CurrentValues.SetValues(header);
                }
                else
                {
                    //Header no existe >> creo 
                    db.T0601_DOCU_H.Add(header);
                }
                return db.SaveChanges() > 0;
            }
        }

        public void GrabaItemEspecifico(T0602_DOCU_S item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataI = db.T0602_DOCU_S.SingleOrDefault(c => c.IDDOCU == item.IDDOCU && c.IDSEG == item.IDSEG);
                if (dataI != null)
                {
                    //Header ya existe >> actualizo
                    db.Entry(dataI).CurrentValues.SetValues(item);
                }
                else
                {
                    //Header no existe >> creo 
                    db.T0602_DOCU_S.Add(item);
                }
                db.SaveChanges();
            }
        }



    }


}
