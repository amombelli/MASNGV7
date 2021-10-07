using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    public class Monedas
    {
        public enum SMonedas
        {
            USD,
            ARS,
        };

        public static SMonedas GetMonedaType(string moneda)
        {
            switch (moneda)
            {
                case "USD":
                    return SMonedas.USD;
                case "ARS":
                    return SMonedas.ARS;
                default:
                    return SMonedas.USD;
            }
        }

        public List<T0151_MONEDAS> GetListMonedas()
        {
            return new TecserData(GlobalApp.CnnApp).T0151_MONEDAS.ToList();
        }

        public T0151_MONEDAS GetSpecificMoneda(SMonedas monedaId)
        {
            string monedaStr = monedaId.ToString();
            var data =
                new TecserData(GlobalApp.CnnApp).T0151_MONEDAS.SingleOrDefault(c => c.IdMoneda == monedaStr);
            if (data == null)
            {
                var datanull = new T0151_MONEDAS();
                datanull.IdMoneda = "000";
                return datanull;
            }
            return data;
        }

    }
}
