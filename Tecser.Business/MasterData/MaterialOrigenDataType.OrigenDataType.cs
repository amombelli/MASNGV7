using System;

namespace Tecser.Business.MasterData
{
    public static class MaterialOrigenDataType
    {
        public enum OrigenDt
        {
            Fabricado,
            CompradoNac,
            Importado,
            AmbosFab,
            AmbosComp,
        };
        public static OrigenDt RetornaTypeFromDataTypeText(string status)
        {
            if (String.IsNullOrEmpty(status))
                return OrigenDt.Fabricado;
            try
            {
                return (OrigenDt)Enum.Parse(typeof(OrigenDt), status, true);
            }
            catch (Exception)
            {
                return OrigenDt.CompradoNac;
                throw;
            }
        }
        public static string RetornaLetraFromDataType(OrigenDt origen)
        {
            switch (origen)
            {
                case OrigenDt.Fabricado:
                    return "F";
                case OrigenDt.CompradoNac:
                    return "CN";
                case OrigenDt.Importado:
                    return "CI";
                case OrigenDt.AmbosFab:
                    return "XF";
                case OrigenDt.AmbosComp:
                    return "XC";
                default:
                    throw new ArgumentOutOfRangeException(nameof(origen), origen, null);
            }
        }
        public static OrigenDt RetornaTypeFromLetraMaterialMaster(string letraOrigen)
        {
            switch (letraOrigen)
            {
                case "FAB":
                    //to fix historical data
                    return OrigenDt.Fabricado;
                case "NAC":
                    //to fix historical data
                    return OrigenDt.CompradoNac;
                case "IMP":
                    //to fix historical data
                    return OrigenDt.Importado;
                case "X":
                    return OrigenDt.AmbosFab;
                case "F":
                    return OrigenDt.Fabricado;
                case "CN":
                    return OrigenDt.CompradoNac;
                case "CI":
                    return OrigenDt.Importado;
                case "XF":
                    return OrigenDt.AmbosFab;
                case "XC":
                    return OrigenDt.AmbosComp;
                default:
                    //si hay algun caso mal o null
                    return OrigenDt.Fabricado;
            }
        }
    }
}