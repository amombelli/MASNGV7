using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using System.Data.Entity;

namespace Tecser.Business.Transactional.FI.ContabilizacionProveedores
{

    public class StxVendorDocPP
    {
        public string TDoc { get; set; }
        public string NDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdVendor { get; set; }
        public string RazonSocial { get; set; }
        public string Moneda { get; set; }
        public decimal ImporteDoc { get; set; }
        public decimal ImporteDeuda { get; set; }
        public string Lx { get; set; }
        public int IdCtaCte { get; set; }
    }

    public class DetalleDocumentosPP
    {

        public DetalleDocumentosPP()
        {
            
        }

        public List<StxVendorDocPP> GetDocumentList(int? idVendor, string lx, bool soloPendientePago = true)
        {
            if (lx == "L0") return new List<StxVendorDocPP>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<StxVendorDocPP> lista;
                if (idVendor == null)
                {
                    var p = from ctacte in db.T0203_CTACTE_PROV
                        select new StxVendorDocPP()
                        {
                            RazonSocial = ctacte.T0005_MPROVEEDORES.prov_rsocial,
                            Moneda = ctacte.MONEDA,
                            Lx = ctacte.TIPO,
                            IdVendor = ctacte.IDPROV,
                            TDoc = ctacte.TDOC,
                            FechaDoc = ctacte.Fecha,
                            NDoc = ctacte.NUMDOC,
                            ImporteDoc = ctacte.IMPORTE_ARS,
                            ImporteDeuda = ctacte.SALDOFACTURA,
                            FechaVencimiento = ctacte.ZTERM == null ? DbFunctions.AddDays(ctacte.Fecha, 60).Value : DbFunctions.AddDays(ctacte.Fecha, ctacte.ZTERM.Value).Value,
                            IdCtaCte = ctacte.IDCTACTE
                        };
                    lista = p.ToList();
                }
                else
                {
                    lista = db.T0203_CTACTE_PROV.Where(ctacte => ctacte.IDPROV == idVendor.Value)
                        .Select(ctacte => new StxVendorDocPP()
                        {
                            RazonSocial = ctacte.T0005_MPROVEEDORES.prov_rsocial,
                            Moneda = ctacte.MONEDA,
                            Lx = ctacte.TIPO,
                            IdVendor = ctacte.IDPROV,
                            TDoc = ctacte.TDOC,
                            FechaDoc = ctacte.Fecha,
                            NDoc = ctacte.NUMDOC,
                            ImporteDoc = ctacte.IMPORTE_ARS,
                            ImporteDeuda = ctacte.SALDOFACTURA,
                            FechaVencimiento = ctacte.ZTERM==null? DbFunctions.AddDays(ctacte.Fecha,60).Value:DbFunctions.AddDays(ctacte.Fecha,ctacte.ZTERM.Value).Value,
                            IdCtaCte = ctacte.IDCTACTE
                        }).ToList();
                }

                if (lx =="L1" || lx =="L2")
                {
                    lista = lista.Where(c => c.Lx == lx).ToList();
                }
                if (soloPendientePago)
                    return lista.Where(c => c.ImporteDeuda != 0).OrderBy(c => c.FechaVencimiento).ToList();
                return lista.OrderBy(c=>c.FechaVencimiento).ToList();
            }
        }
        
    }
}
