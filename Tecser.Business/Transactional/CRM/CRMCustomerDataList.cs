using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CRM
{
    public class CrmCustomerDataList
    {
        public int SO { get; set; }
        public decimal KgPedido { get; set; }
        public decimal KgDespachado { get; set; }
        public string Moneda { get; set; }
        public string LX { get; set; }
        public decimal? Precio1 { get; set; }
        public decimal? Precio2 { get; set; }
        public decimal? Precio { get; set; }
        public string Status { get; set; }
        public string Material { get; set; }
        public DateTime? FechaSO { get; set; }

        public List<CrmCustomerDataList> GetData(int idCustomer6, string materialAKA = null, int maxValues = 15)
        {
            if (maxValues <= 0)
                maxValues = 1;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from cli7 in db.T0007_CLI_ENTREGA
                            join h in db.T0045_OV_HEADER on cli7.ID_CLI_ENTREGA equals h.CLIENTE
                            join i in db.T0046_OV_ITEM on new { a = h.IDOV } equals new { a = i.IDOV }
                            where cli7.IDCLIENTE == idCustomer6
                            orderby h.IDOV descending
                            select new CrmCustomerDataList()
                            {
                                Material = i.Material,
                                LX = i.MODO,
                                SO = h.IDOV,
                                Status = i.StatusItem,
                                FechaSO = h.FECHA_OV.Value,
                                KgDespachado = i.KGStockDespachados,
                                KgPedido = i.Cantidad,
                                Moneda = i.MonedaCotiz,
                                Precio1 = i.PRECIO1,
                                Precio2 = i.PRECIO2,
                                Precio = i.PrecioUnitario
                            };
                if (query.Any() == false)
                    return query.ToList();

                if (string.IsNullOrEmpty(materialAKA))
                    return query.Take(maxValues).ToList();
                return query.Where(c => c.Material.ToUpper().Equals(materialAKA.ToUpper())).Take(maxValues).ToList();
            }
        }
    }
}
