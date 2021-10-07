using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.SuperMD
{
    public class TaxDataManager
    {
        public TaxDataManager()
        {

        }

        public List<T0190_TAX> GetCompleteListOfTTax()
        {
            return new Repository<T0190_TAX>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        public string GetTaxDescription(string taxId)
        {
            var data = new Repository<T0190_TAX>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.TTAX.Trim().Equals(taxId));
            if (data == null)
                return "Descripcion no encontrada";
            return data.TAXDESC;
        }


        /// <summary>
        /// Lista de Tax Retenciones/Percepciones para Combobox.
        /// </summary>
        /// <returns></returns>
        public List<TTAXRetPerConfig> GetListaTaxRetPer(string pc)
        {
            if (pc.ToUpper() == "C")
            {
                return
                    new Repository<TTAXRetPerConfig>(new TecserData(GlobalApp.CnnApp)).GetAll()
                        .Where(c => c.DisponibleCliente == true)
                        .ToList();
            }
            else
            {
                return
                    new Repository<TTAXRetPerConfig>(new TecserData(GlobalApp.CnnApp)).GetAll()
                        .Where(c => c.DisponibleVendor == true)
                        .ToList();
            }
        }


        public List<TTAXRetGananciasConfig> GetListaConceptosRetencionGS()
        {
            return
                new Repository<TTAXRetGananciasConfig>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }


        public TTAXRetGananciasConfig GetValorRetGanancias(int idRetencion)
        {
            return
                new Repository<TTAXRetGananciasConfig>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                    c => c.ConceptoId == idRetencion);
        }

    }

}
