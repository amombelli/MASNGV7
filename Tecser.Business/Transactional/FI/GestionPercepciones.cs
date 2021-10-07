using System;
using Tecser.Business.TOOLS;
using Tecser.Business.WebServices;

namespace Tecser.Business.Transactional.FI
{
    public class GestionPercepciones
    {
        public GestionPercepciones()
        {
        }

        public decimal GetAlicuotaIIBB(string numeroCuit, string periodo)
        {
            var iibb = new PadronArba();
            iibb.Conectar(numeroCuit, new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(periodo),
                new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(periodo));

            return Convert.ToDecimal(iibb.AlPerc);
        }
    }
}
