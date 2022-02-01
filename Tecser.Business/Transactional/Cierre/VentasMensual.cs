using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.Cierre
{
    public class VentasMensual
    {
        public List<DsCierreVentas> GetListadoVentasMensual(string periodo, string lx)
        {
            var lrtx = new List<DsCierreVentas>();
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            DateTime fechaF = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo);
            fechaF = fechaF.AddDays(1).AddSeconds(-1);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (lx == "L1" || lx == "L2")
                {
                    var dataJoin = (from data401 in db.T0401_FACTURA_I
                        where data401.T0400_FACTURA_H.TIPOFACT == lx &&
                              (data401.T0400_FACTURA_H.FECHA >= fechaI && data401.T0400_FACTURA_H.FECHA <= fechaF) &&
                              data401.T0400_FACTURA_H.TIPO_DOC != "DX"
                        group data401 by data401.IDFactura
                        into g
                        select new
                        {
                            xId = g.Key,
                            Kg = g.Sum(c => c.KGDESPACHADOS_R.Value)
                        });
                    
                    var data = (from t400 in db.T0400_FACTURA_H
                        where t400.TIPOFACT == lx && (t400.FECHA >= fechaI && t400.FECHA <= fechaF) &&
                              t400.TIPO_DOC != "DX"
                        join t201 in db.T0201_CTACTE on t400.IdCtaCte equals t201.IDCTACTE into list1
                        from dataJ1 in list1.DefaultIfEmpty()
                        join tcliente in db.T0006_MCLIENTES on t400.Cliente equals tcliente.IDCLIENTE into list2
                    from dataJ2 in list2.DefaultIfEmpty()
                        join dataKg in dataJoin on t400.IDFACTURA equals dataKg.xId into list3
                        from dataJkg in list3.DefaultIfEmpty()
                    select new DsCierreVentas()
                    {
                        IdFactura = t400.IDFACTURA,
                        IdCtaCte = dataJ1.IDCTACTE,
                        NumeroDoc = t400.NumeroDoc,
                        Fecha = t400.FECHA,
                        RazonSocial = dataJ2.cli_rsocial,
                        Cuit = t400.CUIT,
                        Lx = t400.TIPOFACT,
                        Tdoc = t400.TIPO_DOC,
                        Periodo = periodo,
                        NumeroRemito = t400.Remito,
                        Localidad = dataJ2.Direfactu_Localidad,
                        Provincia = dataJ2.Direfactu_Provincia,
                        KgVendidos = dataJkg.Kg,
                        CaeNumero = t400.CAE,
                        CaeVencimiento = t400.CAE_VTO,
                        BaseImponible = t400.TotalImpo,
                        AlicuotaArba = t400.IIBB_PORC ?? 0,
                        ImporteIva21 = t400.TotalIVA21,
                        ImportePercArba = t400.TotalIIBB,
                        ImporteBruto = t400.TotalFacturaB,
                        ImporteNeto = t400.TotalFacturaN,
                    }).ToList();
                    return data;
                }
                return lrtx;
            }
        }
    }
}
