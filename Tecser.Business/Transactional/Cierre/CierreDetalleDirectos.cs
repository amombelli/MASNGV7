using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.Cierre
{
    public class CierreDetalleDirectos
    {
        public List<DsCierreDetalleCompraDirectos> GetListadoDirectos(string periodo, string lx)
        {
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            DateTime fechaF = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo);
            fechaF = fechaF.AddDays(1).AddSeconds(-1);
            //
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (lx == "L1" || lx == "L2")
                {
                    var data = from child in db.T0404_VENDOR_FACT_I
                        where child.GL.StartsWith("1.0.4") &&
                              (child.T0403_VENDOR_FACT_H.FECHA >= fechaI &&
                               child.T0403_VENDOR_FACT_H.FECHA <= fechaF) && child.T0403_VENDOR_FACT_H.TIPO == lx
                        join prov in db.T0005_MPROVEEDORES on child.T0403_VENDOR_FACT_H.IDPROV equals prov.id_prov
                        select new DsCierreDetalleCompraDirectos()
                        {
                            periodo = periodo,
                            IdProv = child.T0403_VENDOR_FACT_H.IDPROV,
                            RazonSocial = prov.prov_rsocial,
                            NumeroDoc = child.T0403_VENDOR_FACT_H.NFACTURA,
                            TD = child.T0403_VENDOR_FACT_H.TFACTURA,
                            GLI = child.GL,
                            GLAP = child.T0403_VENDOR_FACT_H.GLAP,
                            Cantidad = child.CANT ?? 0,
                            Material = child.ITEM_DESC,
                            PrecioU = child.PUNIT_ARS ?? 0,
                            PrecioTotal = child.PTOTAL_ARS ?? 0,
                            TipoProveedor = prov.TIPO,
                            FechaConta = child.T0403_VENDOR_FACT_H.FECHA
                        };
                    return data.ToList();
                }
                else
                {
                    var data = from child in db.T0404_VENDOR_FACT_I
                        where child.GL.StartsWith("1.0.4") &&
                              (child.T0403_VENDOR_FACT_H.FECHA >= fechaI &&
                               child.T0403_VENDOR_FACT_H.FECHA <= fechaF)
                        join prov in db.T0005_MPROVEEDORES on child.T0403_VENDOR_FACT_H.IDPROV equals prov.id_prov
                        select new DsCierreDetalleCompraDirectos()
                        {
                            periodo = periodo,
                            IdProv = child.T0403_VENDOR_FACT_H.IDPROV,
                            RazonSocial = prov.prov_rsocial,
                            NumeroDoc = child.T0403_VENDOR_FACT_H.NFACTURA,
                            TD = child.T0403_VENDOR_FACT_H.TFACTURA,
                            GLI = child.GL,
                            GLAP = child.T0403_VENDOR_FACT_H.GLAP,
                            Cantidad = child.CANT ?? 0,
                            Material = child.ITEM_DESC,
                            PrecioU = child.PUNIT_ARS ?? 0,
                            PrecioTotal = child.PTOTAL_ARS ?? 0,
                            TipoProveedor = prov.TIPO,
                            FechaConta = child.T0403_VENDOR_FACT_H.FECHA
                        };
                    return data.ToList();
                }
            }
        }
    }
}
