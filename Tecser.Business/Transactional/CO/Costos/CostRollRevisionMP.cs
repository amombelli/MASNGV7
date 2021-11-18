using System;
using System.Collections.Generic;
using System.Linq;

using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure.Costos;

namespace Tecser.Business.Transactional.CO.Costos
{

    /// <summary>
    /// 2021.06.01 -- obtiene lista de materias primas para revision 
    /// </summary>
    public class CostRollRevisionMP
    {
        public List<StxCrReposicion> GetListMPRevision(bool onlyActive = true)
        {
            DateTime fechaCostoNull = DateTime.Today.AddYears(-5);
            decimal maxCosto = (decimal)999999.99;
            decimal tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var q1 = from mCR in db.T0035_CostRoll
                         where mCR.MOrigen == "NAC" || mCR.MOrigen == "IMP"
                         join std in db.T0039_CostoStandard on mCR.Material equals std.Material into mate1
                         from mStd in mate1.DefaultIfEmpty()
                         join repo in db.T0036_CostoReposicion on mCR.Material equals repo.Material into maty
                         from mRepo in maty.DefaultIfEmpty()
                         select new StxCrReposicion()
                         {
                             Material = mCR.Material,
                             Moneda = mCR.MonedaCosto,
                             Origen = mCR.MOrigen,
                             Tipo = mCR.MType,
                             FechaCostoRepo = mCR.CostRepoDate == null ? fechaCostoNull : mCR.CostRepoDate.Value,
                             FechaCostoStdA = mStd.FechaCosto == null ? fechaCostoNull : mStd.FechaCosto,
                             ManualUpd = mCR.ManualUpdated,
                             RepoArs = mRepo.CostoUCArs == null ? 9999999 : mRepo.CostoUCArs,
                             RepoUsd = mRepo.CostoUCUsd == null ? 9999999 : mRepo.CostoUCUsd,
                             StdArs = mCR.CostoCR == null ? 9999999 : mCR.CostoCR * tc,
                             StdUsd = mCR.CostoCR == null ? 9999999 : mCR.CostoCR,
                             StdArsA = mStd.CostoArs == null ? 999999 : mStd.CostoArs,
                             StdUsdA = mCR.CostoStandardOld == null ? 9999999 : mCR.CostoStandardOld,
                             VarRepoStdArs = (mCR.CostoRepoUsd * tc) - (mCR.CostoStandardOld * tc) == null ? 10000 : (mCR.CostoRepoUsd * tc) - (mCR.CostoStandardOld * tc),
                             VarRepoStdUsd = mCR.CostoRepoUsd - mCR.CostoStandardOld == null ? 100000 : mCR.CostoRepoUsd - mCR.CostoStandardOld,
                             MaterialActivo = true
                         };
                if (onlyActive)
                    return q1.Where(c => c.MaterialActivo == true).OrderBy(c => c.Material).ToList();
                return q1.OrderBy(c => c.Material).ToList();
            }
        }
    }
}
