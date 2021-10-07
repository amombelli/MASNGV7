using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.Cierre
{
    public class ConciliacionSaldoVendor203Vs204
    {

        public List<StructureConcil203> CheckDiferenciasOrigen203()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataFrom203 = from s203 in db.T0203_CTACTE_PROV
                                  where s203.SALDOFACTURA.Value != 0
                                  group s203 by new
                                  {
                                      IdProv = s203.IDPROV,
                                      TipoLx = s203.TIPO,
                                      Rsocial = s203.T0005_MPROVEEDORES.prov_rsocial,
                                      VendorType = s203.T0005_MPROVEEDORES.TIPO,
                                  } into grp203
                                  select new StructureConcil203()
                                  {
                                      RazonSocial = grp203.Key.Rsocial,
                                      Saldo203 = grp203.Sum(c => c.SALDOFACTURA.Value),
                                      Saldo204 = 0,
                                      TipoLX = grp203.Key.TipoLx,
                                      VendorId = grp203.Key.IdProv,
                                      Diferencia = 0,
                                      VendorType = grp203.Key.VendorType
                                  };
                var lista203 = dataFrom203.ToList();

                var dataFrom204 = from s204 in db.T0204_CTACTESALDOS_PROV
                                  where s204.DEUDA_TOT_ARS.Value != 0
                                  group s204 by new
                                  {
                                      IdProv = s204.IDPROV,
                                      TipoLx = s204.CUENTATIPO,
                                      Rsocial = s204.T0005_MPROVEEDORES.prov_rsocial,
                                      VendorType = s204.T0005_MPROVEEDORES.TIPO,
                                  } into grp204
                                  select new StructureConcil203()
                                  {
                                      RazonSocial = grp204.Key.Rsocial,
                                      Saldo203 = 0,
                                      Saldo204 = grp204.Sum(c => c.DEUDA_TOT_ARS.Value),
                                      TipoLX = grp204.Key.TipoLx,
                                      VendorId = grp204.Key.IdProv,
                                      Diferencia = 0,
                                      VendorType = grp204.Key.VendorType
                                  };
                var lista204 = dataFrom204.ToList();

                var newList = from l203 in lista203
                              join l204 in lista204
                                  on new { l203.VendorId, l203.TipoLX } equals new { l204.VendorId, l204.TipoLX } into tempJoin
                              from ln in tempJoin.DefaultIfEmpty()
                              select new StructureConcil203()
                              {
                                  VendorId = l203.VendorId,
                                  VendorType = l203.VendorType,
                                  RazonSocial = l203.RazonSocial,
                                  Saldo203 = l203.Saldo203,
                                  Saldo204 = ln != null ? ln.Saldo204 : 0,
                                  TipoLX = l203.TipoLX,
                                  Diferencia = l203.Saldo203 - (ln != null ? ln.Saldo204 : 0)
                              };
                var xx = newList.ToList();
                return xx;
            }
        }
        public List<StructureConcil203> CheckDiferenciasOrigen204()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataFrom203 = from s203 in db.T0203_CTACTE_PROV
                                  where s203.SALDOFACTURA.Value != 0
                                  group s203 by new
                                  {
                                      IdProv = s203.IDPROV,
                                      TipoLx = s203.TIPO,
                                      Rsocial = s203.T0005_MPROVEEDORES.prov_rsocial,
                                      VendorType = s203.T0005_MPROVEEDORES.TIPO,
                                  } into grp203
                                  select new StructureConcil203()
                                  {
                                      RazonSocial = grp203.Key.Rsocial,
                                      Saldo203 = grp203.Sum(c => c.SALDOFACTURA.Value),
                                      Saldo204 = 0,
                                      TipoLX = grp203.Key.TipoLx,
                                      VendorId = grp203.Key.IdProv,
                                      Diferencia = 0,
                                      VendorType = grp203.Key.VendorType
                                  };
                var lista203 = dataFrom203.ToList();

                var dataFrom204 = from s204 in db.T0204_CTACTESALDOS_PROV
                                  where s204.DEUDA_TOT_ARS.Value != 0
                                  group s204 by new
                                  {
                                      IdProv = s204.IDPROV,
                                      TipoLx = s204.CUENTATIPO,
                                      Rsocial = s204.T0005_MPROVEEDORES.prov_rsocial,
                                      VendorType = s204.T0005_MPROVEEDORES.TIPO,
                                  } into grp204
                                  select new StructureConcil203()
                                  {
                                      RazonSocial = grp204.Key.Rsocial,
                                      Saldo203 = 0,
                                      Saldo204 = grp204.Sum(c => c.DEUDA_TOT_ARS.Value),
                                      TipoLX = grp204.Key.TipoLx,
                                      VendorId = grp204.Key.IdProv,
                                      Diferencia = 0,
                                      VendorType = grp204.Key.VendorType
                                  };
                var lista204 = dataFrom204.ToList();

                var newList = from l204 in lista204
                              join l203 in lista203
                                  on new { l204.VendorId, l204.TipoLX } equals new { l203.VendorId, l203.TipoLX } into tempJoin
                              from ln in tempJoin.DefaultIfEmpty()
                              select new StructureConcil203()
                              {
                                  VendorId = l204.VendorId,
                                  VendorType = l204.VendorType,
                                  RazonSocial = l204.RazonSocial,
                                  Saldo203 = ln != null ? ln.Saldo203 : 0,
                                  Saldo204 = l204.Saldo204,
                                  TipoLX = l204.TipoLX,
                                  Diferencia = (ln != null ? ln.Saldo203 : 0) - l204.Saldo204
                              };
                var xx = newList.ToList();
                return xx;
            }
        }



    }







    /// <summary>
    /// Estructura para mostrar conciliacion entre T203 y T204
    /// </summary>
    public partial class StructureConcil203
    {
        public int VendorId { get; set; }
        public string RazonSocial { get; set; }
        public string TipoLX { get; set; }
        public string VendorType { get; set; }
        public decimal Saldo203 { get; set; }
        public decimal Saldo204 { get; set; }
        public decimal Diferencia { get; set; }
    }
}

