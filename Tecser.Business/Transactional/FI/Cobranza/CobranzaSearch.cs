using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    public class CobranzaSearch
    {
        public List<T0205_COBRANZA_H> GetListaCobranzas(int? idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idCliente == 0 || idCliente == null)
                    return db.T0205_COBRANZA_H.OrderByDescending(c => c.IDCOB).ToList();
                return db.T0205_COBRANZA_H.Where(c => c.IdCliente == idCliente).OrderByDescending(c => c.IDCOB).ToList();
            }
        }

        public List<T0205_COBRANZA_H> BusquedaConNombreCliente(int? idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idCliente == 0 || idCliente == null)
                    return db.T0205_COBRANZA_H.OrderByDescending(c => c.IDCOB).ToList();
                return db.T0205_COBRANZA_H.Where(c => c.IdCliente == idCliente).OrderByDescending(c => c.IDCOB).ToList();
            }
        }

        public List<T0206_COBRANZA_I> GetItemsFromCobranza(int idCob)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0206_COBRANZA_I.Where(c => c.IDCOB == idCob).ToList();
            }
        }

        public T0205_COBRANZA_H GetCobranzaHeader(int idCob)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCob);
            }
        }

        public int GetIdCobranzaFromIdCtaCte(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                if (data.IDT2 == null)
                    return 0;
                return data.IDT2.Value;

            }
        }

    }
}
