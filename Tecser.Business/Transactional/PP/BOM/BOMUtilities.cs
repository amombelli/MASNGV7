using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure.BOM;

namespace Tecser.Business.Transactional.PP.BOM
{
    public class BOMUtilities
    {
        public List<EstructuraMPenFormula> GetBOMContieneMateriaPrima(string materiaPrima, bool soloActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lista = from items in db.T0021_FORMULA_I
                            where items.ITEM == materiaPrima
                            select new EstructuraMPenFormula()
                            {
                                MaterialFabricar = items.T0020_FORMULA_H.IDMATERIAL,
                                Componente = materiaPrima,
                                DescripcionFormula = items.T0020_FORMULA_H.DESC_FORMULA,
                                IdFormula = items.FORMULA,
                                UltimoUso = items.T0020_FORMULA_H.LastUsed,
                                Version = items.T0020_FORMULA_H.FORM_VERSION,
                                FormulaActiva = items.T0020_FORMULA_H.ACTIVA.Value
                            };

                if (soloActivo)
                    return lista.Where(c => c.FormulaActiva).ToList();
                return lista.ToList();

            }


        }



        public List<T0020_FORMULA_H> GetMaterialsManufacturedWithRawMaterial(string rawMaterial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listHeader =
                    db.T0020_FORMULA_H.Where(
                        c => c.T0021_FORMULA_I.Any(d => d.ITEM.ToUpper().Equals(rawMaterial.ToUpper()))).ToList();
                return listHeader;
            }
        }
        public bool RenameBomItem(int idFormula, string itemActual, string nuevoItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var formI =
                    db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula && c.ITEM.ToUpper().Equals(itemActual.ToUpper()))
                        .ToList();

                foreach (var x in formI)
                {
                    x.ITEM = nuevoItem;
                }

                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public bool RenameBomItemHistory(int idFormula, string itemActual, string nuevoItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0072_FORMULA_TEMP.Where(
                        c => c.NForm == idFormula && c.Primario.ToUpper().Equals(itemActual.ToUpper())).ToList();

                foreach (var i in data)
                {
                    i.Primario = nuevoItem;
                }

                var data2 =
                    db.T0073_FORMULA_PRINT.Where(
                        c => c.NForm == idFormula && c.Primario.ToUpper().Equals(itemActual.ToUpper())).ToList();

                foreach (var j in data2)
                {
                    j.Primario = nuevoItem;
                }

                if (db.SaveChanges() > 0)
                    return true;
                return false;

            }
        }
    }
}
