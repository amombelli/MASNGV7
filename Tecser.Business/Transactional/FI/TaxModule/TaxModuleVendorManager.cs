using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.TaxModule
{
    public class TaxModuleVendorManager
    {

        public static List<T0017_TaxModuleAssign> GetTaxesForVendor(int idVendor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0017_TaxModuleAssign.Where(c => c.CP.Contains("P") && c.IdNumero == idVendor).ToList();
            }
        }
        public static T0017_TaxModuleAssign GetTaxForVendor(int idVendor, string taxId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0017_TaxModuleAssign.SingleOrDefault(c => c.CP.Contains("P") && c.IdNumero == idVendor && c.IdTax == taxId);
            }
        }
        public static void AssignTaxToVendor(int idVendor, string taxId, bool exento, DateTime fechaDesde, DateTime fechaHasta, string numeroCertificado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0017_TaxModuleAssign.SingleOrDefault(c => c.CP.Contains("P") && c.IdNumero == idVendor && c.IdTax == taxId);
                var prov = new VendorManager().GetSpecificVendor(idVendor);
                var s = new T0017_TaxModuleAssign()
                {
                    CP = "¨P",
                    IdNumero = idVendor,
                    Ntax = prov.NTAX1,
                    IdTax = taxId,
                    Exento = exento,
                    FechaDesde = fechaDesde,
                    FechaHasta = fechaHasta,
                    Certificado = numeroCertificado
                };
                if (x == null)
                {
                    db.T0017_TaxModuleAssign.Add(s);
                }
                else
                {
                    x.Ntax = prov.NTAX1;
                    x.Exento = exento;
                    x.FechaDesde = fechaDesde;
                    x.FechaHasta = fechaHasta;
                    x.Certificado = numeroCertificado;
                }
                db.SaveChanges();
            }
        }


    }
}
