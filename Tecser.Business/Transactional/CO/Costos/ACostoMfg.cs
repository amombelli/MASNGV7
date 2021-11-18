using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData.BOM;
using Tecser.Business.SuperMD;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CO.Costos
{

    /// <summary>
    /// Clase abstractra de Costo de Producto Manufactura
    /// Revision 2021.01.18
    /// </summary>
    public abstract class ACostoMfg : ACosto
    {
        protected ACostoMfg(string material, decimal? tc) : base(material, tc)
        {
            if (MaterialData.FORM_COSTO == null || MaterialData.FORM_COSTO <= 0)
            {
                //si el Fcost del MM es nulo intenta colocar un FCOST si es que existe una sola activa
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    var y = db.T0020_FORMULA_H.Where(c => c.IDMATERIAL == material).ToList();
                    if (!y.Any())
                    {
                        InicializaVariablesSinFcost();
                    }
                    else
                    {
                        //existe al menos una formula
                        var m = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                        if (y.Count == 1)
                        {
                            m.FORM_COSTO = y[0].ID_FORMULA;
                            MaterialData.FORM_COSTO = y[0].ID_FORMULA;
                            FCost = MaterialData.FORM_COSTO.Value;
                            SetBomExplosionAccordingToFcost();
                        }
                        else
                        {
                            var f = y.Where(c => c.LastUsed != null).OrderByDescending(c => c.LastUsed).ToList();
                            if (f.Any())
                            {
                                m.FORM_COSTO = f[0].ID_FORMULA;
                                MaterialData.FORM_COSTO = f[0].ID_FORMULA;
                                FCost = MaterialData.FORM_COSTO.Value;
                                SetBomExplosionAccordingToFcost();
                            }
                            else
                            {
                                InicializaVariablesSinFcost();
                            }
                        }
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                //Si el MM tiene FCost 
                FCost = MaterialData.FORM_COSTO.Value;
                SetBomExplosionAccordingToFcost();
            }
            //CostHeader = new List<CostHeader>();
            CostItems = new List<CostItems>();
        }
        private void InicializaVariablesSinFcost()
        {
            FCost = -1;
            LevelMax = 0;
            Porcentaje = 1;
            CostItems = null;
            CostHeader = null;
            BomExplosion = null;
            Encontrado = false;
            ValorARS = CostoMax;
            ValorUSD = CostoMax;
        }

        //-----------------------------------------------------------------------------------
        //*****Propiedades accesibles
        public int FCost { get; protected set; }
        public int LevelMax { get; protected set; }
        public decimal Porcentaje { get; protected set; }
        public List<CostItems> CostItems { get; protected set; }
        public List<CostHeader> CostHeader { get; protected set; }
        public List<T0038_CostoMfgExplo> BomExplosion = new List<T0038_CostoMfgExplo>(); //Datos BOM explotada
        protected struct CostMini
        {
            public decimal ARS;
            public decimal USD;
            public decimal Porcentaje;
            public DateTime Fecha;
            public int LevelMax;
            public List<T0038_CostoMfgExplo> BomExplosion;
        }
        //-----------------------------------------------------------------------------------
        private void SetBomExplosionAccordingToFcost()
        {
            if (BomExplosion == null) return;
            if (BomExplosion.Any()) BomExplosion.Clear();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var formulaData = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == FCost);
                var itemFormula = db.T0021_FORMULA_I.Where(c => c.FORMULA == FCost).ToList();

                if (formulaData == null) InicializaVariablesSinFcost();

                foreach (var item in itemFormula)
                {
                    var matData = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == item.ITEM);
                    var itel1 = new T0038_CostoMfgExplo()
                    {
                        MaterialFabricar = formulaData.IDMATERIAL,
                        MaterialItem = item.ITEM,
                        IdItemFormula = item.ID_ITEM,
                        Origen = matData.ORIGEN,
                        MonedaItem = Moneda,
                        FormulaProp = item.CANTIDAD_PORC.Value,
                        CostoUSD = CostoMax,
                        CostoARS = CostoMax,
                        FechaCostoItem = DateTime.Today.AddYears(-5),
                        FormulaId = FCost,
                        PropARS = CostoMax,
                        PropUSD = CostoMax,
                        TipoCosto = TipoCosto.ToString(),
                        LastRun = DateTime.Now
                    };
                    BomExplosion.Add(itel1);
                }
            }
        }

        /// <summary>
        /// 2021.01.14 Genera los datos explotados con su costo
        /// se puede colocar aca una seleccion de si ver con costo de reposicion o con costo guarado
        /// Revison 2021.01.18 se agrega polimorfismo para Costo Standard.
        /// </summary>
        public virtual void GetCostExplotadoAtLevelMax(Monedas.SMonedas? moneda = null, int? formulaId = null, ACosto.CostType tipoCostoMP = CostType.MfgNowUc)
        {
            var cMoneda = moneda == null ? base.Moneda : moneda.ToString();
            var xplodForm = new BomExplosion(Material, formulaId);
            xplodForm.RunExplosionToLevelMax();
            LevelMax = xplodForm.NivelXplod;
            decimal costoProducto = 0;
            foreach (var item in xplodForm.CostItems)
            {
                ACosto repo;
                if (TipoCosto == CostType.MfgNowUc)
                {
                    repo = new ACostoRepo(item.ItemMP, XRate);
                }
                else
                {
                    repo = new ACostoStandard(item.ItemMP, XRate);
                }

                repo.GetCost();
                item.CostoUnit = cMoneda == "USD" ? repo.ValorUSD : repo.ValorARS;
                item.CostoProp = item.CostoUnit * item.Prop;
                costoProducto = costoProducto + item.CostoProp;
            }

            if (cMoneda == "USD")
            {
                base.ValorUSD = costoProducto;
                base.ValorARS = decimal.Round(costoProducto * XRate, 3);
            }
            else
            {
                base.ValorARS = costoProducto;
                base.ValorUSD = decimal.Round(costoProducto / XRate, 3);
            }
            foreach (var hx in xplodForm.CostHeader)
            {
                hx.CostoUsd = xplodForm.CostItems.Where(c => c.MaterialF == hx.Material).Sum(c => c.CostoProp);
                if (xplodForm.TodoEncontrado == false)
                {
                    hx.CalculoOk = false;
                }
                else
                {
                    hx.CalculoOk = xplodForm.CostItems.Any(c => c.MaterialF == hx.Material && c.CostoFound == false);
                }

                if (hx.Material == base.Material)
                {
                    hx.Material += "**";
                }
            }
            CostHeader = xplodForm.CostHeader;
            CostItems = xplodForm.CostItems;
        }
        public virtual void SetFCost(int fcost)
        {
            FCost = fcost;
            SetBomExplosionAccordingToFcost();
        }

        /// <summary>
        /// Revision --- 
        /// </summary>
        protected CostMini GetCostRecursiveFunction(string materialXplod)
        {
            var rtnNull = new CostMini()
            {
                //Inicializa Retorno NULL
                ARS = CostoMax,
                USD = CostoMax,
                Fecha = DateTime.Today.AddYears(-5),
                Porcentaje = 1,
                LevelMax = 1,
            };
            var costoSuma = new CostMini()
            {
                //Inicializa Retorno
                ARS = 0,
                USD = 0,
                Fecha = DateTime.Today.AddYears(1),
                LevelMax = 1,
                Porcentaje = 0,
            };
            var ppci = new CostItems();
            ACostoMfg mfg;

            if (materialXplod == Material)
            {
                mfg = this;
            }
            else
            {
                //Polimorfismo para implementar si repone costo de MP con STD o con UC 
                switch (TipoCosto)
                {
                    case CostType.MfgNowUc:
                        mfg = new ACostoMfgNowUc(materialXplod);
                        break;
                    case CostType.MfgNowStd:
                        mfg = new ACostoMfgNowStd(materialXplod);
                        break;
                    case CostType.CostRoll:
                        mfg = new ACostoMfgNowStd(materialXplod); //fake
                        break;
                    default:
                        mfg = new ACostoMfgNowStd(materialXplod); //fake
                        break;

                }
            }
            if (mfg.FCost < 0)
                return rtnNull;

            if (mfg.BomExplosion == null)
                return rtnNull;

            if (mfg.BomExplosion.Any() == false)
                return rtnNull;

            mfg.ValorARS = mfg.ValorUSD = 0;
            mfg.FechaCosto = DateTime.Today.AddYears(1);
            mfg.LevelMax = 1;
            mfg.Porcentaje = 0;

            foreach (var item in mfg.BomExplosion)
            {
                if (item.Origen != "FAB")
                {
                    //material no es Fabricado

                    ACosto costoMP;
                    if (TipoCosto == CostType.MfgNowUc)
                    {
                        costoMP = new ACostoRepo(item.MaterialItem, XRate);
                    }
                    else
                    {
                        costoMP = new ACostoStandard(item.MaterialItem, XRate);
                    }
                    costoMP.GetCost();
                    item.CostoARS = costoMP.ValorARS;
                    item.CostoUSD = costoMP.ValorUSD;
                    item.PropARS = item.CostoARS * item.FormulaProp;
                    item.PropUSD = item.CostoUSD * item.FormulaProp;
                    item.LastRun = DateTime.Now;
                    item.FechaCostoItem = costoMP.FechaCosto;

                    ValorARS += item.PropARS;
                    ValorUSD += item.PropUSD;
                    if (FechaCosto > item.FechaCostoItem)
                        FechaCosto = item.FechaCostoItem;

                    //estructura que va a retornar --
                    costoSuma.ARS += item.PropARS;
                    costoSuma.USD += item.PropUSD;
                    if (costoSuma.Fecha > item.FechaCostoItem)
                        costoSuma.Fecha = item.FechaCostoItem;

                    //alta en costitems!
                    ppci = new CostItems
                    {
                        MaterialF = materialXplod,
                        ItemMP = item.MaterialItem,
                        CostoFound = costoMP.Encontrado,
                        Moneda = "USD",
                        CostoUnit = item.CostoUSD,
                        Prop = item.FormulaProp,
                        CostoProp = item.PropUSD,
                    };
                    this.CostItems.Add(ppci);
                }
                else
                {
                    //El Material es Fabricado por lo tanto obtiene el costo desde la explosion
                    var costo = GetCostRecursiveFunction(item.MaterialItem);
                    costo.LevelMax = costo.LevelMax + 1;
                    item.CostoARS = costo.ARS;
                    item.CostoUSD = costo.USD;
                    item.PropARS = item.CostoARS * item.FormulaProp;
                    item.PropUSD = item.CostoUSD * item.FormulaProp;
                    item.FechaCostoItem = costo.Fecha;
                    item.LastRun = DateTime.Now;

                    costoSuma.ARS += item.PropARS;
                    costoSuma.USD += item.PropUSD;
                    costoSuma.LevelMax = costo.LevelMax;

                    if (costoSuma.Fecha > item.FechaCostoItem)
                        costoSuma.Fecha = item.FechaCostoItem;
                    var data0 = CostItems.Where(c => c.MaterialF == item.MaterialItem).ToList();
                    foreach (var qq in CostItems.Where(c => c.MaterialF == item.MaterialItem).ToList())
                    {
                        qq.Prop = qq.Prop * item.FormulaProp;
                        qq.CostoProp = qq.Prop * qq.CostoUnit;
                    }
                }
            }
            costoSuma.BomExplosion = BomExplosion;
            return costoSuma;
        }
    }


}
