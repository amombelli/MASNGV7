using System;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{
    //Nueva clase de costo base
    //2021.01.12
    //Revision 2021.01.18
    public abstract class ACosto
    {
        protected const decimal CostoMax = (decimal)999999.99;

        /// <summary>
        /// MfgNowUC  = Manufactura explotado en tiempo Real segun FCost-MM + MP=> UC/Repo
        /// MfgNowStd = Manufactura explotado en tiempo Real segun FCost-MM + MP=> STD
        /// MfgTable = Manufactura almancenado en tabla T0037
        /// Reposicion = Ultima Compra almacenado en tabla T0036
        /// Standard = Costo Guardado Standard en tabla T0039
        /// </summary>

        public enum CostType
        {
            MfgNowUc,
            MfgNowStd,
            Reposicion, //Costo UC T0036
            Standard, //Standard sera reposicion guardado T0039
            CostRoll  // Costo en Revision de Cost Roll para generar el Standard
        }
        protected ACosto(string material, decimal? xrate = null)
        {
            Material = material;
            ValorUSD = ValorARS = CostoMax;
            XRate = xrate ?? new ExchangeRateManager().GetExchangeRate(DateTime.Today); //XRate para calculo alternativo de costo
            MaterialData = MaterialMasterManager.GetSpecificPrimaryInformation(material);
            if (MaterialData == null)
            {
                var primario = MaterialMasterManager.GetPrimario(material);
                MaterialData = MaterialMasterManager.GetSpecificPrimaryInformation(primario);
                if (MaterialData == null)
                {
                    MaterialOrigen = "XXX";
                    Moneda = "USD";
                    Encontrado = false;
                    FechaCosto = DateTime.Today.AddYears(-5);
                    return;
                }
            }
            MaterialOrigen = MaterialData.ORIGEN;
            Moneda = string.IsNullOrEmpty(MaterialData.MonedaCosto) ? "USD" : MaterialData.MonedaCosto;
            FechaCosto = DateTime.Today.AddYears(-5);
            Encontrado = true;
        }
        //-----------------------------------------------------------------------------------------------
        protected readonly string Material;
        public string MaterialOrigen { get; private set; }
        public CostType TipoCosto { get; protected set; }
        public T0010_MATERIALES MaterialData { get; protected set; }
        public decimal XRate { get; protected set; }

        public DateTime FechaCosto;
        public decimal ValorUSD { get; protected set; }
        public decimal ValorARS { get; protected set; }
        public string Moneda { get; protected set; }
        public bool Encontrado { get; protected set; }
        //-----------------------------------------------------------------------------------------------
        
        public virtual void SaveCost(decimal costo)
        {
            //en clase abstracta solo la firma
            throw new NotImplementedException();
        } 
        public abstract void GetCost();
        protected void SetMoneda(Monedas.SMonedas moneda)
        {
            Moneda = moneda.ToString();
        }
        protected void SetTC(decimal tc)
        {
            XRate = tc <= 0 ? new ExchangeRateManager().GetExchangeRate(DateTime.Today) : tc;
        }
    }


}
