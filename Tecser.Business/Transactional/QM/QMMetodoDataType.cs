using System;

namespace Tecser.Business.Transactional.QM
{
    public class QmMetodoDataType
    {
        public enum TipoDato
        {
            Decimal,
            Entero,
            Si_No,
            Ok_Incorrecto,
            Aprobado_Rechazado,
            TextoLibre,
            True_False
        }
        public enum VSiNo
        {
            Si,
            No
        };
        public enum VOkIncorrecto
        {
            Ok,
            Incorrecto
        };
        public enum VAprobadoRechazado
        {
            Aprobado,
            Rechazado
        };

        public enum VTrueFalse
        {
            Verdadero,
            Falso
        };

        public static TipoDato MapTipoDatoFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = TipoDato.TextoLibre.ToString();
            try
            {
                return (TipoDato)Enum.Parse(typeof(TipoDato), status, true);
            }
            catch (Exception)
            {
                return TipoDato.TextoLibre;
                throw;
            }
        }


    }
}