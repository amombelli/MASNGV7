using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;
using TecserSQL.Data.SuperMD;

namespace Tecser.Business.SuperMD
{

    public class ZtermManager
    {

        public ZtermManager()
        {

        }


        /// <summary>
        /// Return cuando se tendria que estar cobranza (recibiendo la cobranza)
        /// </summary>
        public int GetCustomerZtermCobranzaDays(int idCliente, string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string zTermKey;
                var data = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (data == null)
                {
                    zTermKey = "0E";
                }
                else
                {
                    zTermKey = tipoLx == "L1" ? data.ZTERML1 : data.ZTERML2;
                }
                var zTermData = db.T0019_ZTERM.SingleOrDefault(c => c.ZTERM == zTermKey);
                return zTermData?.ZTERMDIASCOB ?? 0;
            }
        }

        public List<T0019_ZTERM> GetCompleteListOfZterms()
        {
            return new Repository<T0019_ZTERM>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        public T0019_ZTERM GetSpecificZtermData(string zterm, bool allowNull = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (string.IsNullOrEmpty(zterm))
                {
                    if (allowNull)
                    {
                        return null;
                    }
                    else
                    {
                        return db.T0019_ZTERM.SingleOrDefault(c => c.ZTERM == "0");
                    }
                }
                return db.T0019_ZTERM.SingleOrDefault(c => c.ZTERM == zterm);
            }
        }

        public string GetDescripcionZTerm(string zTerm)
        {
            var data = new Repository<T0019_ZTERM>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.ZTERM.Trim().ToUpper().Equals(zTerm.ToUpper()));
            if (data == null)
                return "Condicion No Encontrada";
            return data.ZTERMDESC;
        }

        public bool GuardaZterm(T0019_ZTERM structure)
        {
            return new Zterm(new TecserData(GlobalApp.CnnApp)).Create_UpdateObject(structure, GlobalApp.CnnApp);
        }
    }
}
