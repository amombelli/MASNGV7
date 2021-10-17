using System;
using System.Linq;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class ACostoMfgNowStd : ACostoMfg
    {
        public ACostoMfgNowStd(string material, decimal? tc = null) : base(material, tc)
        {
            TipoCosto = CostType.MfgNowStd;
            if (BomExplosion == null) return;
            foreach (var i in base.BomExplosion)
            {
                i.TipoCosto = TipoCosto.ToString();
            }
        }
        public new void SetFCost(int fcost)
        {
            base.SetFCost(fcost);
        }
        public override void SaveCost(decimal costo)
        {
            //using (var db = new TecserData(GlobalApp.CnnApp))
            //{
            //    var s = db.T0039_CostoStandard.SingleOrDefault(c => c.Material == base.Material);
            //    if (s == null)
            //    {


            //    }
            //    else
            //    {



            //    }
            //}
            throw new NotImplementedException();
        }

        /// <summary>
        /// Funcion GetCost on the Fly funciona OK 2021.01.13
        /// Explotado a Nivel Std segun formula Orignal
        /// </summary>
        public override void GetCost()
        {
            var valorFinal = GetCostRecursiveFunction(Material);
            ValorARS = valorFinal.ARS;
            ValorUSD = valorFinal.USD;
            Porcentaje = CostItems.Sum(c => c.Prop);
            LevelMax = valorFinal.LevelMax;
            Encontrado = Math.Round(Porcentaje, 4) == 1;
            FechaCosto = valorFinal.Fecha;
        }
    }
}
