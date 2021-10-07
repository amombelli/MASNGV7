﻿using System;
using System.Linq;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class ACostoMfgNowUc : ACostoMfg
    {
        /// <summary>
        /// Clase de administracion de costo de Manufactura Explotado en memoria
        /// utilizando la FCOST del MM y los datos de UC almacenados en T0035
        /// </summary>

        public ACostoMfgNowUc(string material, decimal? tc = null) : base(material, tc)
        {
            TipoCosto = CostType.MfgNowUc;
        }
        
        public new void SetFCost(int fcost)
        {
            base.SetFCost(fcost);
        }

        public override void SaveCost(decimal costo)
        {
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
