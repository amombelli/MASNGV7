using System.Collections;
using System.Linq;
using TecserEF.Entity;

namespace TecserSQL.Data.TransactionalData
{
    public class SalesOrderDataManager
    {
        public SalesOrderDataManager(string conn)
        {
            GlobalApp.CnnApp = conn;
        }

        private static class GlobalApp
        {
            public static string CnnApp;
        }

        public IList ListSalesOrderbyClienteT6(int idClienteT6)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from cli in db.T0007_CLI_ENTREGA
                            join so in db.T0045_OV_HEADER on cli.ID_CLI_ENTREGA equals so.CLIENTE
                            where cli.IDCLIENTE == idClienteT6
                            orderby so.IDOV descending
                            select new { so.IDOV, so.FECHA_OV, so.MetodoIngreso, so.StatusOV, so.StatusEN };
                return query.ToList();
            }

        }


        //public SalesOrder GetCompleteSalesOrder(int soNumber)
        //{

        //    var so = new SalesOrder
        //    {
        //        Header = new Repository<T0045_OV_HEADER>(new TecserData(GlobalApp.CnnApp)).Get(soNumber),
        //        Item = new Repository<T0046_OV_ITEM>(new TecserData(GlobalApp.CnnApp)).GetAll().Where(c => c.IDOV == soNumber).ToList()
        //    };

        //    return so;
        //}

        public int NextSalesOrderId()
        {
            return new TecserData(GlobalApp.CnnApp).T0045_OV_HEADER.Max(c => c.IDOV) + 1;
        }

        //public bool SaveSalesOrder(SalesOrder so)
        //{
        //    using (var db = new TecserData(GlobalApp.CnnApp))
        //    {
        //        if (so.Header.IDOV == 0)
        //        {
        //            //Nueva sales order
        //            //Agrega automaticamente los datos del LOG
        //            so.Header.LOG_USER = System.Environment.UserName;
        //            so.Header.LOG_FECHA = DateTime.Now;
        //            so.Header.IDOV = NextSalesOrderId();
        //            db.T0045_OV_HEADER.Add(so.Header);
        //            for (var i = 0; i < so.Item.Count; i++)
        //            {
        //                so.Item[i].IDOV = so.Header.IDOV;
        //                db.T0046_OV_ITEM.Add(so.Item[i]);
        //            }

        //        }
        //        else
        //        {
        //            //Update sales order header
        //            var result = db.T0045_OV_HEADER.SingleOrDefault(b => b.IDOV == so.Header.IDOV);
        //            db.Entry(result).CurrentValues.SetValues(so.Header);
        //            var resultI = db.T0046_OV_ITEM.Where(c => c.IDOV == so.Header.IDOV).ToList();
        //            for (int a = 0; a < resultI.Count(); a++)
        //            {
        //                db.Entry(resultI[a]).CurrentValues.SetValues(so.Item[a]);
        //            }

        //            if (so.Item.Count() > resultI.Count())
        //            {
        //                for (int a = resultI.Count(); a < (so.Item.Count()); a++)
        //                {
        //                    db.T0046_OV_ITEM.Add(so.Item[a]);
        //                }
        //            }
        //        }

        //        return db.SaveChanges() > 0;
        //    }
        //}

    }
}


