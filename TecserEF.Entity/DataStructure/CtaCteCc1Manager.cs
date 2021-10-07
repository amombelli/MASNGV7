using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    public class CtaCteCc1Manager
    {
        public List<Cc1DataStructure> GetCc1Data(string globalAppCnn, int idCliente = 0, int maxRecords = 200)
        {
            using (var db = new TecserData(globalAppCnn))
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
    }
}