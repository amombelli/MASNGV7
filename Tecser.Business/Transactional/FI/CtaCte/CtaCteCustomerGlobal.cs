using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.CtaCte
{
    public class CtaCteCustomerGlobal
    {
        public struct Retorno
        {
            public decimal SaldoGlobalL1_202;
            public decimal SaldoGlobalL2_202;
            public decimal SinImputarGlobalL1;
            public decimal SinImputarGlobalL2;
            public decimal SaldoGlobalL1_201;
            public decimal SaldoGlobalL2_201;
            public decimal ImporteL1_207;
            public decimal ImporteL2_207;
            public bool HayDiferenciaSaldos;
            public bool HayDiferencia207;
        }
        public Retorno GetGlobalData()
        {
            var ret = new Retorno();

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                ret.SaldoGlobalL1_202 = (decimal)db.T0202_CTACTESALDOS.Where(c => c.CUENTATIPO == "L1").Sum(c => c.DEUDA_TOT_ARS);
                ret.SaldoGlobalL2_202 = (decimal)db.T0202_CTACTESALDOS.Where(c => c.CUENTATIPO == "L2").Sum(c => c.DEUDA_TOT_ARS);
                ret.SinImputarGlobalL1 = (decimal)db.T0208_COB_NO_APLICADA.Where(c => c.TIPOCUENTA == "L1").Sum(c => c.MONTO);
                ret.SinImputarGlobalL2 = (decimal)db.T0208_COB_NO_APLICADA.Where(c => c.TIPOCUENTA == "L2").Sum(c => c.MONTO);
                ret.SaldoGlobalL1_201 = (decimal)db.T0201_CTACTE.Where(c => c.TIPO == "L1").Sum(c => c.SALDOFACTURA);
                ret.SaldoGlobalL2_201 = (decimal)db.T0201_CTACTE.Where(c => c.TIPO == "L2").Sum(c => c.SALDOFACTURA);
                ret.ImporteL1_207 =
                    (decimal)
                        db.T0207_SPLITFACTURAS.Where(c => c.TIPO == "L1" && c.MontoImputado == 0).Sum(c => c.ImporteAImputar);

                ret.ImporteL2_207 =
                   (decimal)
                       db.T0207_SPLITFACTURAS.Where(c => c.TIPO == "L2" && c.MontoImputado == 0).Sum(c => c.ImporteAImputar);

            }

            var dif201202 = (ret.SaldoGlobalL1_201 + ret.SaldoGlobalL2_201 - ret.SaldoGlobalL1_202 - ret.SaldoGlobalL2_202);

            var dif201207L1 = (ret.SaldoGlobalL1_201 - ret.ImporteL1_207 + ret.SinImputarGlobalL1);
            var dif201207L2 = (ret.SaldoGlobalL2_201 - ret.ImporteL2_207 + ret.SinImputarGlobalL2);

            ret.HayDiferenciaSaldos = dif201202 != 0;
            ret.HayDiferencia207 = (dif201207L1 + dif201207L2) != 0;

            return ret;
        }
    }
}
