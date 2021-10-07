using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.SuperMD
{
    public class TipoVendorManager
    {
        public TipoVendorManager()
        {


        }

        public List<T0014_TIPO_PROVEEDOR> GetCompleteListOfVendorType(bool onlyActive = true)
        {

            //No tiene implementado un flag activo asi que devuelve lo mismo
            if (onlyActive == true)
                return new Repository<T0014_TIPO_PROVEEDOR>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
            return new Repository<T0014_TIPO_PROVEEDOR>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        public string GetDescripcionTipoVendor(string tipoVendor)
        {
            var data =
                new Repository<T0014_TIPO_PROVEEDOR>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                    c => c.TIPOPROV.Trim().ToUpper().Equals(tipoVendor.ToUpper()));
            if (data == null)
                return "Descipcion no encontrada";
            return data.TIPOPROV_DESC;
        }
    }
}
