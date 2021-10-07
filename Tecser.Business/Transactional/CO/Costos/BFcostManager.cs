using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{

    /// <summary>
    /// Clase para adminsitrar ABM de datos en T0037
    ///2021.01.15
    /// </summary>
    public class BFcostManager
    {
        public BFcostManager()
        {

        }

        /// <summary>
        /// Actualiza en T0010 - FCOST y Moneda
        /// </summary>
        /// <returns>
        /// False si no se pudo realizar el seteo
        /// </returns>
        public bool SetFcostInMaterialMaster(string material, int? fCostId, string moneda = "USD")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (fCostId == null)
                {
                    //Retirar Fcost
                    return true;
                }
                else
                {
                    var formulaData = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == fCostId);
                    if (formulaData == null) return false; //formula no existe
                    if (formulaData.IDMATERIAL != material) return false; //el FCostId proporcionado no corresponde a formula para material provisto
                    var matData = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == formulaData.IDMATERIAL);
                    if (matData.MonedaCosto == null)
                    {
                        matData.MonedaCosto = string.IsNullOrEmpty(moneda) ? "USD" : moneda;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(moneda))
                        {
                            matData.MonedaCosto = moneda;
                        }
                    }
                    matData.FORM_COSTO = fCostId;
                }
                db.SaveChanges();

                var xstd = db.T0039_CostoStandard.SingleOrDefault(c => c.Material == material);
                if (xstd == null)
                {
                    //no existe datos en la estructura de costo standard
                    //Dar de alta el material con costo de repomfg uc
                    //no hace falta avisar que el costo se modifico pq no es componente de ningun
                    //material existente
                }
                else
                {
                    //hay que actualizar los datos. - yo pondria el costo de repomfg uc
                    //indicando que el costo std se cambio despues de ejecutar el costroll
                    //en CR header trackear si hay cambios de materia prima UC
                    //y trackear si hay modificacion de un FCOST
                    //si un material se agregar NUEVO agregarlo sin avisar porque no sera componenete
                    //de ningun mateairal existente
                }

            }





            ManageMfgCostHeaderStructure(material);  //actualiza estructura de costo T0037
            //falta costear!!!

            //GetCostBomItemsWithUpdateStructure(idFormula, moneda, false);
            //
            return true;
        }


        private bool ManageMfgCostHeaderStructure(string material)
        {
            //esta funcion sacarla porque se va a ir la tabla T0037!! 
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matData = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                if (matData == null) return false;

                if (matData.MonedaCosto == null)
                {
                    matData.MonedaCosto = "USD";
                    db.SaveChanges();
                }

                decimal xRate = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                var dataH = db.T0037_CostoMfg.SingleOrDefault(c => c.Material == material);

                if (dataH == null)
                {
                    //no hay estrctura de costo Mfg
                }


                if (matData.FORM_COSTO == null || matData.FORM_COSTO <= 0)
                {
                    //No Existe FCost asignado en material master -->Setea en MAX
                    if (dataH != null)
                    {
                        //update info
                        dataH.MonedaCosto = matData.MonedaCosto;
                        dataH.FCost = -1;
                        dataH.UpdateFCost = DateTime.Now;
                        dataH.LastRun = DateTime.Now;
                        dataH.CostDateStd = DateTime.Now;
                        dataH.CostDateRepo = DateTime.Now;
                        dataH.MfgArsStd = (decimal)999999.99;
                        dataH.MfgUsdStd = (decimal)999999.99;
                        dataH.MfgArsRepo = (decimal)999999.99;
                        dataH.MfgUsdRepo = (decimal)999999.99;
                        dataH.LevelMax = 0;
                    }
                    else
                    {
                        //no existia estructura de costos genera info con valor maximo
                        var data = new T0037_CostoMfg()
                        {
                            //crea datos
                            Material = material,
                            MonedaCosto = matData.MonedaCosto,
                            Origen = matData.ORIGEN,
                            FCost = -1,
                            CostDateRepo = DateTime.Now,
                            CostDateStd = DateTime.Now,
                            LevelMax = 0,
                            MfgArsRepo = (decimal)999999.99,
                            MfgArsStd = (decimal)999999.99,
                            MfgUsdRepo = (decimal)999999.99,
                            MfgUsdStd = (decimal)999999.99,
                            TCCalculo = xRate,
                            UpdateFCost = DateTime.Now,
                            LastRun = DateTime.Now,
                        };
                        db.T0037_CostoMfg.Add(data);
                    }
                }
                else
                {
                    //Existe en el MM un FCost Asignado
                    if (dataH != null)
                    {
                        //update info porque existe en la estructura
                        dataH.MonedaCosto = matData.MonedaCosto;
                        dataH.FCost = matData.FORM_COSTO.Value;
                        dataH.UpdateFCost = DateTime.Now;
                        dataH.LastRun = DateTime.Now;
                        dataH.CostDateStd = DateTime.Now;
                        dataH.CostDateRepo = DateTime.Now;
                        dataH.MfgArsStd = (decimal)999999.99;
                        dataH.MfgUsdStd = (decimal)999999.99;
                        dataH.MfgArsRepo = (decimal)999999.99;
                        dataH.MfgUsdRepo = (decimal)999999.99;
                        dataH.LevelMax = 0;
                    }
                    else
                    {
                        //no existia estructura de costos genera info con valor maximo
                        var data = new T0037_CostoMfg()
                        {
                            //crea datos
                            Material = material,
                            MonedaCosto = matData.MonedaCosto,
                            Origen = matData.ORIGEN,
                            FCost = matData.FORM_COSTO.Value,
                            CostDateRepo = DateTime.Now,
                            CostDateStd = DateTime.Now,
                            LevelMax = 0,
                            MfgArsRepo = (decimal)999999.99,
                            MfgArsStd = (decimal)999999.99,
                            MfgUsdRepo = (decimal)999999.99,
                            MfgUsdStd = (decimal)999999.99,
                            TCCalculo = xRate,
                            UpdateFCost = DateTime.Now,
                            LastRun = DateTime.Now,
                        };
                        db.T0037_CostoMfg.Add(data);
                    }
                }
                db.SaveChanges();
                return true;
            }
        }
    }
}

