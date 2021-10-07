using System.Collections.Generic;
using System.Linq;


namespace TecserEF.Entity.DataStructure
{
    public class CobranzaHeaderSerach : T0205_COBRANZA_H
    {
        public string RazonSocial { get; set; }

        public List<CobranzaHeaderSerach> GetData(int? idCliente, string globalAppConnection)
        {
            using (var db = new TecserData(globalAppConnection))
            {
                var query = from h in db.T0205_COBRANZA_H
                            select new CobranzaHeaderSerach()
                            {
                                RazonSocial = h.T0006_MCLIENTES.cli_rsocial,
                                CUENTA = h.CUENTA,
                                IdCliente = h.IdCliente,
                                FECHA = h.FECHA,
                                IDCOB = h.IDCOB,
                                DIAS_PP = h.DIAS_PP,
                                MON = h.MON,
                                Monto = h.Monto,
                                DOC_CANCELADO = h.DOC_CANCELADO,
                                NRECIBO = h.NRECIBO,
                                NRECIPROVI = h.NRECIPROVI,
                                ReciboDesc = h.ReciboDesc,
                                ENVIAREMAIL = h.ENVIAREMAIL,
                                ENVIADO = h.ENVIADO,
                                NRECIBOOFI = h.NRECIBOOFI,

                            };
                var lista = query.ToList();
                if (idCliente == null || idCliente == 0)
                    return lista.OrderByDescending(c => c.IDCOB).ToList();
                return lista.Where(c => c.IdCliente == idCliente.Value).OrderByDescending(c => c.IDCOB).ToList();
            }
        }
    }
}
