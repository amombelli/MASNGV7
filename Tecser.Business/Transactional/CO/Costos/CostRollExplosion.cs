using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class StxCostoItemMemoria
    {
        public string material { get; set; }
        public string moneda { get; set; }
        public decimal repoARS { get; set; }
        public decimal repoUSD { get; set; }
        public DateTime fechaCosto { get; set; }
        public int LevelMax { get; set; }
    }



    public struct CostMini
    {
        public decimal ARS;
        public decimal USD;
        public decimal Porcentaje;
        public DateTime Fecha;
        public int LevelMax;
        public List<T0038_CostoMfgExplo> BomExplosion;
    }

    public class CostRollExplosion
    {
        private List<StxCostoItemMemoria> _listaCostoMP = new List<StxCostoItemMemoria>();
        private void AddRecordCostRoll(Guid guidCostRoll, DateTime costRollDate, string material, int? formulaId, decimal costoStd, decimal costoRepo, DateTime? stdDate = null, DateTime? repoDate = null, DateTime? pppDate = null)
        {
            if (stdDate == null)
                stdDate = DateTime.Today.AddYears(-5);

            if (repoDate == null)
                repoDate = DateTime.Today.AddYears(-5);

            if (pppDate == null)
                pppDate = DateTime.Today.AddDays(-5);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matH = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                var stx = new T0035_CostRoll()
                {
                    CostRollId = guidCostRoll,
                    CostRollDate = costRollDate,
                    Material = material,
                    ManualUpdated = false,
                    RecordAddedBy = GlobalApp.AppUsername,
                    RecordAddedOn = DateTime.Now,
                    MonedaCosto = matH.MonedaCosto,
                    MOrigen = matH.ORIGEN,
                    FCost = formulaId,
                    MType = matH.TIPO_MATERIAL,
                    CostoCR = costoStd,
                    CostoRepoUsd = costoRepo,
                    CostoCRDate = stdDate,
                    CostRepoDate = repoDate,
                    MaterialComplex = 0,
                };
            }
        }

        /// <summary>
        /// Funcion que llama a Recursiva - y actualiza tabla de costo T0035
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="material"> Use null value for all the materials</param>
        public int SetCostForManufacturedMaterial(Guid guid, string material, bool requiereRecursividad = true)
        {
            DateTime inicio = DateTime.Now;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                List<T0035_CostRoll> materialesCosto;
                if (material == null)
                {
                    materialesCosto = db.T0035_CostRoll.Where(c => c.MOrigen == "FAB").ToList();
                }
                else
                {
                    materialesCosto = db.T0035_CostRoll.Where(c => c.Material == material).ToList();
                }

                foreach (var materiales in materialesCosto)
                {
                    var rtnExplosion = LaMagia(materiales.Material, tc);
                    {
                        if (materiales.MonedaCosto == "USD")
                        {
                            materiales.CostoRepoUsd = rtnExplosion.USD;
                        }
                        else
                        {
                            materiales.CostoRepoUsd = rtnExplosion.ARS * tc;
                        }
                        materiales.CostRepoDate = rtnExplosion.Fecha;
                        materiales.RecordAddedOn = DateTime.Now;
                        materiales.MaterialComplex = rtnExplosion.LevelMax;
                        if (material != null)
                        {
                            //si se paso material por parametro es porque se esta actualizando el costo despues del CR
                            //materiales.ManualUpdated = true;
                            materiales.UpdatedAfterCR = true;
                            if (requiereRecursividad)
                            {
                                var usedBy = db.T0037_CostRollExplosionL1.Where(c => c.MaterialComponente == material)
                                    .ToList();
                                foreach (var xmaterial in usedBy)
                                {
                                    SetCostForManufacturedMaterial(guid, xmaterial.ProductoFabricado, false);
                                }
                            }
                        }
                        else
                        {
                            materiales.UpdatedAfterCR = false;
                        }
                        Debug.Print($"Material {materiales.Material} - Costo {materiales.CostoCR}");
                    }
                }
                db.SaveChanges();
                DateTime final = DateTime.Now;
                TimeSpan duracion = final - inicio;
                double segundosTotales = duracion.TotalSeconds;
                int segundos = duracion.Seconds;
                if (material == null)
                {
                    //Si se ejecuto para todos los materiales actualiza esta info en el Header
                    var costRollHeader = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == guid);
                    costRollHeader.RunTimeFabricado = (int)segundosTotales;
                    db.SaveChanges();
                }
                return (int)segundosTotales;
            }
        }
        public int RetornaRegistrosT0035Compras()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0035_CostRoll.Count(c => c.MOrigen != "FAB");
            }
        }
        public int RetornaRegistrosT0035Fabricados()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0035_CostRoll.Count(c => c.MOrigen == "FAB");
            }
        }
        public int RetornaRegistrosT0035()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0035_CostRoll.Count();
            }
        }
        public int RetornaRegistrosExplosion()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0037_CostRollExplosionL1.Count();
            }
        }
        public List<T0037_CostRollExplosionL1> GetExplosionMaterial(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0037_CostRollExplosionL1.Where(c => c.ProductoFabricado == material).ToList();
            }
        }
        /// <summary>
        /// Funcion principal recursiva para Costeo de Material Fabricado
        /// </summary>
        private CostMini LaMagia(string material, decimal tc)
        {
            if (tc <= 0)
                tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //A- Busca en Lista Memoria si ya tiene costo para este elemento que tiene que ser Fabricado
                var isInList = _listaCostoMP.SingleOrDefault(c => c.material == material);
                if (isInList != null)
                {
                    //Encontre el costo almancenado por lo tanto lo retorna sin ejecutar explosion
                    return new CostMini
                    {
                        ARS = isInList.repoARS,
                        USD = isInList.repoUSD,
                        Fecha = isInList.fechaCosto,
                        Porcentaje = 1,
                        LevelMax = isInList.LevelMax
                    };
                }
                //No tengo datos almancenados - Realiza la Explosion de Items
                var listaExplosion = db.T0037_CostRollExplosionL1.Where(c => c.ProductoFabricado == material).ToList();
                if (!listaExplosion.Any())
                {
                    //La formula no tiene ningun Item lo agrega a la lista para no volver a consultar
                    var tmp = new StxCostoItemMemoria()
                    {
                        material = material,
                        moneda = "USD",
                        repoUSD = GlobalApp.MaxCosto,
                        repoARS = GlobalApp.MaxCosto,
                        LevelMax = 99,
                        fechaCosto = DateTime.Today.AddDays(-10)
                    };

                    //Retorna valores maximos porue no tiene componentes a explotar
                    return new CostMini()
                    {
                        USD = tmp.repoUSD,
                        ARS = tmp.repoARS,
                        Fecha = tmp.fechaCosto,
                        LevelMax = tmp.LevelMax,
                        Porcentaje = 1
                    };
                }

                //Inicializa variable de Retorno donde acumulara los costos de los items
                //para obtener el costo final del Item - fecha base -5años
                var rtnCostoFinalAcumulado = new CostMini()
                {
                    ARS = 0,
                    USD = 0,
                    Fecha = DateTime.Today,
                    LevelMax = 0,
                    Porcentaje = 0
                };

                //Empieza a Recorrer los ITems de la explosion -->
                foreach (var itemBom in listaExplosion)
                {
                    //Busca si componente esta en lista memoria antes de inciar la busqueda en Db del costo
                    isInList = _listaCostoMP.SingleOrDefault(c => c.material == itemBom.MaterialComponente);
                    if (isInList != null)
                    {
                        //Se encontro el costo almacenado en memoria. --> Mapea desde Memoria
                        itemBom.CostoRepoArs = isInList.repoARS;
                        itemBom.CostoRepoUsd = isInList.repoUSD;
                        itemBom.FechaCosto = isInList.fechaCosto;
                        itemBom.CostoRepoArsProp = isInList.repoARS * itemBom.Proporcion;
                        itemBom.CostoRepoUsdProp = isInList.repoUSD * itemBom.Proporcion;
                        itemBom.FlagRepo = "M";
                        itemBom.FormulaComplex = isInList.LevelMax;
                        db.SaveChanges();

                        //Acumula costo unitario
                        rtnCostoFinalAcumulado.ARS += itemBom.CostoRepoArsProp;
                        rtnCostoFinalAcumulado.USD += itemBom.CostoRepoUsdProp;
                        rtnCostoFinalAcumulado.Porcentaje += itemBom.Proporcion;
                        //Actualiza siempre a la fecha mas antigua del item
                        if (rtnCostoFinalAcumulado.Fecha > itemBom.FechaCosto)
                            rtnCostoFinalAcumulado.Fecha = itemBom.FechaCosto;
                        //Actualiza FormulaComplex con el mayor valor de sus items
                        if (itemBom.FormulaComplex > rtnCostoFinalAcumulado.LevelMax)
                            rtnCostoFinalAcumulado.LevelMax = itemBom.FormulaComplex;
                        db.SaveChanges();
                    }
                    else
                    {
                        //El Costo del Item no esta en memoria.
                        if (itemBom.OrigenComponente != "FAB")
                        {
                            //Material es Comprado por lo tanto mapea desde Cost_Roll Table 
                            var itemTableCostRoll =
                                db.T0035_CostRoll.SingleOrDefault(c => c.Material == itemBom.MaterialComponente);
                            if (itemTableCostRoll == null)
                            {
                                //no encontro el costo ni en memoria ni en la Db
                                itemBom.CostoRepoArs = GlobalApp.MaxCosto;
                                itemBom.CostoRepoUsd = GlobalApp.MaxCosto;
                                itemBom.FechaCosto = DateTime.Today.AddYears(-10);
                                itemBom.CostoRepoArsProp = GlobalApp.MaxCosto;
                                itemBom.CostoRepoUsdProp = GlobalApp.MaxCosto;
                                itemBom.FlagRepo = "X";
                                itemBom.FormulaComplex = 50;
                            }
                            else
                            {
                                //Mapeamos el costo del material *comprado* desde Tabla CostRoll 
                                if (itemBom.MonedaCosto == "USD")
                                {
                                    itemBom.CostoRepoArs = itemTableCostRoll.CostoRepoUsd * tc;
                                    itemBom.CostoRepoUsd = itemTableCostRoll.CostoRepoUsd;
                                    itemBom.FechaCosto = itemTableCostRoll.CostRepoDate.Value;
                                    itemBom.CostoRepoArsProp = itemBom.CostoRepoArs * itemBom.Proporcion;
                                    itemBom.CostoRepoUsdProp = itemBom.CostoRepoUsd * itemBom.Proporcion;
                                    itemBom.FlagRepo = "R";
                                    itemBom.FormulaComplex = 0;
                                }
                                else
                                {
                                    itemBom.CostoRepoUsd = itemTableCostRoll.CostoRepoUsd / tc;
                                    itemBom.CostoRepoArs = itemTableCostRoll.CostoRepoUsd;
                                    itemBom.FechaCosto = itemTableCostRoll.CostRepoDate.Value;
                                    itemBom.CostoRepoArsProp = itemBom.CostoRepoArs * itemBom.Proporcion;
                                    itemBom.CostoRepoUsdProp = itemBom.CostoRepoUsd * itemBom.Proporcion;
                                    itemBom.FlagRepo = "R";
                                    itemBom.FormulaComplex = 0;
                                }
                            }

                            //agrego el costo a la lista a memoria para tenerla disponible luego
                            _listaCostoMP.Add(new StxCostoItemMemoria()
                            {
                                material = itemBom.MaterialComponente,
                                moneda = itemBom.MonedaCosto,
                                fechaCosto = itemBom.FechaCosto,
                                repoARS = itemBom.CostoRepoArs,
                                repoUSD = itemBom.CostoRepoUsd,
                                LevelMax = itemBom.FormulaComplex,
                            });

                            rtnCostoFinalAcumulado.ARS += itemBom.CostoRepoArsProp;
                            rtnCostoFinalAcumulado.USD += itemBom.CostoRepoUsdProp;
                            rtnCostoFinalAcumulado.Porcentaje += itemBom.Proporcion;
                            //Actualiza siempre a la fecha mas antigua del item
                            if (rtnCostoFinalAcumulado.Fecha > itemBom.FechaCosto)
                                rtnCostoFinalAcumulado.Fecha = itemBom.FechaCosto;
                            //Actualiza FormulaComplex con el mayor valor de sus items
                            if (itemBom.FormulaComplex > rtnCostoFinalAcumulado.LevelMax)
                                rtnCostoFinalAcumulado.LevelMax = itemBom.FormulaComplex;
                            db.SaveChanges();
                        }
                        else
                        {
                            //Material es Fabricado por lo tanto re-explota y retornar el valor
                            var costo = LaMagia(itemBom.MaterialComponente, tc);
                            if (costo.LevelMax >= 50)
                            {
                                //No Encontro explosion de formula para retornar
                                itemBom.CostoRepoArs = GlobalApp.MaxCosto;
                                itemBom.CostoRepoUsd = GlobalApp.MaxCosto;
                                itemBom.CostoRepoArsProp = GlobalApp.MaxCosto;
                                itemBom.CostoRepoUsdProp = GlobalApp.MaxCosto;
                                itemBom.FlagRepo = "J";
                                itemBom.FormulaComplex = costo.LevelMax;
                                itemBom.FechaCosto = DateTime.Now.AddYears(-5);
                            }
                            else
                            {
                                //La Formula se exploto y retorno un valor
                                itemBom.CostoRepoArs = costo.ARS;
                                itemBom.CostoRepoUsd = costo.USD;
                                itemBom.CostoRepoArsProp = itemBom.CostoRepoArs * itemBom.Proporcion;
                                itemBom.CostoRepoUsdProp = itemBom.CostoRepoUsd * itemBom.Proporcion;
                                itemBom.FlagRepo = "F";
                                itemBom.FormulaComplex = costo.LevelMax + 1; //aumento la complejidad en 1
                                itemBom.FechaCosto = costo.Fecha;

                                var tmpFab = new StxCostoItemMemoria()
                                {
                                    material = itemBom.MaterialComponente,
                                    repoARS = itemBom.CostoRepoArs,
                                    repoUSD = itemBom.CostoRepoUsd,
                                    moneda = itemBom.MonedaCosto,
                                    fechaCosto = itemBom.FechaCosto,
                                    LevelMax = itemBom.FormulaComplex,
                                };
                                _listaCostoMP.Add(tmpFab);
                            }

                            //Agregamos el costo de este material fabricado a la lista
                            //costo.LevelMax = costo.LevelMax;  //aca habia puesto +1
                            db.SaveChanges();
                            rtnCostoFinalAcumulado.ARS += itemBom.CostoRepoArsProp;
                            rtnCostoFinalAcumulado.USD += itemBom.CostoRepoUsdProp;
                            rtnCostoFinalAcumulado.LevelMax = costo.LevelMax;
                            rtnCostoFinalAcumulado.Porcentaje += itemBom.Proporcion;
                            if (rtnCostoFinalAcumulado.Fecha > itemBom.FechaCosto)
                                rtnCostoFinalAcumulado.Fecha = itemBom.FechaCosto;
                        }
                    }
                }
                rtnCostoFinalAcumulado.LevelMax++;
                return rtnCostoFinalAcumulado;
            }
        }
    }
}