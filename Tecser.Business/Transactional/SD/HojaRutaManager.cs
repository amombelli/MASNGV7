using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class HojaRutaManager
    {
        public int CreaHojaRutaHeader(T0059_HOJARUTA_H data)
        {
            data.LogFecha = DateTime.Now;
            data.LogUser = Environment.UserName;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (db.T0059_HOJARUTA_H.SingleOrDefault(c => c.IdRuta == 1) == null)
                {
                    data.IdRuta = 1;
                }
                else
                {
                    data.IdRuta = db.T0059_HOJARUTA_H.Max(c => c.IdRuta) + 1;
                }

                db.T0059_HOJARUTA_H.Add(data);
                if (db.SaveChanges() > 0)
                    return data.IdRuta;
                return 0;
            }
        }
        public T0059_HOJARUTA_H GetHRutaData(int idHRuta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0059_HOJARUTA_H.SingleOrDefault(c => c.IdRuta == idHRuta);
            }
        }
        public List<T0059_HOJARUTA_H> GetListHojaRutas()
        {
            var top = 100;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0059_HOJARUTA_H.OrderByDescending(c => c.IdRuta).Take(top).ToList();
            }
        }
        public List<T0059_HOJARUTA_I> GetListRemitosEnHojaRuta(int idRuta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0059_HOJARUTA_I.Where(c => c.IdRuta == idRuta).OrderBy(c => c.OrdenEntrega).ToList();
            }
        }
        public void SubirPrioridad(int idRuta, int orden)
        {
            if (orden == 1)
                return; //no puede subir

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rutaAnterior =
                    db.T0059_HOJARUTA_I.Where(c => c.IdRuta == idRuta && c.OrdenEntrega == (orden - 1)).ToList();
                var ruta = db.T0059_HOJARUTA_I.Where(c => c.IdRuta == idRuta && c.OrdenEntrega == orden).ToList();
                rutaAnterior[0].OrdenEntrega = orden;
                ruta[0].OrdenEntrega = orden - 1;

                db.SaveChanges();
            }
        }
        public void BajarPrioridad(int idRuta, int orden)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ruta = db.T0059_HOJARUTA_I.Where(c => c.IdRuta == idRuta).ToList();
                var canItems = ruta.Count;
                if (orden == canItems)
                    return; //no puede bajar

                var data = db.T0059_HOJARUTA_I.SingleOrDefault(c => c.IdRuta == idRuta && c.OrdenEntrega == orden);
                var dataNext = ruta.Find(c => c.OrdenEntrega == orden + 1);
                dataNext.OrdenEntrega = orden;
                data.OrdenEntrega = orden + 1;
                db.SaveChanges();
            }
        }
        public void ConfirmacionHojaRuta(int idRuta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var HRItems = db.T0059_HOJARUTA_I.Where(c => c.IdRuta == idRuta).ToList();
                foreach (var item in HRItems)
                {
                    item.StatusEntrega = HojaRutaStatusManager.StatusItem.EnRutaOK.ToString();
                }

                var HRHeader = db.T0059_HOJARUTA_H.SingleOrDefault(c => c.IdRuta == idRuta);
                HRHeader.StatusRuta = HojaRutaStatusManager.StatusHeader.EnRuta.ToString();
                db.SaveChanges();
            }
        }
        public void CierreHojaRuta(int idRuta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0059_HOJARUTA_I.Where(c => c.IdRuta == idRuta).ToList();
                foreach (var it in data)
                {
                    if (it.StatusEntrega == HojaRutaStatusManager.StatusItem.EnRutaOK.ToString())
                    {
                        it.StatusEntrega = HojaRutaStatusManager.StatusItem.EntregadoOk.ToString();
                        var dataEntrega = db.T0059_ENTREGAS.SingleOrDefault(c => c.idRemito == it.IdRemito);
                        dataEntrega.StatusEntrega = EntregaStatusManager.Status.Finalizado.ToString();
                    }
                }

                var dataH = db.T0059_HOJARUTA_H.SingleOrDefault(c => c.IdRuta == idRuta);
                dataH.StatusRuta = HojaRutaStatusManager.StatusHeader.Finalizado.ToString();

                db.SaveChanges();


            }
        }

    }
}

