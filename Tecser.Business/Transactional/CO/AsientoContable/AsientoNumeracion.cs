using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable
{

    /// <summary>
    /// Clase para Obetencion Numero de Asiento Proximo
    /// </summary>
    public class AsientoNumeracion
    {
        public struct ReturnNumeracion
        {
            public int IdDocu;
            public decimal Nasx1;
            public decimal Nasx2;
        };
        public enum TipoLx
        {
            L1,
            L2,
        };
        public ReturnNumeracion GetNextNumeroAsiento(TipoLx lx, DateTime fechaAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rtn = new ReturnNumeracion()
                {
                    IdDocu = 0,
                    Nasx1 = 0,
                    Nasx2 = 0
                };

                string prefijo;
                string tipo1;
                string _xyear = fechaAsiento.Year.ToString().Substring(2, 2);
                string _mes = fechaAsiento.Month.ToString("D2");
                switch (lx)
                {
                    case TipoLx.L1:
                        prefijo = "1";
                        tipo1 = "1";
                        break;
                    case TipoLx.L2:
                        prefijo = "8";
                        tipo1 = "2";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(lx), lx, null);
                }

                var d = db.T0004_ASN.SingleOrDefault(c => c.XYEAR == _xyear && c.TIPO == tipo1);
                if (d == null)
                {
                    d.XYEAR = _xyear;
                    d.TIPO = tipo1;
                    d.ASN = 0;
                    d.XDOC = "AS";
                    d.PRE = prefijo;
                    d.NASX1X2 = Convert.ToDecimal(prefijo + _xyear + _mes + d.ASN.Value.ToString("D5"));
                    db.T0004_ASN.Add(d);
                    db.SaveChanges();
                }
                else
                {
                    d.ASN = (short?)(d.ASN.Value + 1);
                    d.NASX1X2 = Convert.ToDecimal(prefijo + _xyear + _mes + d.ASN.Value.ToString("D5"));
                    db.SaveChanges();
                }

                rtn.IdDocu = db.T0601_DOCU_H.Max(c => c.IDDOCU) + 1;
                rtn.Nasx1 = Convert.ToDecimal(d.NASX1X2);
                rtn.Nasx2 = (decimal)d.ASN;
                return rtn;
            }
        }
    }
}
