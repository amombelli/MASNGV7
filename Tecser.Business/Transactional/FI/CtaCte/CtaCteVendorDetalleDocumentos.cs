using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.CtaCte
{
    public class CtaCteVendorDetalleDocumentos
    {
        public List<T0203_CTACTE_PROV> DetalleFacturasPendientePago(int idProveedor, string lx = null, bool soloConSaldo = true)
        {
            var lista = new List<T0203_CTACTE_PROV>();
            if (string.IsNullOrEmpty(lx) == true)
            {
                if (soloConSaldo)
                {
                    lista =
                        new TecserData(GlobalApp.CnnApp).T0203_CTACTE_PROV.Where(c => c.IDPROV == idProveedor && c.SALDOFACTURA != 0)
                            .OrderBy(c => c.Fecha).ToList();
                }
                else
                {
                    lista =
                        new TecserData(GlobalApp.CnnApp).T0203_CTACTE_PROV.Where(c => c.IDPROV == idProveedor).OrderBy(c => c.Fecha).ToList();
                }
            }
            else
            {
                if (soloConSaldo)
                {
                    lista =
                    new TecserData(GlobalApp.CnnApp).T0203_CTACTE_PROV.Where(
                        c => c.IDPROV == idProveedor && c.SALDOFACTURA != 0 && c.TIPO.ToUpper().Equals(lx.ToUpper()))
                        .OrderBy(c => c.Fecha)
                        .ToList();
                }
                else
                {
                    lista =
                    new TecserData(GlobalApp.CnnApp).T0203_CTACTE_PROV.Where(
                        c => c.IDPROV == idProveedor && c.TIPO.ToUpper().Equals(lx.ToUpper()))
                        .OrderBy(c => c.Fecha)
                        .ToList();
                }
            }
            return lista;
        }
    }
}
