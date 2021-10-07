using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.Cierre
{
    public class RetornaConciliacion
    {
        public string Periodo { get; set; }
        public decimal ImporteCob205 { get; set; }
        public decimal importeCob201 { get; set; }
        public decimal ImporteFa400 { get; set; }
        public decimal ImporteFa201 { get; set; }
        public bool OkCob { get; set; }
        public bool OkFactu { get; set; }
        public decimal ImporteFa { get; set; }
        public decimal ImporteNc { get; set; }
        public decimal ImporteNd { get; set; }
        public decimal ImporteAj { get; set; }
    }
    public class ConciliaGeneral
    {
        public List<RetornaConciliacion> ConciliaDesde(string periodoInicial, int cantidadPeriodos, string tipoLx, bool includeFa = true, bool includeNc = true, bool includeNd = true, bool includeAj = true)
        {
            var rtn = new List<RetornaConciliacion>();
            var periodo = periodoInicial;
            for (var i = 0; i < cantidadPeriodos; i++)
            {
                rtn.Add(ResultadoCuentasGeneral(periodo, tipoLx, includeFa, includeNc, includeNd, includeAj));
                periodo = new PeriodoConversion().GetProximoPeriodo(periodo);
            }
            return rtn;
        }
        public RetornaConciliacion ResultadoCuentasGeneral(string periodo, string tipoLx, bool includeFa = true, bool includeNc = true, bool includeNd = true, bool includeAj = true)
        {
            var fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            var fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1); //traia problemas con el ultimo dia + horas
            var rtn = new RetornaConciliacion
            {
                Periodo = periodo,
                ImporteAj = 0,
                ImporteCob205 = 0,
                ImporteFa = 0,
                ImporteNc = 0,
                OkCob = false,
                OkFactu = false,
                ImporteFa201 = 0,
                ImporteFa400 = 0,
                ImporteNd = 0,
                importeCob201 = 0
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cob205Lst = new List<T0205_COBRANZA_H>();
                var cob201Lst = new List<T0201_CTACTE>();
                var fac400Lst = new List<T0400_FACTURA_H>();

                var fac201Lst = new List<T0201_CTACTE>();
                var t400Tmp = new List<T0400_FACTURA_H>();
                var t201Tmp = new List<T0201_CTACTE>();


                //** Listado de Cobranzas ** 
                cob205Lst = db.T0205_COBRANZA_H
                    .Where(c => c.FECHA >= fechaI && c.FECHA < fechaD && c.DOC_CANCELADO == false)
                    .ToList();
                cob201Lst = db.T0201_CTACTE
                    .Where(c => c.Fecha >= fechaI && c.Fecha < fechaD && c.TDOC == "CO" && c.CK != "False").ToList();

                // ** facturas/NC/ND/AJ ** 
                if (includeFa)
                {
                    t400Tmp.Clear();
                    t400Tmp = db.T0400_FACTURA_H.Where(c =>
                        c.FECHA >= fechaI && c.FECHA < fechaD &&
                        (c.TIPO_DOC == "FA" || c.TIPO_DOC == "FB" || c.TIPO_DOC == "FM")).ToList();

                    fac400Lst.AddRange(
                        t400Tmp.Where(c => c.StatusFactura == "APROBADA" && c.TIPOFACT == "L1").ToList());
                    fac400Lst.AddRange(
                        t400Tmp.Where(c => c.StatusFactura == "Aprobada" && c.TIPOFACT == "L2").ToList());
                    //Compatibilidad anterior
                    //fac400List.AddRange(t400tmp.Where(c => c.StatusFactura == "Registrada" && c.TIPOFACT == "L2").ToList());
                    //fac400List.AddRange(t400tmp.Where(c => c.StatusFactura == "REGISTRAD" && c.TIPOFACT == "L1").ToList());

                    fac201Lst.AddRange(db.T0201_CTACTE.Where(c =>
                        c.Fecha >= fechaI && c.Fecha < fechaD && (c.TDOC == "FA" || c.TDOC == "FB" || c.TDOC == "FM") &&
                        c.CK != "False").ToList());
                }

                if (includeNc)
                {
                    t400Tmp.Clear();
                    t400Tmp = db.T0400_FACTURA_H.Where(c =>
                        c.FECHA >= fechaI && c.FECHA < fechaD &&
                        (c.TIPO_DOC == "NC" || c.TIPO_DOC == "CM")).ToList();

                    fac400Lst.AddRange(
                        t400Tmp.Where(c => c.StatusFactura == "APROBADA" && c.TIPOFACT == "L1").ToList());
                    fac400Lst.AddRange(
                        t400Tmp.Where(c => c.StatusFactura == "Aprobada" && c.TIPOFACT == "L2").ToList());

                    fac201Lst.AddRange(db.T0201_CTACTE.Where(c =>
                        c.Fecha >= fechaI && c.Fecha < fechaD && (c.TDOC == "NC" || c.TDOC == "CM") &&
                        c.CK != "False").ToList());
                }

                if (includeNd)
                {
                    t400Tmp.Clear();
                    t400Tmp = db.T0400_FACTURA_H.Where(c =>
                        c.FECHA >= fechaI && c.FECHA < fechaD &&
                        (c.TIPO_DOC == "ND" || c.TIPO_DOC == "DM")).ToList();

                    fac400Lst.AddRange(
                        t400Tmp.Where(c => c.StatusFactura == "APROBADA" && c.TIPOFACT == "L1").ToList());
                    fac400Lst.AddRange(
                        t400Tmp.Where(c => c.StatusFactura == "Aprobada" && c.TIPOFACT == "L2").ToList());

                    fac201Lst.AddRange(db.T0201_CTACTE.Where(c =>
                        c.Fecha >= fechaI && c.Fecha < fechaD && (c.TDOC == "ND" || c.TDOC == "DM") &&
                        c.CK != "False").ToList());
                }

                var ajx = new List<T0300_NCD_H>();
                if (includeAj)
                {
                    //Los Ajustes no estan en T0400 trae de T0300
                    ajx = db.T0300_NCD_H.Where(c => c.FECHA >= fechaI && c.FECHA < fechaD && c.TDOC == "AJ")
                        .ToList();
                    //
                    fac201Lst.AddRange(db.T0201_CTACTE.Where(c =>
                        c.Fecha >= fechaI && c.Fecha < fechaD && (c.TDOC == "AJ") &&
                        c.CK != "False").ToList());
                }

                switch (tipoLx)
                {
                    case "L3":
                        rtn.ImporteAj = ajx.Sum(c => c.ImporteARS) == null ? 0 : ajx.Sum(c => c.ImporteARS);
                        rtn.ImporteCob205 = cob205Lst.Sum(c => c.Monto);
                        rtn.importeCob201 = cob201Lst.Sum(c => c.IMPORTE_ARS) * -1;
                        t400Tmp = fac400Lst;
                        t201Tmp = fac201Lst;
                        break;
                    case "L1":
                        rtn.ImporteAj = ajx.Where(c => c.LX == "L1").Sum(c => c.ImporteARS) == null
                            ? 0
                            : ajx.Where(c => c.LX == "L1").Sum(c => c.ImporteARS);
                        rtn.ImporteCob205 = cob205Lst.Where(c => c.CUENTA == "L1").Sum(c => c.Monto);
                        rtn.importeCob201 = cob201Lst.Where(c => c.TIPO == "L1").Sum(c => c.IMPORTE_ARS) * -1;
                        t400Tmp = fac400Lst.Where(c => c.TIPOFACT == "L1").ToList();
                        t201Tmp = fac201Lst.Where(c => c.TIPO == "L1").ToList();
                        break;
                    case "L2":
                        rtn.ImporteAj = ajx.Where(c => c.LX == "L2").Sum(c => c.ImporteARS) == null
                            ? 0
                            : ajx.Where(c => c.LX == "L1").Sum(c => c.ImporteARS);
                        rtn.ImporteCob205 = cob205Lst.Where(c => c.CUENTA == "L2").Sum(c => c.Monto);
                        rtn.importeCob201 = cob201Lst.Where(c => c.TIPO == "L2").Sum(c => c.IMPORTE_ARS) * -1;
                        t400Tmp = fac400Lst.Where(c => c.TIPOFACT == "L2").ToList();
                        t201Tmp = fac201Lst.Where(c => c.TDOC == "L2").ToList();
                        break;
                }

                decimal fa = 0;
                decimal nc = 0;
                decimal nd = 0;
                decimal aj = 0;

                foreach (var i in t400Tmp)
                {
                    switch (i.TIPO_DOC)
                    {
                        case "FA":
                            fa += i.TotalFacturaN;
                            break;
                        case "FM":
                            fa += i.TotalFacturaN;
                            break;
                        case "FB":
                            fa += i.TotalFacturaN;
                            break;
                        case "NC":
                            nc -= i.TotalFacturaN;
                            break;
                        case "ND":
                            nd += i.TotalFacturaN;
                            break;
                        case "DM":
                            nd += i.TotalFacturaN;
                            break;
                        case "CM":
                            nc -= i.TotalFacturaN;
                            break;
                        case "DB":
                            nd += i.TotalFacturaN;
                            break;
                        case "CB":
                            nc -= i.TotalFacturaN;
                            break;
                        case "AJ":
                            aj += rtn.ImporteAj;
                            //atencion no hay ajustes en T0400 - 
                            break;
                        default:
                            break;
                    }
                }
                rtn.ImporteFa = fa;
                //rtn.ImporteAj = aj;
                rtn.ImporteNc = nc;
                rtn.ImporteNd = nd;
                rtn.ImporteFa400 = fa + nd + nc + aj;
                rtn.ImporteFa201 = t201Tmp.Sum(c => c.IMPORTE_ARS);
                var totalFactu201 = t201Tmp.Sum(c => c.IMPORTE_ARS);
                rtn.OkFactu = rtn.ImporteFa400 == (rtn.ImporteFa201 - rtn.ImporteAj);
                rtn.OkCob = rtn.importeCob201 == rtn.ImporteCob205;
                return rtn;
            }
        }

        public List<T0400_FACTURA_H> RetornaListaDocumentosPeriodo(string periodo, string tipoLx, bool includeFa = true,
            bool includeNc = true, bool includeNd = true, bool includeAj = true)
        {
            List<T0400_FACTURA_H> rtn = new List<T0400_FACTURA_H>();
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            DateTime fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);//para evitar problemas con las horas pasadas del ultimo dia
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //ver si hay que agregar distinto de status=registrada
                var lista400_ =
                    db.T0400_FACTURA_H.Where(c => c.TIPOFACT == tipoLx && c.FECHA >= fechaI && c.FECHA < fechaD).ToList();


                var lista400 = new List<T0400_FACTURA_H>();
                lista400.AddRange(lista400_.Where(c => c.StatusFactura.ToUpper() == "REGISTRADA"));
                lista400.AddRange(lista400_.Where(c => c.StatusFactura.ToUpper() == "APROBADA"));


                if (includeFa)
                {
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "FA").ToList());
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "R2").ToList());
                }


                if (includeNc)
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "NC").ToList());

                if (includeNd)
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "ND").ToList());

                if (includeAj)
                {
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "AJ").ToList());
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "AJ+").ToList());
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "AJ-").ToList());
                }
                return rtn;
            }
        }
    }
}
