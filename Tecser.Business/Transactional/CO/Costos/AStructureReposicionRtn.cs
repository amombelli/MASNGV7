using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MasterData;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class AStructureReposicionRtn
    {
        public AStructureReposicionRtn(string material=null)
        {
            PrecioArs = 9999999;
            PrecioUsd = 9999999;
            FechaUCompra = DateTime.Today.AddDays(-5);
            Proveedor = null;
            KgUCompra = 0;
            MonedaCompra = "USD";
            VendorId = 0;
            Material = material;
            XRate = 1;
        }

        public void SetVendor(int idVendor)
        {
            var p = new VendorManager().GetSpecificVendor(idVendor);
            VendorId = idVendor;
            Proveedor = p.prov_rsocial;
        }
        public string Material { get; set; }
        public string Proveedor { get; protected set; }
        public decimal KgUCompra { get; set; }
        public DateTime FechaUCompra { get; set; }
        public Decimal PrecioArs { get; set; }
        public Decimal PrecioUsd { get; set; }
        public string MonedaCompra { get; set; }
        public int VendorId { get; protected set; }
        public decimal XRate { get; set; }


    }
}
