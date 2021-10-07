using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;

namespace TecserSQL.Data.MasterData
{
    public class CustomerBillTo
    {
        public CustomerBillTo(TecserData context)
        {

        }
        public int GetId6FromCustomerT7(int id7, string cnn)
        {
            using (var data = new TecserData(cnn))
            {
                var result = data.T0007_CLI_ENTREGA.FirstOrDefault(c => c.ID_CLI_ENTREGA == id7);
                if (result == null)
                {
                    return 0;
                }
                else
                {
                    return (int)result.IDCLIENTE;
                }
            }
        }
        public IEnumerable<T0007_CLI_ENTREGA> GetAllActiveShiptoFromBillto(int id6, bool onlyActive, string cnn)
        {
            using (var data = new TecserData(cnn))
            {
                return data.T0007_CLI_ENTREGA.Where(c => c.Activo == onlyActive && c.IDCLIENTE == id6);

            }
        }
        private int GetMaxCustomerId6(string cnn)
        {
            return new TecserData(cnn).T0006_MCLIENTES.Max(x => x.IDCLIENTE);
        }
        private int GetMaxCustomerId7(string cnn)
        {
            return new TecserData(cnn).T0007_CLI_ENTREGA.Max(x => x.ID_CLI_ENTREGA);
        }
        public bool CheckIfCuitExist(string ntax, string cnn)
        {
            return new TecserData(cnn).T0006_MCLIENTES.Any(c => c.CUIT.Equals(ntax));
        }
        public IEnumerable<T0006_MCLIENTES> PruebaCargaTablaRelacionada(int id6, string cnn)
        {
            using (var data = new TecserData(cnn))
            {
                var result =
                    data.T0006_MCLIENTES.Include("T0007_CLI_ENTREGA")
                        .OrderBy(x => x.cli_rsocial)
                        .Where(c => c.IDCLIENTE == id6);
                return result;
            }
        }

        ////private void CreateCtaCteRecordL1L2(int customerId, string cnn)
        ////{
        ////    using (var db = new TecserData(cnn))
        ////    {
        ////        var dataT0202 =
        ////            db.T0202_CTACTESALDOS.SingleOrDefault(
        ////                c => c.IDCLIENTE == customerId && c.CUENTATIPO.ToUpper().Equals("L1"));
        ////        if (dataT0202 == null)
        ////        {
        ////            var x = new T0202_CTACTESALDOS();
        ////            x.CUENTATIPO = "L1";
        ////            x.IDCLIENTE = customerId;
        ////            x.DEUDA_ARS = 0;
        ////            x.DEUDA_TOT_ARS = 0;
        ////            x.DEUDA_USD = 0;
        ////            x.FACTPEND = false;
        ////            x.LCREDITO = 0;
        ////            x.LogDate = DateTime.Today;
        ////            x.LogUsuario = Environment.UserName;
        ////            x.NDIAS = 0;
        ////            x.NMON = "ARS";
        ////            x.NSALDO = 0;
        ////            x.NUFACTN = "";
        ////            x.TC = 0;
        ////            x.UPAGO = null;
        ////            db.T0202_CTACTESALDOS.Add(x);
        ////            db.SaveChanges();
        ////        }

        ////        dataT0202 =
        ////            db.T0202_CTACTESALDOS.SingleOrDefault(
        ////                c => c.IDCLIENTE == customerId && c.CUENTATIPO.ToUpper().Equals("L2"));
        ////        if (dataT0202 == null)
        ////        {
        ////            var x = new T0202_CTACTESALDOS();
        ////            x.CUENTATIPO = "L2";
        ////            x.IDCLIENTE = customerId;
        ////            x.DEUDA_ARS = 0;
        ////            x.DEUDA_TOT_ARS = 0;
        ////            x.DEUDA_USD = 0;
        ////            x.FACTPEND = false;
        ////            x.LCREDITO = 0;
        ////            x.LogDate = DateTime.Today;
        ////            x.LogUsuario = Environment.UserName;
        ////            x.NDIAS = 0;
        ////            x.NMON = "ARS";
        ////            x.NSALDO = 0;
        ////            x.NUFACTN = "";
        ////            x.TC = 0;
        ////            x.UPAGO = null;
        ////            db.T0202_CTACTESALDOS.Add(x);
        ////            if (db.SaveChanges() > 0)
        ////            {
        ////                //aa
        ////            }
        ////            else
        ////            {
        ////                //b
        ////            }

        ////        }
        ////    }
        ////}

        //public bool SaveCustomerData(Customer customerData, string cnn)
        //{
        //    var x = new T0006_MCLIENTES();
        //    x = (T0006_MCLIENTES) customerData.Header;
        //    using (var db = new TecserData(cnn))
        //    {
        //        if (customerData.Header.IDCLIENTE == 0)
        //        {
        //            customerData.Header.IDCLIENTE = GetMaxCustomerId6(cnn) + 1;
        //            customerData.Header.Fecha_Ingreso = DateTime.Today;
        //            db.T0006_MCLIENTES.Add(customerData.Header);
        //            var customerId7 = GetMaxCustomerId7(cnn) + 1;
        //            for (var i = 0; i < customerData.Items.Count; i++)
        //            {
        //                customerData.Items[i].IDCLIENTE = customerData.Header.IDCLIENTE;
        //                customerData.Items[i].ID_CLI_ENTREGA = customerId7 + i;
        //                customerData.Items[i].Log_Date = DateTime.Today;
        //                customerData.Items[i].Log_User = Environment.UserName;
        //                db.T0007_CLI_ENTREGA.Add(customerData.Items[i]);
        //            }
        //            db.SaveChanges();
        //            CreateCtaCteRecordL1L2(customerData.Header.IDCLIENTE,cnn);
        //        }
        //        else
        //        {
        //            var data = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == customerData.Header.IDCLIENTE);
        //            db.Entry(data).CurrentValues.SetValues(customerData.Header);
        //            var customerId7 = GetMaxCustomerId7(cnn) + 1; 
        //            for (var i = 0; i < customerData.Items.Count; i++)
        //            {
        //                if (customerData.Items[i].ID_CLI_ENTREGA == 0)
        //                {
        //                    //Este shipto es nuevo
        //                    customerData.Items[i].IDCLIENTE = customerData.Header.IDCLIENTE;
        //                    customerData.Items[i].ID_CLI_ENTREGA = customerId7;
        //                    customerData.Items[i].Log_Date = DateTime.Today;
        //                    customerData.Items[i].Log_User = Environment.UserName;
        //                    db.T0007_CLI_ENTREGA.Add(customerData.Items[i]);
        //                    customerId7 ++;
        //                }
        //                else
        //                {

        //                    //Este shipto es viejo >> update
        //                    var idCliente = customerData.Items[i].IDCLIENTE;
        //                    var idClienteShipto = customerData.Items[i].ID_CLI_ENTREGA;
        //                    var dataShipto = db.T0007_CLI_ENTREGA.SingleOrDefault(c => c.IDCLIENTE == idCliente && c.ID_CLI_ENTREGA == idClienteShipto);
        //                    db.Entry(dataShipto).CurrentValues.SetValues(customerData.Items[i]);
        //                }
        //            }
        //            db.SaveChanges();
        //            CreateCtaCteRecordL1L2(customerData.Header.IDCLIENTE,cnn);
        //        }
        //       return true;
        //    }
        //}
    }
}