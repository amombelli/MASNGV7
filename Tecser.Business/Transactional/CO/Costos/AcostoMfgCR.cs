using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CO.Costos
{
    /// <summary>
    /// Revision 2021.06.01
    /// Clase para menajar la completitud de los costos de MFG para el Cost Roll
    /// Se usa como datos los de T0035_COSTROLL
    /// </summary>
    public class AcostoMfgCr
    {
        private decimal? _tc;
        private const decimal CostoMax = (decimal)999999.99;
        public AcostoMfgCr(decimal? tc = null)
        {
            _tc = tc;
            CostType = ACosto.CostType.CostRoll;
        }
        public ACosto.CostType CostType { get; protected set; }
        public List<CostItems> CostItems { get; protected set; }
        public List<CostHeader> CostHeader { get; protected set; }
        private List<CostHeader> StoredMaterials { get; set; } //Lista para el manejo de todos los materiales que se van costeando (MP/PM,...)
        
        public void GetCostXplodAll(string material = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (_tc==null)
                    _tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                var materialesCostear = material == null
                    ? db.T0035_CostRoll.Where(c => c.MOrigen == "FAB").ToList()
                    : db.T0035_CostRoll.Where(c => c.Material == material && c.MOrigen == "FAB").ToList();

                foreach (var mat in materialesCostear)
                {
                    var costoReturn = ExplotaToLevelX(mat.Material, mat.FCost);
                    mat.MonedaCosto = "USD";
                    mat.CostoRepoUsd = Math.Round(costoReturn.CostoUsd, 4);
                    mat.CostoCR = mat.CostoRepoUsd;
                    mat.MaterialComplex = costoReturn.LevelMax;
                    mat.CostRepoDate = costoReturn.FechaCosto;
                    Debug.Print($"Retorno costo {mat.Material} = USD {Math.Round(mat.CostoRepoUsd, 4)} - Resultado {costoReturn.CalculoOk} +++ LevelMax {costoReturn.LevelMax}");
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Revision 2021.06.01
        /// Funcion explota costos guardando los 'sub-productos' en memoria para un rapido acceso
        /// Permite IDFormula null en caso que un producto no tenga la FCOST cargada
        /// </summary>
        private CostHeader ExplotaToLevelX(string material, int? idFormula, decimal multiplicador = 1)
        {
            decimal costoAcc = 0;
            decimal costoSp = 0;
            bool calculoOK = true;
            int nivelExplosion = 0;
            DateTime fechaCostoOlder = DateTime.Today.AddYears(+5);
            
            if (idFormula == null) idFormula = -1; //manejo de producto con formula null.

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (StoredMaterials == null) StoredMaterials = new List<CostHeader>();

                var materialReuse = StoredMaterials.Find(c => c.Material == material);
                if (materialReuse != null)
                {
                    //El material a analizar ya se encuentra en la lista de Reuse con costo
                    return new CostHeader()
                    {
                        Moneda = "USD",
                        CalculoOk = materialReuse.CalculoOk,
                        Material = material,
                        CostoUsd = materialReuse.CostoUsd,
                        Fcost = idFormula,
                        Origen = materialReuse.Origen,
                        FechaCosto = materialReuse.FechaCosto,
                        LevelMax = materialReuse.LevelMax,
                    };
                }
                else
                {
                    //** Ingreso a funcion normal para explosion de Formula -->
                    var f0 = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                    if (f0 == null)
                    {
                        //Formula NO Existe agrega a lista de MP costoMax (En caso de Fcost Inexistente o nulo -->Error!)
                        var s1 = new CostHeader()
                        {
                            Material = material,
                            LevelMax = 100,
                            CostoUsd = CostoMax,
                            FechaCosto = DateTime.Today.AddYears(-5),
                            Origen = "XXX",
                            CalculoOk = false,
                            Moneda = "USD",
                            Fcost = idFormula,
                        };
                        StoredMaterials.Add(s1);
                        nivelExplosion = 100;
                        calculoOK = false;
                        fechaCostoOlder = DateTime.Today.AddYears(-5);
                        costoSp += CostoMax;
                    }
                    else
                    {
                        //Ingreso Principal -->Explosion de Material Header en Lista de Items
                        var fi = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();
                        int a = 0;
                        foreach (var i in fi)
                        {
                            //Si el Item de la Formula esta en memoria retorna el item sin calcular nada
                            //a++;
                            Debug.Print($"Explotando Material: {material} - ({a}) MP> {i.ITEM}");
                            materialReuse = StoredMaterials.Find(c => c.Material == i.ITEM);
                            if (materialReuse != null)
                            {
                                //Item en memoria retorna directo el valor
                                var explo = new CostItems()
                                {
                                    Moneda = "USD",
                                    MaterialF = f0.IDMATERIAL,
                                    ItemMP = i.ITEM,
                                    Prop = multiplicador * i.CANTIDAD_PORC.Value,
                                    CostoProp = materialReuse.CostoUsd * multiplicador * i.CANTIDAD_PORC.Value,
                                    CostoUnit = materialReuse.CostoUsd,
                                    CostoFound = materialReuse.CalculoOk,
                                };
                                CostItems.Add(explo);
                                costoAcc += explo.CostoProp;
                                costoSp += (materialReuse.CostoUsd * i.CANTIDAD_PORC.Value);
                                if (materialReuse.FechaCosto < fechaCostoOlder)
                                    fechaCostoOlder = materialReuse.FechaCosto;
                                if (materialReuse.Origen == "FAB")
                                    nivelExplosion = materialReuse.LevelMax; //revisar esto borre el -1!
                            }
                            else
                            {
                                if (i.T0010_MATERIALES == null)
                                {
                                    //Correccion de posible _BUG en el que el item no existe en T0010
                                    var explo = new CostItems()
                                    {
                                        Moneda = "USD",
                                        MaterialF = i.ITEM,
                                        ItemMP = i.ITEM,
                                        Prop = multiplicador * i.CANTIDAD_PORC.Value,
                                        CostoProp = CostoMax,
                                        CostoUnit = CostoMax,
                                        CostoFound = false,
                                    };
                                    CostItems.Add(explo);
                                    var s1 = new CostHeader()
                                    {
                                        Material = material,
                                        LevelMax = 100,
                                        CostoUsd = CostoMax,
                                        FechaCosto = DateTime.Today.AddYears(-5),
                                        Moneda = "USD",
                                        Origen = "XXX",
                                        Fcost = 0,
                                        CalculoOk = false
                                    };
                                    StoredMaterials.Add(s1);
                                    nivelExplosion = 100;
                                    calculoOK = false;
                                    fechaCostoOlder = DateTime.Today.AddYears(-5);
                                    costoSp += CostoMax;
                                    costoAcc += CostoMax;
                                }
                                else
                                {
                                    //-> El costo no esta en Memoria dependiendo el origen re-explota o
                                    //busca el costo en T0035-CR
                                    if (i.T0010_MATERIALES.ORIGEN == "FAB")
                                    {
                                        if (i.T0010_MATERIALES.FORM_COSTO == null ||
                                            i.T0010_MATERIALES.FORM_COSTO.Value <= 0)
                                        {
                                            //FAB pero formula inexistente
                                            var explo = new CostItems()
                                            {
                                                Moneda = "USD",
                                                MaterialF = i.ITEM,
                                                ItemMP = i.ITEM,
                                                Prop = multiplicador * i.CANTIDAD_PORC.Value,
                                                CostoProp = CostoMax,
                                                CostoUnit = CostoMax,
                                                CostoFound = false,
                                            };
                                            CostItems.Add(explo);
                                            var s1 = new CostHeader()
                                            {
                                                Material = material,
                                                LevelMax = 100,
                                                CostoUsd = CostoMax,
                                                FechaCosto = DateTime.Today.AddYears(-5),
                                                Moneda = "USD",
                                                Origen = "FAB",
                                                Fcost = -1,
                                                CalculoOk = false
                                            };
                                            StoredMaterials.Add(s1);
                                            costoAcc += CostoMax;
                                            costoSp += CostoMax;
                                            nivelExplosion = 100;
                                            calculoOK = false;
                                        }
                                        else
                                        {
                                            //fabricado - vuelve a re-explotar
                                            var retornoRecursivo = ExplotaToLevelX(i.ITEM, MaterialMasterManager.GetFCost(i.ITEM),
                                                i.CANTIDAD_PORC.Value * multiplicador);

                                            costoAcc += (retornoRecursivo.CostoUsd * i.CANTIDAD_PORC.Value * multiplicador);
                                            costoSp += (retornoRecursivo.CostoUsd * i.CANTIDAD_PORC.Value);
                                            if (retornoRecursivo.CalculoOk == false)
                                                calculoOK = false;
                                            nivelExplosion = nivelExplosion + (retornoRecursivo.LevelMax);
                                            if (fechaCostoOlder > retornoRecursivo.FechaCosto)
                                                fechaCostoOlder = retornoRecursivo.FechaCosto;
                                        }
                                    }
                                    else
                                    {
                                        //material ya es MP
                                        var crData = db.T0035_CostRoll.SingleOrDefault(c => c.Material == i.ITEM);
                                        decimal costo;
                                        string origen;
                                        DateTime fecha;
                                        bool mpFound;
                                        if (crData != null)
                                        {
                                            costo = crData.CostoCR;
                                            fecha = crData.CostRepoDate.Value;
                                            origen = crData.MOrigen;
                                            mpFound = true;
                                        }
                                        else
                                        {
                                            costo = CostoMax;
                                            fecha = DateTime.Today.AddYears(-5);
                                            origen = "XXX";
                                            mpFound = false;
                                        }
                                        var explo = new CostItems()
                                        {
                                            Moneda = "USD",
                                            MaterialF = i.T0020_FORMULA_H.IDMATERIAL,
                                            ItemMP = i.ITEM,
                                            Prop = multiplicador * i.CANTIDAD_PORC.Value,
                                            CostoProp = costo * multiplicador * i.CANTIDAD_PORC.Value,
                                            CostoUnit = costo,
                                            CostoFound = mpFound,
                                        };
                                        if (costo == CostoMax) explo.CostoProp = CostoMax;
                                        if (CostItems == null)
                                            CostItems = new List<CostItems>();
                                        CostItems.Add(explo);
                                        var s1 = new CostHeader()
                                        {
                                            Material = i.ITEM,
                                            LevelMax = 0,
                                            CostoUsd = costo,
                                            FechaCosto = fecha,
                                            Moneda = "USD",
                                            Origen = origen,
                                            Fcost = 0,
                                            CalculoOk = mpFound
                                        };
                                        StoredMaterials.Add(s1);
                                        costoAcc += explo.CostoProp;
                                        costoSp += (costo * i.CANTIDAD_PORC.Value);
                                        if (fechaCostoOlder > fecha) fechaCostoOlder = fecha;
                                        if (mpFound == false)
                                            calculoOK = false;
                                    }
                                }
                            }
                        }

                        if (CostHeader == null) CostHeader = new List<CostHeader>();
                        var costoH = new CostHeader()
                        {
                            Moneda = "USD",
                            Material = f0.IDMATERIAL,
                            CostoUsd = costoSp,
                            CalculoOk = calculoOK,
                            Fcost = f0.ID_FORMULA,
                            Origen = "FAB",
                            LevelMax = nivelExplosion + 1,
                            FechaCosto = fechaCostoOlder
                        };
                        CostHeader.Add(costoH);

                        var sf = new CostHeader()
                        {
                            Material = f0.IDMATERIAL,
                            LevelMax = nivelExplosion + 1,
                            CostoUsd = costoSp,
                            FechaCosto = fechaCostoOlder,
                            Moneda = "USD",
                            Origen = "FAB",
                            Fcost = idFormula,
                            CalculoOk = calculoOK
                        };
                        StoredMaterials.Add(sf);
                    }
                }
            }
            //Salida de Explosion del Material/Submaterial y Regreso al Nivel Anterior (recursivo padre-->)
            nivelExplosion++;
            return new CostHeader()
            {
                Material = material,
                Moneda = "USD",
                CostoUsd = costoSp,
                Origen = "FAB",
                CalculoOk = calculoOK,
                Fcost = idFormula,
                LevelMax = nivelExplosion,
                FechaCosto = fechaCostoOlder
            };
        }
    }
}