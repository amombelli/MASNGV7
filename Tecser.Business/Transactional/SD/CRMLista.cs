using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.Transactional.SD
{
    public class CrmLista
    {
        public CrmLista()
        {

        }

        public List<T0046_OV_ITEM> CRMHistoricoCustomer_ByMaterial(string materialAka)
        {
            return
                new Repository<T0046_OV_ITEM>(new TecserData(GlobalApp.CnnApp)).GetAll()
                    .Where(c => c.Material.Equals(materialAka))
                    .OrderByDescending(c => c.IDOV)
                    .ToList();
        }

        public IList CRMHistorico_ByMaterial_and_ByCustomer(string materialAka, int idCustomerT6)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from cli in db.T0007_CLI_ENTREGA
                            join h in db.T0045_OV_HEADER on cli.ID_CLI_ENTREGA equals h.CLIENTE
                            join I in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = I.IDOV }
                            where cli.IDCLIENTE == idCustomerT6
                            orderby h.IDOV descending
                            select new
                            {
                                SO_N = h.IDOV,
                                KGPEDIDO = I.Cantidad,
                                KGDESPACHADO = I.KGStockDespachados,
                                MONEDA = I.MonedaCotiz,
                                LX = I.MODO,
                                PRECIO = I.PrecioUnitario,
                                PRL1 = I.PRECIO1,
                                PRL5 = I.PRECIO2,
                                ESTADO = I.StatusItem,
                                PRODUCTO = I.Material,
                                FECHA = h.FECHA_OV
                            };
                return query.Where(c => c.PRODUCTO.Equals(materialAka)).ToList();
            }
        }

    }
}
