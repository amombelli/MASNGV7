using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Vendor
{
    public class RendicionFF
    {
        public enum StatusRendicion
        {
            Temporal,
            Ingresado,
            Presentado,
            Contabilizado,
            Cancelado,
            Error
        }

        public List<T0135_GLX_FF> GetListGLforFF()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0135_GLX_FF.ToList();
            }
        }
        public int CreaRendicionHeader(T0406_RendicionFF_H header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var nuevoId = db.T0406_RendicionFF_H.Count(c => c.idRendicion > 0);
                header.idRendicion = nuevoId + 1;
                db.T0406_RendicionFF_H.Add(header);
                return db.SaveChanges() == 1 ? header.idRendicion : 0;
            }
        }
        public int CreaRendicionItems(List<T0407_RendicionFF_I> itemList)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                db.T0407_RendicionFF_I.AddRange(itemList);
                return db.SaveChanges();
            }
        }

        public List<T0406_RendicionFF_H> GetDataSourceAConvertir(string cuentaGL,
            StatusRendicion estado = StatusRendicion.Ingresado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (cuentaGL == null)
                {
                    return db.T0406_RendicionFF_H.Where(c => c.StatusRendicion == estado.ToString()).ToList();
                }
                else
                {
                    return
                        db.T0406_RendicionFF_H.Where(
                            c => c.RendicionCuentaGL == cuentaGL && c.StatusRendicion == estado.ToString()).ToList();
                }
            }
        }

        public T0406_RendicionFF_H GetDataRendicion(int idRendicion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0406_RendicionFF_H.SingleOrDefault(c => c.idRendicion == idRendicion);
            }
        }

        public List<T0407_RendicionFF_I> GetDataRendicionItems(int idRendicion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0407_RendicionFF_I.Where(c => c.idRendicion == idRendicion).ToList();
            }
        }

        public void UpdateRendicionAfterConversion(int idRendicion, string responsableConversion, int idCtaCte,
            int id403, int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0406_RendicionFF_H.SingleOrDefault(c => c.idRendicion == idRendicion);
                data.StatusRendicion = StatusRendicion.Contabilizado.ToString();
                data.idCtaCte = idCtaCte;
                data.id403 = id403;
                data.rendicionAprobadaPor = responsableConversion;
                data.numeroAsiento = numeroAsiento;
                db.SaveChanges();
            }
        }


    }
}
