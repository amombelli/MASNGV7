using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.MasterData.BOM
{
    /// <summary>
    /// Creation Date: 2021.01.14
    /// Nueva clase para gestionar explosion de BOM a items con origen != a FAB
    /// Explota la formula a maximo nivel pero no costea
    ///  </summary>
    public class BomExplosion
    {
        private readonly string _material;
        public List<CostItems> CostItems { get; private set; }
        public List<CostHeader> CostHeader { get; private set; }
        private readonly int _idFcost;
        private readonly string _moneda;
        public bool TodoEncontrado { get; private set; }
        public int NivelXplod { get; private set; }

        /// <summary>
        /// Si se provee idFormula utiliza esta FCOST para calcular el costo
        /// si no se provee utiliza la FCOST seleccionda
        /// </summary>
        public BomExplosion(string material, int? idformula)
        {
            _material = material;
            CostHeader = new List<CostHeader>();
            CostItems = new List<CostItems>();
            var m = new MaterialMasterManager().GetPrimarioInfo(_material);
            _moneda = string.IsNullOrEmpty(m.MonedaCosto) ? "USD" : m.MonedaCosto;
            _idFcost = idformula ?? MaterialMasterManager.GetFCost(_material);
            TodoEncontrado = true;
        }


        /// <summary>
        /// Metdo que deje disponible CostItems y CostHeader la explosion de la
        /// Formula hasta el maximo nivel donde todos los items sean MP/Comprados
        /// </summary>
        public void RunExplosionToLevelMax()
        {
            NivelXplod = 1;
            ExplosionFormulaCompletaMemoria(_idFcost);
        }
        private bool ExplosionFormulaCompletaMemoria(int idFormula, decimal multiplicador = 1)
        {
            NivelXplod++;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = new CostHeader();
                var f0 = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                if (f0 == null)
                {
                    TodoEncontrado = false; //Este Item no ha sido encontrado (FCOST inexistente o nulo)
                    x = new CostHeader()
                    {
                        Material = "ID" + idFormula,
                        CostoUsd = GlobalApp.MaxCosto,
                        Moneda = _moneda,
                        Origen = "IND",
                        Fcost = idFormula,
                        CalculoOk = false
                    };
                }
                else
                {
                    x = new CostHeader()
                    {
                        Material = f0.IDMATERIAL,
                        CostoUsd = 0,
                        Moneda = _moneda,
                        Origen = f0.T0010_MATERIALES.ORIGEN,
                        Fcost = idFormula,
                        CalculoOk = true
                    };
                }
                CostHeader.Add(x);  //Va acumulando en CostHeader la lista de materiales a Explotar

                var fi = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();
                foreach (var i in fi)
                {
                    if (i.T0010_MATERIALES.ORIGEN == "FAB")
                    {
                        if (i.T0010_MATERIALES.FORM_COSTO == null || i.T0010_MATERIALES.FORM_COSTO.Value <= 0)
                        {
                            var explo = new CostItems()
                            {
                                Moneda = _moneda,
                                MaterialF = i.ITEM,
                                ItemMP = i.ITEM,
                                Prop = multiplicador * i.CANTIDAD_PORC.Value,
                                CostoProp = GlobalApp.MaxCosto,
                                CostoUnit = GlobalApp.MaxCosto,
                                CostoFound = false
                            };
                            CostItems.Add(explo);
                        }
                        else
                        {
                            ExplosionFormulaCompletaMemoria(MaterialMasterManager.GetFCost(i.ITEM), i.CANTIDAD_PORC.Value * multiplicador);
                        }
                    }
                    else
                    {
                        var explo = new CostItems()
                        {
                            Moneda = _moneda,
                            MaterialF = i.T0020_FORMULA_H.IDMATERIAL,
                            ItemMP = i.ITEM,
                            Prop = multiplicador * i.CANTIDAD_PORC.Value,
                            CostoProp = GlobalApp.MaxCosto,
                            CostoUnit = GlobalApp.MaxCosto
                        };
                        CostItems.Add(explo);
                    }
                }
            }
            return true;
        }
    }
}
