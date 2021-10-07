using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;
using static System.Decimal;

namespace Tecser.Business.Transactional.FI.CtaCte
{
    public class CtaCteEstiloCliente
    {
        public List<CtaCteCliSaldoAcumuladoStx> GetInfo(int idCliente, DateTime fechaDesde, string tipoLx, decimal tcHoy = 0)
        {
            var list = GetInfoFromDb(idCliente, fechaDesde, tipoLx);
            decimal DeudaTotalHoy;
            if (tcHoy <= 0)
            {
                tcHoy = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            }
            switch (tipoLx)
            {
                case "L1":
                    DeudaTotalHoy = new CtaCteCustomer(idCliente).GetResultadoCtaCte(@"L1").SaldoResumen;
                    break;
                case "L2":
                    DeudaTotalHoy = new CtaCteCustomer(idCliente).GetResultadoCtaCte(@"L2").SaldoResumen;
                    break;
                default:
                    DeudaTotalHoy = new CtaCteCustomer(idCliente).GetResultadoCtaCte("L1").SaldoResumen +
                                    new CtaCteCustomer(idCliente).GetResultadoCtaCte("L2").SaldoResumen;
                    break;
            }

            decimal ultimoTC = 0;
            foreach (var item in list)
            {
                item.SaldoAcc = DeudaTotalHoy;
                DeudaTotalHoy = DeudaTotalHoy - item.Importe;
                item.ImporteUSD = item.Mon == @"ARS" ? Round(item.Importe / item.TC, 2) : item.Importe;
                ultimoTC = item.TC;
            }

            if (ultimoTC == 0)
            {
                ultimoTC = 1;
            }
            var reg = new CtaCteCliSaldoAcumuladoStx()
            {
                IdReg = 0,
                FechaDoc = fechaDesde.AddDays(-1),
                Lx = tipoLx,
                Mon = @"ARS",
                TC = 0,
                TipoDoc = "SACC",
                Numero = "ANTERIOR",
                Importe = 0,
                SaldoAcc = DeudaTotalHoy,
                ImporteUSD = DeudaTotalHoy / ultimoTC,
            };
            reg.Lx = tipoLx == @"L3" ? "@@" : tipoLx;
            list.Add(reg);
            return list;
        }
        private List<CtaCteCliSaldoAcumuladoStx> GetInfoFromDb(int idCliente, DateTime fechaDesde, string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from ctacte in db.T0201_CTACTE
                            where ctacte.IDCLI == idCliente && ctacte.Fecha.Value > fechaDesde
                            orderby ctacte.Fecha descending
                            select new CtaCteCliSaldoAcumuladoStx()
                            {
                                FechaDoc = ctacte.Fecha.Value,
                                IdReg = ctacte.IDCTACTE,
                                Lx = ctacte.TIPO,
                                Mon = ctacte.MONEDA,
                                TipoDoc = ctacte.TDOC,
                                Numero = ctacte.NUMDOC,
                                Importe = ctacte.IMPORTE_ORI,
                                SaldoAcc = 0,
                                TC = ctacte.TC.Value,
                                ImporteUSD = 0
                            };
                if (tipoLx == "L1" || tipoLx == "L2")
                {
                    return query.Where(c => c.Lx == tipoLx).OrderByDescending(c => c.FechaDoc)
                        .ThenByDescending(c => c.IdReg).ToList();
                }
                else
                {
                    return query.OrderByDescending(c => c.FechaDoc).ThenByDescending(c => c.IdReg).ToList();
                }
            }
        }
    }
}
