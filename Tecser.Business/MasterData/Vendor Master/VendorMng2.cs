using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.Vendor_Master
{
    //Funciones simple y optimizadas para GetData 
    //2021.11.04
    public class VendorMng2
    {
        public enum OrderBy1
        {
            RazonSocial,
            Fantasia,
            Id,
            VendorType
        };

        public List<StxVendnorSimple> GetVendorList(bool onlyActive, OrderBy1 ordenadoPor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                IQueryable<StxVendnorSimple> lst;
                if (onlyActive)
                {
                    lst = from vendor in db.T0005_MPROVEEDORES
                          where vendor.ACTIVO == true
                          select new StxVendnorSimple()
                          {
                              VendorId = vendor.id_prov,
                              RazonSocial = vendor.prov_rsocial,
                              Fantasia = vendor.prov_fantasia,
                              Cuit = vendor.NTAX1,
                              Activo = vendor.ACTIVO.Value,
                              VendorType = vendor.TIPO
                          };
                }
                else
                {
                    lst = from vendor in db.T0005_MPROVEEDORES
                          where vendor.ACTIVO == true
                          select new StxVendnorSimple()
                          {
                              VendorId = vendor.id_prov,
                              RazonSocial = vendor.prov_rsocial,
                              Fantasia = vendor.prov_fantasia,
                              Cuit = vendor.NTAX1,
                              Activo = vendor.ACTIVO.Value,
                              VendorType = vendor.TIPO
                          };
                }

                switch (ordenadoPor)
                {
                    case OrderBy1.RazonSocial:
                        return lst.OrderBy(c => c.RazonSocial).ToList();
                    case OrderBy1.Fantasia:
                        return lst.OrderBy(c => c.Fantasia).ToList();
                    case OrderBy1.Id:
                        return lst.OrderBy(c => c.VendorId).ToList();
                    case OrderBy1.VendorType:
                        return lst.OrderBy(c => c.VendorType).ToList();
                    default:
                        return lst.OrderBy(c => c.VendorId).ToList();
                        throw new ArgumentOutOfRangeException(nameof(ordenadoPor), ordenadoPor, null);
                }
            }
        }
    }

    public class StxVendnorSimple
    {
        public int VendorId { get; set; }
        public string RazonSocial { get; set; }
        public string Fantasia { get; set; }
        public string Cuit { get; set; }
        public bool Activo { get; set; }
        public string VendorType { get; set; }
    }
}
