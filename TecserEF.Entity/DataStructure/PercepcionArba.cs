using System;
using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    public class PercepcionArbaStructure
    {
        public int IdFactura { get; set; }
        public string TipoDoc { get; set; }
        public string NumDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public string TaxNum { get; set; }
        public string RazonSocial { get; set; }
        public decimal ImporteDoc { get; set; }
        public decimal ImportIIBB { get; set; }
        public decimal SaldoImpago { get; set; }
        public string RefCobranza { get; set; }
        public DateTime? FechaImputado { get; set; }
        public DateTime? FechaCobroReal { get; set; }
        public int idCtaCte { get; set; }
        public bool Presentado { get; set; }
    }

    public class ManagePercepcionArbaData
    {
        public List<PercepcionArbaStructure> GetData1(DateTime fechaD, DateTime fechaH, string globalConnection, bool soloPendiente)
        {
            using (var db = new TecserData(globalConnection))
            {
                var q = (from p in db.T0402_FACTURA_PERCEP
                         where (p.FechaImputacion >= fechaD && p.FechaImputacion <= fechaH)
                         join fx in db.T0400_FACTURA_H on new { a = p.IdFactura } equals new { a = fx.IDFACTURAX.Value }
                         select new PercepcionArbaStructure()
                         {
                             IdFactura = p.IdFactura,
                             FechaDoc = p.FechaFactura.Value,
                             NumDoc = p.NumFactura,
                             TaxNum = fx.CUIT,
                             RazonSocial = fx.RAZONSOC,
                             TipoDoc = fx.TIPO_DOC,
                             ImportIIBB = p.IIBB_Perc_ARS.Value,
                             ImporteDoc = fx.TotalFacturaN,
                             RefCobranza = p.IIBB_Perc_DocPago,
                             FechaCobroReal = p.IIBB_Perc_FechaPago,
                             FechaImputado = p.FechaImputacion,
                             Presentado = p.Informado.Value,
                             idCtaCte = p.IDCtaCte.Value,
                             SaldoImpago = p.IIBB_Perc_ARS_Saldo.Value
                         }).OrderByDescending(c => c.FechaImputado.Value).ToList();

                if (soloPendiente)
                    return q.Where(c => c.Presentado == false).ToList();
                return q;


            }
        }
    }
}
