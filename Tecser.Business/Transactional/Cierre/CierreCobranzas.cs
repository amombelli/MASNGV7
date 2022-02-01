using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.Cierre
{
    public class CierreCobranzas
    {
        public List<DsCierreCobranzasxCliente> GetCobranzasxCliente(string periodo, string lx)
        {
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            DateTime fechaF = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo);
            fechaF = fechaF.AddDays(1).AddSeconds(-1);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (lx == "L1" || lx == "L2")
                {
                    var dataCob = (from cob in db.T0205_COBRANZA_H
                        where cob.DOC_CANCELADO == false && (cob.FECHA >= fechaI && cob.FECHA <= fechaF) &&
                              cob.CUENTA == lx
                        group cob by new {cob.IdCliente, cob.T0006_MCLIENTES.cli_rsocial}
                        into g
                        select new DsCierreCobranzasxCliente()
                        {
                            IdCliente = g.Key.IdCliente.Value,
                            RazonSocial = g.Key.cli_rsocial,
                            Lx = lx,
                            Cobrado = g.Sum(c => c.Monto),
                            CantidadRegistros = g.Count(),
                            Periodo = periodo,
                            Cuit = g.FirstOrDefault().T0006_MCLIENTES.CUIT
                        }).ToList();
                    return dataCob;
                }
                else
                {
                    //sin tipo
                    return null;
                }
            }

        }
    }
}
