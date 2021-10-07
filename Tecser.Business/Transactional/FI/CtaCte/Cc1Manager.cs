using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.FI.CtaCte
{
    public class Cc1Manager
    {
        public List<Cc1DataStructure> GetCc1Data(int idCliente = 0, int maxRecords = 200)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idCliente == 0)
                {
                    var qdata = from t201 in db.T0201_CTACTE
                                join t400 in db.T0400_FACTURA_H on t201.IDCTACTE equals t400.IdCtaCte
                                    into list1
                                from l1 in list1.DefaultIfEmpty()
                                select new Cc1DataStructure()
                                {
                                    IdCtaCte = t201.IDCTACTE,
                                    IdCliente = t201.IDCLI,
                                    LX = t201.TIPO,
                                    Fecha = t201.Fecha.Value,
                                    Importe = t201.IMPORTE_ORI,
                                    SaldoPendiente = t201.SALDOFACTURA,
                                    Moneda = t201.MONEDA,
                                    Td = t201.TDOC,
                                    Usuario = t201.LogUsuario,
                                    NumeroDoc = t201.NUMDOC,
                                    ClienteRS = t201.T0006_MCLIENTES.cli_rsocial,
                                    NumeroRemito = l1.Remito,
                                    IdFactura400 = l1.IDFACTURA
                                };
                    return qdata.OrderByDescending(c => c.IdCtaCte).Take(maxRecords).ToList();
                }
                else
                {
                    var qdata = from t201 in db.T0201_CTACTE
                                where t201.IDCLI == idCliente
                                join t400 in db.T0400_FACTURA_H on t201.IDCTACTE equals t400.IdCtaCte
                                    into list1
                                from l1 in list1.DefaultIfEmpty()
                                select new Cc1DataStructure()
                                {
                                    IdCtaCte = t201.IDCTACTE,
                                    IdCliente = t201.IDCLI,
                                    LX = t201.TIPO,
                                    Fecha = t201.Fecha.Value,
                                    Importe = t201.IMPORTE_ORI,
                                    SaldoPendiente = t201.SALDOFACTURA,
                                    Moneda = t201.MONEDA,
                                    Td = t201.TDOC,
                                    Usuario = t201.LogUsuario,
                                    NumeroDoc = t201.NUMDOC,
                                    ClienteRS = t201.T0006_MCLIENTES.cli_rsocial,
                                    NumeroRemito = l1.Remito,
                                    IdFactura400 = l1.IDFACTURA
                                };
                    return qdata.OrderByDescending(c => c.IdCtaCte).Take(maxRecords).ToList();
                }
            }
        }
        public List<Cc1AnalisisDiferenciaStructure> GetAnalisisDiferenciaSaldo()
        {
            var dataList = new List<Cc1AnalisisDiferenciaStructure>();
            int a = 1;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                foreach (var i in db.T0006_MCLIENTES)
                {
                    var cta = new CtaCteCustomerCc1(i.IDCLIENTE).GetData();
                    var record = new Cc1AnalisisDiferenciaStructure
                    {
                        IdCliente = i.IDCLIENTE,
                        RazonSocial = i.cli_rsocial,
                        TipoLx = "L1",
                        Saldo201 = cta.SaldoL1_201,
                        Saldo202 = cta.SaldoL1_202,
                        Saldo207 = cta.ImporteL1_207,
                        SaldoNI = cta.SinImputarL1,
                        Observacion = "",
                        Dif201207 = (cta.SaldoL1_201 - cta.ImporteL1_207 + cta.SinImputarL1),
                        Dif202201 = (cta.SaldoL1_202 - cta.SaldoL1_201),
                        Dif202207 = (cta.SaldoL1_202 - cta.ImporteL1_207 + cta.SinImputarL1)
                    };
                    var record1 = new Cc1AnalisisDiferenciaStructure
                    {
                        IdCliente = i.IDCLIENTE,
                        RazonSocial = i.cli_rsocial,
                        TipoLx = "L2",
                        Saldo201 = cta.SaldoL2_201,
                        Saldo202 = cta.SaldoL2_202,
                        Saldo207 = cta.ImporteL2_207,
                        SaldoNI = cta.SinImputarL2,
                        Observacion = "",
                        Dif201207 = (cta.SaldoL2_201 - cta.ImporteL2_207 + cta.SinImputarL2),
                        Dif202201 = (cta.SaldoL2_202 - cta.SaldoL2_201),
                        Dif202207 = (cta.SaldoL2_202 - cta.ImporteL2_207 + cta.SinImputarL2)
                    };
                    a++;

                    dataList.Add(record);
                    dataList.Add(record1);
                }
            }
            return dataList;
        }
    }
}