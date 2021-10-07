using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure.Costos;

namespace Tecser.Business.Transactional.CO.Costos
{

    /// <summary>
    /// Revison 2021.06.01 Revision de Costo MFG desde CR
    /// </summary>
    public class CostRollRevisionFabricado
    {
        public void PopulateCostVersion2(string material = null)
        {
            var p = new AcostoMfgCr();
            p.GetCostXplodAll();

        }

        public List<StxCrManufactura> GetListPTRevision()
        {
            DateTime fechaCostoNull = DateTime.Today.AddYears(-5);
            decimal maxCosto = (decimal)999999.99;
            decimal tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var q1 = from t0035CostRoll in db.T0035_CostRoll
                         where t0035CostRoll.MOrigen == "FAB"
                         join std in db.T0039_CostoStandard on t0035CostRoll.Material equals std.Material into mate1
                         from mStd in mate1.DefaultIfEmpty()
                         join repo in db.T0036_CostoReposicion on t0035CostRoll.Material equals repo.Material into maty
                         from mRepo in maty.DefaultIfEmpty()
                         select new StxCrManufactura()
                         {
                             Material = t0035CostRoll.Material,
                             Moneda = t0035CostRoll.MonedaCosto,
                             Origen = t0035CostRoll.MOrigen,
                             FCost = t0035CostRoll.FCost == null ? -1 : t0035CostRoll.FCost.Value,
                             Tipo = t0035CostRoll.MType,
                             FechaCostoRepo = t0035CostRoll.CostRepoDate == null ? fechaCostoNull : t0035CostRoll.CostRepoDate.Value,
                             FechaCostoStdA = mStd.FechaCosto == null ? fechaCostoNull : mStd.FechaCosto,
                             ManualUpd = t0035CostRoll.ManualUpdated == null ? false : t0035CostRoll.ManualUpdated,
                             RepoArs = t0035CostRoll.CostoRepoUsd == null ? maxCosto : t0035CostRoll.CostoRepoUsd * tc,
                             RepoUsd = t0035CostRoll.CostoRepoUsd == null ? maxCosto : t0035CostRoll.CostoRepoUsd,
                             StdArs = t0035CostRoll.CostoCR == null ? maxCosto : t0035CostRoll.CostoCR * tc,
                             StdUsd = t0035CostRoll.CostoCR == null ? maxCosto : t0035CostRoll.CostoCR,
                             StdArsA = mStd.CostoArs == null ? maxCosto : mStd.CostoArs,
                             StdUsdA = mStd.CostoUsd == null ? maxCosto : mStd.CostoUsd,
                             VarRepoStdArs = 0,
                             VarRepoStdUsd = t0035CostRoll.CostoRepoUsd - (mStd.CostoUsd == null ? maxCosto : mStd.CostoUsd),
                             LevelMax = t0035CostRoll.MaterialComplex ?? 999
                         };
                return q1.OrderBy(c => c.Material).ToList();
            }
        }
    }
}
