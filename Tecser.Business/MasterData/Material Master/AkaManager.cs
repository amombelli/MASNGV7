using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.Material_Master
{
    //nueva clase para manejar all related to AKAs
    public class AkaManager
    {
        public enum ModoCreacionAka
        {
            CopiaPrimario,
            CodigoLibre,
            TipoZrlb
        };

        public int RetornaCantidadAKA(string primario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var z = db.T0011_MATERIALES_AKA.Where(c => c.PRIMARIO.ToUpper().Equals(primario.ToUpper())).ToList();
                return z.Count;
            }
        }
        public bool CheckIfExistThisAKA(string primario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var z = db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(primario.ToUpper()));
                return z != null;
            }
        }
        public static string GetPrimario(string codigoVenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(codigoVenta.ToUpper()));
                if (x != null)
                    return x.PRIMARIO.ToUpper();

                var prim = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(codigoVenta.ToUpper()));
                if (prim != null)
                    return prim.IDMATERIAL.ToUpper();
                return null;
            }
        }
        public T0011_MATERIALES_AKA GetAkaInformation(string aka)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(aka.ToUpper()));
            }
        }
        public List<T0011_MATERIALES_AKA> GetListAkaFromPrimario(string primario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0011_MATERIALES_AKA.Where(c => c.PRIMARIO.ToUpper().Equals(primario.ToUpper())).ToList();
            }
        }
        public bool UpdateAkaData(T0011_MATERIALES_AKA aka)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var akaData = db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(aka.CODVENTA.ToUpper()));
                if (akaData == null)
                {
                    aka.LOGUSER = GlobalApp.AppUsername;
                    aka.FECHA = DateTime.Now;
                    db.T0011_MATERIALES_AKA.Add(aka);
                }
                else
                {
                    db.Entry(akaData).CurrentValues.SetValues(aka);
                    aka.LOGUSER = GlobalApp.AppUsername;
                    aka.FECHA = DateTime.Now;
                }
                return db.SaveChanges() > 0;
            }
        }
    }
}
