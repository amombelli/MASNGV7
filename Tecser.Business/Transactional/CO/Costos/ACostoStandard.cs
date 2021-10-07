using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{

    /// <summary>
    /// Clase para administracion de costo Standard
    /// </summary>
    public class ACostoStandard : ACosto
    {
        public ACostoStandard(string material, decimal? xrate = null) : base(material, xrate)
        {
            TipoCosto = CostType.Standard;
        }
        public override void SaveCost(decimal costo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0039_CostoStandard.SingleOrDefault(c => c.Material == Material);
                if (d == null)
                {
                    var x = new T0039_CostoStandard
                    {
                        //Registro nuevo actualizado via SetCosto
                        Material = base.Material,
                        Origen = MaterialOrigen,
                        MType = base.MaterialData.TIPO_MATERIAL,
                        MonedaCosto = Moneda,
                        FechaCosto = DateTime.Today,
                        VarCostoUsd = 0,
                        VarCostoArs = 0,
                        FechaCostoOld = DateTime.Today.AddYears(-5),
                        FechaCostRoll = DateTime.Today.AddYears(-5),
                        UpdatedBy = GlobalApp.AppUsername,
                        UpdatedOn = DateTime.Now,
                        DeltaUsd1 = 0,
                        DeltaUsd2 = 0,
                        CostDetBy = "Manual"
                    };
                    if (Moneda == @"USD")
                    {
                        x.CostoUsd = costo;
                        x.CostoArs = Math.Round(costo * base.XRate, 2);
                    }
                    else
                    {
                        x.CostoArs = costo;
                        x.CostoUsd = Math.Round(costo / base.XRate, 2);
                    }
                    db.T0039_CostoStandard.Add(x);
                    db.SaveChanges();
                }
                else
                {
                    d.CostoArsOld = d.CostoArs;
                    d.CostoUsdOld = d.CostoUsd;
                    if (Moneda == @"USD")
                    {
                        if (d.CostoUsd != costo)
                        {
                            d.CostDetBy = "Manual";
                            d.CostoUsd = costo;
                            d.CostoArs = decimal.Round((costo * this.XRate), 3);
                            d.ManualUpdated = true;
                            d.UpdatedBy = GlobalApp.AppUsername;
                            d.UpdatedOn = DateTime.Now;
                            d.VarCostoArs = d.CostoArs - d.CostoArsOld;
                            d.VarCostoUsd =d.CostoUsd - d.CostoUsdOld;
                            db.SaveChanges(); 
                        }
                    }
                    else
                    {
                        if (d.CostoArs != costo)
                        {
                            d.CostDetBy = "Manual";
                            d.CostoArs = costo;
                            d.CostoUsd = decimal.Round((costo / this.XRate), 3);
                            d.ManualUpdated = true;
                            d.UpdatedBy = GlobalApp.AppUsername;
                            d.UpdatedOn = DateTime.Now;
                            d.VarCostoArs = d.CostoArs - d.CostoArsOld;
                            d.VarCostoUsd = d.CostoUsd - d.CostoUsdOld;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        public override void GetCost()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0039_CostoStandard.SingleOrDefault(c => c.Material == Material);
                if (d == null)
                {
                    base.Encontrado = false;
                    base.ValorARS = CostoMax;
                    base.ValorUSD = CostoMax;
                }
                else
                {
                    Encontrado = true;
                    ValorARS = d.CostoArs;
                    ValorUSD = d.CostoUsd;
                    FechaCosto = d.FechaCosto;
                }
            }
        }
    }
}
