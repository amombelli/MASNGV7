using System;
using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    public class DsSalesOrderList
    {
        public int SO { get; set; }
        public int IdC7 { get; set; }
        public int IdC6 { get; set; }
        public string ClienteFantasia { get; set; }
        public string ClienteRazonSocial { get; set; }
        public string ClienteDescripcionT7 { get; set; }
        public DateTime? FechaSalesOrder { get; set; }
        public DateTime? FechaCompromiso { get; set; }
        public string StatusSalesOrder { get; set; }
        public string StatusEntrega { get; set; }


        public List<DsSalesOrderList> GetAllData(string globalAppCnn)
        {
            using (var db = new TecserData(globalAppCnn))
            {

                var data = (from salesH in db.T0045_OV_HEADER
                            select new DsSalesOrderList()
                            {
                                SO = salesH.IDOV,
                                ClienteFantasia = salesH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_fantasia,
                                ClienteRazonSocial = salesH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                ClienteDescripcionT7 = salesH.T0007_CLI_ENTREGA.ClienteEntregaDesc,
                                FechaCompromiso = salesH.FechaEntrega,
                                FechaSalesOrder = salesH.FECHA_OV,
                                IdC6 = (Int32)salesH.T0007_CLI_ENTREGA.IDCLIENTE,
                                IdC7 = salesH.CLIENTE.Value,
                                StatusEntrega = "NO DISP",
                                StatusSalesOrder = salesH.StatusOV
                            }).OrderByDescending(c => c.SO).ToList();
                return data;
            }
        }
        public List<DsSalesOrderList> GetByCustomer(int idCliente6, string globalAppCnn)
        {
            using (var db = new TecserData(globalAppCnn))
            {
                var data = (from salesH in db.T0045_OV_HEADER
                            where salesH.T0007_CLI_ENTREGA.IDCLIENTE == idCliente6
                            select new DsSalesOrderList()
                            {
                                SO = salesH.IDOV,
                                ClienteFantasia = salesH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_fantasia,
                                ClienteRazonSocial = salesH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                ClienteDescripcionT7 = salesH.T0007_CLI_ENTREGA.ClienteEntregaDesc,
                                FechaCompromiso = salesH.FechaEntrega,
                                FechaSalesOrder = salesH.FECHA_OV,
                                IdC6 = (Int32)salesH.T0007_CLI_ENTREGA.IDCLIENTE,
                                IdC7 = salesH.CLIENTE.Value,
                                StatusEntrega = "NO DISP",
                                StatusSalesOrder = salesH.StatusOV
                            }).OrderByDescending(c => c.SO).ToList();
                return data;
            }
        }
    }
}
