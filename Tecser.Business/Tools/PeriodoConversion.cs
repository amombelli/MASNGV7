using System;
using System.Globalization;

namespace Tecser.Business.TOOLS
{
    public class PeriodoConversion
    {
        /// <summary>
        /// Devuelve el mes de una fecha en formato 00
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public string GetMesMm(DateTime fecha)
        {
            //return fecha.Month.ToString("MM");
            return fecha.Month.ToString("00");
        }

        /// <summary>
        /// Devuelve el año de una fecha en formato YYYY
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public string GetYearYyyy(DateTime fecha)
        {
            return fecha.Year.ToString(("0000"));
        }
        /// <summary>
        /// Devuelve el año de una fecha en formato YY
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public string GetYearYy(DateTime fecha)
        {
            return fecha.ToString(("yy"));
        }
        /// <summary>
        /// Devuelve el dia de una fecha en formato DD
        /// </summary>
        public string GetDayDd(DateTime fecha)
        {
            return fecha.Day.ToString(("d2"));
        }
        /// <summary>
        /// Devuelve el periodo de una fecha en formato YYYYMM
        /// </summary>
        public string GetPeriodo(DateTime fecha)
        {
            return fecha.Year.ToString(("0000")) + fecha.Month.ToString("00");
        }

        public string GetProximoPeriodo(string periodo)
        {
            var fechaP = GetFechaPrimerDiaPeriodo(periodo);
            return GetPeriodo(fechaP.AddMonths(1));
        }

        public string GetAnteriorPeriodo(string periodo)
        {
            var fechaP = GetFechaPrimerDiaPeriodo(periodo);
            return GetPeriodo(fechaP.AddMonths(-1));
        }

        public DateTime GetFechaPrimerDiaPeriodo(string periodo)
        {
            var fechaI = DateTime.ParseExact(periodo + "01",
                "yyyyMMdd",
                CultureInfo.InvariantCulture);
            return fechaI;
        }

        public DateTime GetFechaUltimoDiaPeriodo(string periodo)
        {
            return GetFechaPrimerDiaPeriodo(periodo).AddMonths(1).AddDays(-1);
        }

        public string GetPrimerDiaPeriodoYyyymmdd(string periodo)
        {
            return periodo + "01";
        }

        public string GetUltimoDiaPeriodoYyyymmdd(string periodo)
        {
            var dt = DateTime.DaysInMonth(Convert.ToInt32(periodo.Substring(0, 4)), Convert.ToInt32(periodo.Substring(4, 2)));
            return periodo + dt;
        }
    }
}

