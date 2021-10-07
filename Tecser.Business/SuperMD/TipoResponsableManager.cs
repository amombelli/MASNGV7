using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.SuperMD
{
    public class TipoResponsableTaxManager
    {
        public TipoResponsableTaxManager()
        {

        }

        /// <summary>
        /// Listado de Responsable inscripto, no inscripto, etc...
        /// </summary>
        /// <param name="soloActivo"></param>
        /// <returns></returns>
        public List<T0018_TIPORESP> GetCompleteTipoResponsableList(bool soloActivo = true)
        {
            if (soloActivo == true)
            {
                return new TecserData(GlobalApp.CnnApp).T0018_TIPORESP.Where(c => c.Activo == true).ToList();
            }
            else
            {
                return new Repository<T0018_TIPORESP>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
            }
        }

        public string GetDescripcionTipoResponsable(string idResponsable)
        {
            var data = new Repository<T0018_TIPORESP>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.IDTipoResponsable.Trim().ToUpper().Equals(idResponsable.ToUpper()));
            if (data == null)
                return "Descripcion no encontrada";
            return data.DESCRIPCION;
        }


        public string GetTaxIdFromDescription(string taxDescription)
        {
            var data = new Repository<T0018_TIPORESP>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.DESCRIPCION.Trim().Equals(taxDescription));
            if (data == null)
                return "??";
            return data.IDTipoResponsable;
        }

    }
}
