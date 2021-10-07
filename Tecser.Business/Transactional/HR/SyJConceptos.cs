using System;

namespace Tecser.Business.Transactional.HR
{

    /// <summary>
    /// Clase para manejar los conceptos de SYJ
    /// 2021.03.22
    /// </summary>
    public class SyJConceptos
    {
        public enum HrConceptos
        {
            Salario,
            SAC,
            Vacaciones,
            LiquidacionFinal,  //mapea dentro de Salario
            Anticipo, //mapea dentro de Salario
            Prestamo,
            Devolucion, //mapea dentro de Prestamo
            Viaticos,
            Honorarios,
            Comisiones,
            DividendosSrl, //mapea dentro de Honorarios
            Bonos,
            HoraExtra,
        }

        public static HrConceptos MapConcepto(string conceptoString)
        {
            if (conceptoString == null)
                conceptoString = HrConceptos.Salario.ToString();
            try
            {
                return (HrConceptos)Enum.Parse(typeof(HrConceptos), conceptoString, true);
            }
            catch (Exception)
            {
                return HrConceptos.Salario;
                throw;
            }
        }
        public static string ReturnGL(HrConceptos concepto)
        {
            switch (concepto)
            {
                case HrConceptos.Salario:
                    return "5.1.2.";
                case HrConceptos.SAC:
                    return "5.1.9.";
                case HrConceptos.Vacaciones:
                    return "5.1.5.";
                case HrConceptos.LiquidacionFinal:
                    return "5.1.2.";
                case HrConceptos.Anticipo:
                    return "5.1.2.";
                case HrConceptos.Prestamo:
                    return "5.1.14.";
                case HrConceptos.Devolucion:
                    return "5.1.14.";
                case HrConceptos.Viaticos:
                    return "5.1.1.";
                case HrConceptos.Honorarios:
                    return "5.1.15.";
                case HrConceptos.Comisiones:
                    return "5.1.4.";
                case HrConceptos.DividendosSrl:
                    return "5.1.15.";
                case HrConceptos.Bonos:
                    return "5.1.6.";
                case HrConceptos.HoraExtra:
                    return "5.1.3.";
                default:
                    throw new ArgumentOutOfRangeException(nameof(concepto), concepto, null);
            }
        }
        public static string ReturnDescripcion(HrConceptos concepto)
        {
            switch (concepto)
            {
                case HrConceptos.Salario:
                    return "Salario";
                case HrConceptos.SAC:
                    return "SAC";
                case HrConceptos.Vacaciones:
                    return "Vacaciones";
                case HrConceptos.LiquidacionFinal:
                    return "Liquidacion Final";
                case HrConceptos.Anticipo:
                    return "Anticipos Sueldo";
                case HrConceptos.Prestamo:
                    return "Prestamo Personal";
                case HrConceptos.Devolucion:
                    return "Devolucion Prestamo";
                case HrConceptos.Viaticos:
                    return "Viaticos y Gastos";
                case HrConceptos.Honorarios:
                    return "Honarios";
                case HrConceptos.Comisiones:
                    return "Comision Ventas";
                case HrConceptos.DividendosSrl:
                    return "Dividendos Soc.";
                case HrConceptos.Bonos:
                    return "Bonos y Adicionales";
                case HrConceptos.HoraExtra:
                    return "Horas Extra";
                default:
                    throw new ArgumentOutOfRangeException(nameof(concepto), concepto, null);
            }
        }
    }


}
