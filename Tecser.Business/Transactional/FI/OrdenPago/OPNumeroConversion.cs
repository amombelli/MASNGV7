using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.Transactional.FI.Cobranza;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.OrdenPago
{
    public static class OPNumeroConversion
    {
        public static string GetNumeroOP(int idOP, string lx)
        {
            if (idOP <= 0) return string.Empty;
            if (lx == "L1")
            {
                var i = idOP.ToString().Substring(0, 1);
                var j = idOP.ToString().Substring(1, idOP.ToString().Length - 1);
                return i.PadLeft(4, '0') + "-" + j.PadLeft(8, '0');
            }
            else
            {
                return "0002-" + idOP.ToString("D8");
            }
        }
        public static int GetIdOp(string numeroOp)
        {
            if (numeroOp.Length < 13) return -1;
            if (Convert.ToInt32(numeroOp.Substring(0, 3)) == 4)
            {
                //L1
                return Convert.ToInt32(numeroOp.Substring(4, 12));
            }

            if (Convert.ToInt32(numeroOp.Substring(0, 3)) == 2)
            {
                //L2
                return Convert.ToInt32(numeroOp.Substring(4, 12));
            }

            return -1;
        }
    }

}
