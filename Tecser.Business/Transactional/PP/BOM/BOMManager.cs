using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure.BOM;

namespace Tecser.Business.Transactional.PP
{

    //Todas las funciones relacionadas con la adminsitracion de una BOM

    public class BOMManager
    {

        /// <summary>
        /// Lista todos los materiales que tienen una BOM creada
        /// </summary>
        public List<string> GetListMaterialWithBOM()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0020_FORMULA_H.Select(c => c.IDMATERIAL).Distinct().ToList();
            }
        }
        public int GetNumberOfBOM(string materialPrimario, bool onlyActive = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive == true)
                {
                    var data =
                        db.T0020_FORMULA_H.Where(c => c.IDMATERIAL.ToUpper().Equals(materialPrimario.ToUpper()) && c.ACTIVA.Value == true)
                            .ToList().Count;
                    return data;
                }
                else
                {
                    var data =
                        db.T0020_FORMULA_H.Where(c => c.IDMATERIAL.ToUpper().Equals(materialPrimario.ToUpper()))
                            .ToList().Count;
                    return data;

                }
            }


        }
        public int GetBOMIdFormulaActiva(string materialPrimario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                try
                {
                    var data =
                        db.T0020_FORMULA_H.SingleOrDefault(
                            c => c.IDMATERIAL.ToUpper().Equals(materialPrimario.ToUpper()) && c.ACTIVA.Value == true)
                            .ID_FORMULA;

                    return data;
                }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
                catch (NullReferenceException e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
                {
                    throw new NullReferenceException();
                }
            }
        }
        public T0020_FORMULA_H GetFormulaHeader(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
            }
        }
        public List<T0021_FORMULA_I> GetFormulaItems(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();
            }
        }
        public List<T0020_FORMULA_H> GetListFormulasFromMaterial(string material, bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return onlyActive == true ? db.T0020_FORMULA_H.Where(c => c.IDMATERIAL.ToUpper().Equals(material.ToUpper()) && c.ACTIVA.Value).ToList() : db.T0020_FORMULA_H.Where(c => c.IDMATERIAL.ToUpper().Equals(material.ToUpper())).ToList();
            }
        }

        public List<StxBomHeaderWithCost> GetListFormulasFromMaterialWithCostStructure(string material, bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from h in db.T0020_FORMULA_H
                            where h.IDMATERIAL == material
                            select new StxBomHeaderWithCost()
                            {
                                IDMATERIAL = h.IDMATERIAL,
                                ACTIVA = h.ACTIVA,
                                Complex = 0,
                                MfgCostArs = 0,
                                MfgCostUsd = 0,
                                ID_FORMULA = h.ID_FORMULA,
                                DESC_FORMULA = h.DESC_FORMULA,
                                LastUsed = h.LastUsed,
                                FORM_VERSION = h.FORM_VERSION,
                            };
                if (onlyActive)
                    return query.Where(c => c.ACTIVA == true).ToList();
                return query.ToList();
            }
        }





        public void SetUltimoUso(int idBOM, DateTime fechaUso)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idBOM);
                x.LastUsed = fechaUso;
                db.SaveChanges();
            }

        }
        public void SetFormulaInactiva(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fx = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                fx.ACTIVA = false;
                fx.STATUS = "I" + DateTime.Today.ToString("yyyy MMMM dd");
                db.SaveChanges();
            }
        }
        public void SetFormulaActiva(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fx = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                fx.ACTIVA = true;
                fx.STATUS = "A" + DateTime.Today.ToString("yyyy MMMM dd");
                db.SaveChanges();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Listado de IDFormulas repetidos</returns>

        public List<int> FormulaExistente(string materialHeader, List<T0021_FORMULA_I> dataAdd, decimal margen = (decimal)0.01)
        {
            var xlist = new List<int>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var VersionesHeaderDisponible = db.T0020_FORMULA_H.Where(c => c.IDMATERIAL == materialHeader).ToList();
                if (VersionesHeaderDisponible.Count == 0)
                    return xlist; //Si el material a fabricar no tiene BOM - Seguro que no existe!

                foreach (var BomToAnalize in VersionesHeaderDisponible)
                {
                    var ItemsBomToAnalize = db.T0021_FORMULA_I.Where(c => c.FORMULA == BomToAnalize.ID_FORMULA).ToList();
                    foreach (var itemBomAdd in dataAdd)
                    {
                        bool encontrado = false;
                        var sublista = ItemsBomToAnalize.Where(c => c.ITEM == itemBomAdd.ITEM && c.ID_ITEM != 9998).ToList();
                        foreach (var sublista2 in sublista)
                        {
                            if (encontrado == false)
                            {
                                if (itemBomAdd.CANTIDAD_PORC.Value == sublista2.CANTIDAD_PORC.Value)
                                {
                                    sublista2.ID_ITEM = 9998; //flag no analizar nuevamente
                                    itemBomAdd.ID_ITEM = 994; //flag item encontrado
                                    encontrado = true;
                                }
                                else
                                {
                                    if (Math.Abs(itemBomAdd.CANTIDAD_PORC.Value - sublista2.CANTIDAD_PORC.Value) <=
                                        margen)
                                    {
                                        sublista2.ID_ITEM = 9998;
                                        itemBomAdd.ID_ITEM = 994;
                                        encontrado = true;
                                    }
                                }
                            }
                        }
                    }

                    if (ItemsBomToAnalize.Where(c => c.ID_ITEM != 9998).ToList().Count == 0)
                        xlist.Add(BomToAnalize.ID_FORMULA);
                }
                return xlist;
            }
        }

    }
}
