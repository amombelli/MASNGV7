using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.SuperMD
{

    /// <summary>
    /// Este file hay que elmiminarlo por completo -
    /// reemplazando con lo que ya esta implementado
    /// </summary>

    public class HumanResourcesManager
    {

        //-----------------------------------------------------------------------------------------------------------------
  //-----------------------------------------------------------------------------------------------------------------

        public static T0086_HHRR_POSICIONES GetPosicioneData(int idPosicion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0086_HHRR_POSICIONES.SingleOrDefault(c => c.IDPOSICION == idPosicion);
            }
        }
       
        
        public List<T0085_PERSONAL> GetListEmployees(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                {
                    return db.T0085_PERSONAL.Where(c => c.ACTIVO == true).ToList();
                }
                else
                {
                    return db.T0085_PERSONAL.ToList();
                }
            }
        }


        public T0085_PERSONAL GetEmployeeDataByShortname(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0085_PERSONAL.SingleOrDefault(c => c.SHORTNAME.ToUpper().Equals(shortname.ToUpper()));
            }
        }
    


        //de aca para abajo son viejas...
        public List<T0085_PERSONAL> GetListPermiteDespacho()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(
                    c => c.ACTIVO == true && c.PERMITE_DESPACHO.Value == true)
                    .OrderBy(c => c.SHORTNAME)
                    .ToList();
        }
        public List<T0085_PERSONAL> GetListAllActiveVendedor()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(c => c.ACTIVO == true && c.PERMITE_VENTA == true)
                    .OrderBy(c => c.SHORTNAME)
                    .ToList();
        }
        public List<T0085_PERSONAL> GetListAllActiveOperario()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(c => c.ACTIVO == true && c.PERMITE_OPERARIO == true)
                    .OrderBy(c => c.SHORTNAME)
                    .ToList();
        }
        public List<T0085_PERSONAL> GetListAllActiveCobrador()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(c => c.ACTIVO == true && c.PERMITE_COBRANZA == true)
                    .OrderBy(c => c.SHORTNAME)
                    .ToList();
        }
        public List<T0085_PERSONAL> GetListAllActivePermiteControlIc()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(c => c.ACTIVO == true && c.PermiteIngresoIC == true)
                    .OrderBy(c => c.SHORTNAME).ToList();
        }

    }
}
