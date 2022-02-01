using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.Cierre
{
    public class ComprasGastosMensual
    {
        public List<DsCierreComprasGastos> GetListadoCompras(string periodo, string lx)
        {
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            DateTime fechaF = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo);
            fechaF = fechaF.AddDays(1).AddSeconds(-1);
            //
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rtn = new List<DsCierreComprasGastos>();
                if (lx == "L1" || lx == "L2")
                {
                    var dataA = (from t403 in db.T0403_VENDOR_FACT_H
                        where t403.TIPO == lx && (t403.FECHA>=fechaI && t403.FECHA <=fechaF)
                        join t203 in db.T0203_CTACTE_PROV on t403.IDCTACTE equals t203.IDCTACTE into lista1
                        from j1 in lista1.DefaultIfEmpty()
                        join tprov in db.T0005_MPROVEEDORES on t403.IDPROV equals tprov.id_prov into lista2
                        from j2 in lista2.DefaultIfEmpty()
                        select new DsCierreComprasGastos()
                        {
                            NumeroDoc = t403.NFACTURA,
                            IdFactura = t403.IDINT,
                            IdCtaCte = j1.IDCTACTE,
                            Fecha = t403.FECHA,
                            RazonSocial = j2.prov_rsocial,
                            Cuit = j2.NTAX1,
                            Lx = t403.TIPO,
                            IBaseImpo = t403.BaseImponible,
                            Periodo = periodo,
                            TotalKg = t403.CANTKG ?? 0,
                            TD = t403.TFACTURA,
                            Iiva21 = t403.IVA21,
                            InetoFinal = t403.NETO,
                            IBruto = t403.BRUTO,
                            Iiva10 = t403.IVA10,
                            Iiva27 = t403.IVA27,
                            IConceptoNoGrav = t403.ConceptosNoGravados,
                            IDescuento = t403.DTO,
                            IimpMunicipal = t403.ImpuestoMunicipal,
                            IimpProvincial = t403.ImpuestoProvincial,
                            IimpOtros = t403.IMPOTR,
                            IimpInternos = t403.IMPINT,
                            Iredondeo = t403.RedondeoFinal,
                            IpercGs = t403.PerGS,
                            IpercIIBB = t403.PerIIBB,
                            IimpuestoNoDeducTotal =
                                t403.ImpuestoMunicipal + t403.ImpuestoProvincial + t403.IMPINT + t403.IMPOTR,
                            IivaTotal = t403.IVA10 + t403.IVA21 + t403.IVA27,
                            ApercGs = t403.PerGA_Alicuota ?? 0,
                            ApercIIBB = t403.PerIIBB_Alicuota ?? 0,
                            LogUser = t403.LOGUSER,
                            LogFecha = t403.FECHA,
                            TCode = t403.TCODE,
                            TipoProveedor = j2.T0014_TIPO_PROVEEDOR.TIPOPROV,
                            GLap = (t403.GLAP == null || t403.GLAP == "0.0.0.0")
                                ? j2.T0014_TIPO_PROVEEDOR.GL
                                : t403.GLAP,
                            StatusDocumento = t403.StatusDocumento,
                            IsGasto = false,
                            SaldoPendienteHoy = j1.SALDOFACTURA,
                            ApercIva = t403.PerIVA_Alicuota ?? 0,
                            IpercIva = t403.PerIVA,
                        }).ToList();
                    return dataA;
                }
                else
                {
                    return rtn;
                }
            }
        }
    }

    //                   from


                //           var dataJoin = (from data401 in db.T0401_FACTURA_I
                //                    where data401.T0400_FACTURA_H.TIPOFACT == lx &&
                //                          (data401.T0400_FACTURA_H.FECHA >= fechaI && data401.T0400_FACTURA_H.FECHA <= fechaF) &&
                //                          data401.T0400_FACTURA_H.TIPO_DOC != "DX"
                //                    group data401 by data401.IDFactura
                //        into g
                //                    select new
                //                    {
                //                        xId = g.Key,
                //                        Kg = g.Sum(c => c.KGDESPACHADOS_R.Value)
                //                    });

                //    var data = (from t400 in db.T0400_FACTURA_H
                //                where t400.TIPOFACT == lx && (t400.FECHA >= fechaI && t400.FECHA <= fechaF) &&
                //                      t400.TIPO_DOC != "DX"
                //                join t201 in db.T0201_CTACTE on t400.IdCtaCte equals t201.IDCTACTE into list1
                //                from dataJ1 in list1.DefaultIfEmpty()
                //                join tcliente in db.T0006_MCLIENTES on t400.Cliente equals tcliente.IDCLIENTE into list2
                //                from dataJ2 in list2.DefaultIfEmpty()
                //                join dataKg in dataJoin on t400.IDFACTURA equals dataKg.xId into list3
                //                from dataJkg in list3.DefaultIfEmpty()
                //                select new DsCierreVentas()
                //                {
                //                    IdFactura = t400.IDFACTURA,
                //                    IdCtaCte = dataJ1.IDCTACTE,
                //                    NumeroDoc = t400.NumeroDoc,
                //                    Fecha = t400.FECHA,
                //                    RazonSocial = dataJ2.cli_rsocial,
                //                    Cuit = t400.CUIT,
                //                    Lx = t400.TIPOFACT,
                //                    Tdoc = t400.TIPO_DOC,
                //                    Periodo = periodo,
                //                    NumeroRemito = t400.Remito,
                //                    Localidad = dataJ2.Direfactu_Localidad,
                //                    Provincia = dataJ2.Direfactu_Provincia,
                //                    KgVendidos = dataJkg.Kg,
                //                    CaeNumero = t400.CAE,
                //                    CaeVencimiento = t400.CAE_VTO,
                //                    BaseImponible = t400.TotalImpo,
                //                    AlicuotaArba = t400.IIBB_PORC ?? 0,
                //                    ImporteIva21 = t400.TotalIVA21,
                //                    ImportePercArba = t400.TotalIIBB,
                //                    ImporteBruto = t400.TotalFacturaB,
                //                    ImporteNeto = t400.TotalFacturaN,
                //                }).ToList();
                //    return data;
                //}
                //return lrtx;
        //    }
        //}
}
