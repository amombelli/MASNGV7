using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.MasterData.Customer
{
    //Funciones simples y optimizadas para GetData
    public class CustomerMng2
    {
        public enum OrderBy1
        {
            RazonSocial,
            Fantasia,
            Id,
        };

        public List<StxCustomerSimple> GetCustomerList(bool onlyActive, OrderBy1 ordenadoPor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                IQueryable<StxCustomerSimple> lst;
                if (onlyActive)
                {
                    lst = from cliente in db.T0006_MCLIENTES
                        where cliente.ACTIVO == true
                        select new StxCustomerSimple()
                        {
                            IdCliente = cliente.IDCLIENTE,
                            RazonSocial = cliente.cli_rsocial,
                            Fantasia = cliente.cli_fantasia,
                            Cuit = cliente.CUIT,
                            Activo = cliente.ACTIVO
                        };
                }
                else
                {
                    lst = from cliente in db.T0006_MCLIENTES
                        where cliente.ACTIVO == true
                        select new StxCustomerSimple()
                        {
                            IdCliente = cliente.IDCLIENTE,
                            RazonSocial = cliente.cli_rsocial,
                            Fantasia = cliente.cli_fantasia,
                            Cuit = cliente.CUIT,
                            Activo = cliente.ACTIVO
                        };
                }

                switch (ordenadoPor)
                {
                    case OrderBy1.RazonSocial:
                        return lst.OrderBy(c => c.RazonSocial).ToList();
                    case OrderBy1.Fantasia:
                        return lst.OrderBy(c => c.Fantasia).ToList();
                    case OrderBy1.Id:
                        return lst.OrderBy(c => c.IdCliente).ToList();
                    default:
                        return lst.OrderBy(c => c.IdCliente).ToList();
                        throw new ArgumentOutOfRangeException(nameof(ordenadoPor), ordenadoPor, null);
                }
            }
        }
    }
    public class StxCustomerSimple
    {
        public int IdCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Fantasia { get; set; }
        public string Cuit { get; set; }
        public bool Activo { get; set; }
    }
}
