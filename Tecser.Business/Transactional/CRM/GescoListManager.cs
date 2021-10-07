using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CRM
{
    public class GescoListManager
    {
        public List<GescoStructure> PopulateGescoList(bool incluirInactivo)
        {
            var rtn = new List<GescoStructure>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                IQueryable<GescoStructure> data1;
                if (incluirInactivo == false)
                {
                    data1 = from cli in db.T0006_MCLIENTES
                            where cli.ACTIVO
                            join gescoH in db.T0230_GescoHeader on cli.IDCLIENTE equals gescoH.IdCliente
                                into list1
                            from l1 in list1.DefaultIfEmpty()
                            select new GescoStructure()
                            {
                                IdCliente = cli.IDCLIENTE,
                                ClienteRs = cli.cli_rsocial,
                                ClienteFantasia = cli.cli_fantasia,
                                LimiteCredito = cli.Limite_credito,
                                CallRequest = l1 != null && l1.RequestCall,
                                ConciliarCtaRequest = l1 != null && l1.RequestConciliation,
                                ProximaLlamada = l1.NextCall,
                                DocumentosImpagos = 1,
                                SaldoL1 = 1,
                                SaldoL2 = 1,
                                SaldoTotal = 1,
                                UltimaLlamada = l1.UltimaLlamadaFecha,
                                FechaPago = l1.UltimoPagoDate,
                                PL = l1.FechaPagoConfirmado,
                                ClienteActivo = cli.ACTIVO,
                                ClienteBloqueado = (cli.BLK_PEDIDO || cli.BLK_DELIVERY)
                            };
                }
                else
                {
                    data1 = from cli in db.T0006_MCLIENTES
                            join gescoH in db.T0230_GescoHeader on cli.IDCLIENTE equals gescoH.IdCliente
                                into list1
                            from l1 in list1.DefaultIfEmpty()
                            select new GescoStructure()
                            {
                                IdCliente = cli.IDCLIENTE,
                                ClienteRs = cli.cli_rsocial,
                                ClienteFantasia = cli.cli_fantasia,
                                LimiteCredito = cli.Limite_credito,
                                CallRequest = l1 != null && l1.RequestCall,
                                ConciliarCtaRequest = l1 != null && l1.RequestConciliation,
                                ProximaLlamada = l1.NextCall,
                                DocumentosImpagos = 1,
                                SaldoL1 = 1,
                                SaldoL2 = 1,
                                SaldoTotal = 1,
                                UltimaLlamada = l1.UltimaLlamadaFecha,
                                FechaPago = l1.UltimoPagoDate,
                                PL = l1.FechaPagoConfirmado,
                                ClienteActivo = cli.ACTIVO,
                                ClienteBloqueado = (cli.BLK_PEDIDO || cli.BLK_DELIVERY)
                            };
                }
                var lista = data1.ToList();
                foreach (var item in lista)
                {
                    var cta = db.T0202_CTACTESALDOS.SingleOrDefault(c =>
                        c.IDCLIENTE == item.IdCliente && c.CUENTATIPO == "L1");
                    item.SaldoL1 = cta?.DEUDA_TOT_ARS ?? 0;
                    cta = db.T0202_CTACTESALDOS.SingleOrDefault(c =>
                        c.IDCLIENTE == item.IdCliente && c.CUENTATIPO == "L2");
                    item.SaldoL2 = cta?.DEUDA_TOT_ARS ?? 0;
                    item.SaldoTotal = item.SaldoL1 + item.SaldoL2;
                    item.DocumentosImpagos = db.T0201_CTACTE.Count(c => c.IDCLI == item.IdCliente && c.SALDOFACTURA > 0);
                }
                return lista.ToList();
            }
        }
    }
}
