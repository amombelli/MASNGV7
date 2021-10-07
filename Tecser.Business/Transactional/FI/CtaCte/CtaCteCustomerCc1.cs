using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.CtaCte
{
    public class CtaCteCustomerCc1
    {
        public CtaCteCustomerCc1(int idCliente)
        {
            _idCli = idCliente;
        }

        private readonly int _idCli;
        public struct Retorno
        {
            public decimal SaldoL1_202;
            public decimal SaldoL2_202;
            public decimal SinImputarL1;
            public decimal SinImputarL2;
            public decimal SaldoL1_201;
            public decimal SaldoL2_201;
            public decimal ImporteL1_207;
            public decimal ImporteL2_207;
            public bool HayDiferenciaSaldos;
            public bool HayDiferencia207;
        }
        public Retorno GetData()
        {
            var ret = new Retorno()
            {
                HayDiferencia207 = false,
                HayDiferenciaSaldos = false,
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d201 = db.T0201_CTACTE.Where(c => c.IDCLI == _idCli && c.TIPO.ToUpper().Equals("L1")).ToList();
                ret.SaldoL1_201 = !d201.Any() ? 0 : d201.Sum(c => c.SALDOFACTURA);

                d201 = db.T0201_CTACTE.Where(c => c.IDCLI == _idCli && c.TIPO.ToUpper().Equals("L2")).ToList();
                ret.SaldoL2_201 = !d201.Any() ? 0 : d201.Sum(c => c.SALDOFACTURA);

                var x202L1 = db.T0202_CTACTESALDOS.SingleOrDefault(c => c.IDCLIENTE == _idCli && c.CUENTATIPO.ToUpper().Equals("L1"));
                ret.SaldoL1_202 = x202L1?.DEUDA_TOT_ARS ?? 0;

                var x202L2 = db.T0202_CTACTESALDOS.SingleOrDefault(c => c.IDCLIENTE == _idCli && c.CUENTATIPO.ToUpper().Equals("L2"));
                ret.SaldoL2_202 = x202L2?.DEUDA_TOT_ARS ?? 0;

                var sinImpu = db.T0208_COB_NO_APLICADA.Where(c => c.TIPOCUENTA == "L1" && c.CLIENTE == _idCli).ToList();
                ret.SinImputarL1 = !sinImpu.Any() ? 0 : sinImpu.Sum(c => c.MONTO.Value);

                sinImpu = db.T0208_COB_NO_APLICADA.Where(c => c.TIPOCUENTA == "L2" && c.CLIENTE == _idCli).ToList();
                ret.SinImputarL2 = !sinImpu.Any() ? 0 : sinImpu.Sum(c => c.MONTO.Value);

                var x207 = db.T0207_SPLITFACTURAS.Where(c => c.TIPO == "L1" && c.MontoImputado == 0 && c.CLIENTE == _idCli).ToList();
                ret.ImporteL1_207 = !x207.Any() ? 0 : x207.Sum(c => c.ImporteAImputar);

                x207 = db.T0207_SPLITFACTURAS.Where(c => c.TIPO == "L2" && c.MontoImputado == 0 && c.CLIENTE == _idCli).ToList();
                ret.ImporteL2_207 = !x207.Any() ? 0 : x207.Sum(c => c.ImporteAImputar);

                var dif201202 = (ret.SaldoL1_201 + ret.SaldoL2_201 - ret.SaldoL1_202 - ret.SaldoL2_202);
                var dif201207L1 = (ret.SaldoL1_201 - ret.ImporteL1_207 + ret.SinImputarL1);
                var dif201207L2 = (ret.SaldoL2_201 - ret.ImporteL2_207 + ret.SinImputarL2);

                ret.HayDiferenciaSaldos = dif201202 != 0;
                ret.HayDiferencia207 = (dif201207L1 + dif201207L2) != 0;
            }
            return ret;
        }
    }
}
