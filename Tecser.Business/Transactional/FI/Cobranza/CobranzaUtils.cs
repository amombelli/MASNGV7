using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    public struct DiasImputacion
    {
        public int? DiasPP_FacturaRecibo;
        public int? DiasPP_ReciboPago;
        public bool ImputacionCompleta;
        public bool ErrorDetectado;
    }

    public struct EstadisticasCobro
    {
        public bool ValidacionPorcPago; //True si valores son consistentes
        public decimal ArsValorImpuestos;
        public decimal ArsValorProductos;
        public decimal ArsCobradoImpuestos;
        public decimal ArsCobradoProductos;
        public decimal ArsTotalCobrado;  //Valor Total Imputado a Factura
        public decimal PorcPagoTotalArs;
        public decimal ArsSaldoImpago; //Saldo Impago Documento
        public decimal PorcPagoImpuestos; //PorcentajePagoImpuestos
        public decimal PorcPagoProductos; //PorcentajePagoProductos
        public decimal UsdValorProductos;
        public decimal UsdValorImpuestos;
        public decimal UsdCobradoProductos;
        public decimal UsdTotalCobrado;
        public decimal XratePp;
    }
    public class CobranzaUtils
    {
        public List<T0207_SPLITFACTURAS> GetListaImputacionPorCtaCteFactura(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCte).OrderBy(c => c.FACTSPLIT).ToList();
            }
        }
        public List<T0207_SPLITFACTURAS> GetListaImputacionPorRecibo(int idCobranza)
        {
            string idCobRecibo = idCobranza.ToString();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0207_SPLITFACTURAS.Where(c => c.IDCOB == idCobranza).OrderBy(c => c.IDCTACTE).ToList();
            }
        }
        public string GetReciboOficialSucursal()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T000.SingleOrDefault(c => c.ID == "SUCRECL1").VALUE;
            }
        }
        public string GetNextReciboOficial()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rofi = db.T000.SingleOrDefault(c => c.ID == "NUMRECL1");
                int numero = Convert.ToInt32(rofi.VALUE);
                numero = numero + 1;
                return numero.ToString("D8");
            }
        }
        public void SaveUltimoReciboUtilizado(string numeroRecibo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rofi = db.T000.SingleOrDefault(c => c.ID == "NUMRECL1");
                rofi.VALUE = numeroRecibo;
                db.SaveChanges();
            }
        }
        public int FixCobranzaDiasPp()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cob = db.T0205_COBRANZA_H.Where(c => c.DIAS_PP == null || c.DIAS_PP == 0).OrderByDescending(c => c.IDCOB).Take(300).ToList();
                foreach (var lst in cob)
                {
                    var r = db.T0206_COBRANZA_I.Where(c => c.IDCOB == lst.IDCOB).ToList();
                    if (r.Count > 0)
                    {
                        var dias = CalculaDiasPromedioPago(r, lst.FECHA);
                        lst.DIAS_PP = dias;
                    }
                }
                return db.SaveChanges();

            }
        }

        public int CalculaDiasPromedioPago(List<T0206_COBRANZA_I> list, DateTime fechaRecibo)
        {
            decimal diasPP = 0;
            decimal importeComputo = 0;

            foreach (var it in list)
            {
                //aqui deben ir todas las cuentas disponibles para un recibo 
                //solo se computan para calculo de dias PP lo que no es bono
                switch (it.CUENTA)
                {
                    case "ARS":
                        importeComputo += it.IMP_RECIBO;
                        break;
                    case "CHE":
                        importeComputo += it.IMP_RECIBO;
                        break;
                    case "USD":
                        importeComputo += it.IMP_RECIBO;
                        break;
                    case "GAL":
                        importeComputo += it.IMP_RECIBO;
                        break;
                    case "SAN":
                        importeComputo += it.IMP_RECIBO;
                        break;
                    case "ICBC":
                        importeComputo += it.IMP_RECIBO;
                        break;
                    case "BAF":
                        break;
                    case "RGA":
                        break;
                    case "RIB":
                        break;
                    case "RIVA":
                        break;
                    case "COM":
                        //lo que se ingrese por COM lo computaremos como EFE?
                        importeComputo += it.IMP_RECIBO;
                        break;
                    default:
                        MessageBox.Show(
                            $@"Cuenta {it.CUENTA} No manejada por la aplicacion. Notifique a AM con urgencia si ha visto este mensaje",
                            @"Cuenta No Manejada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }

            foreach (var it in list)
            {
                var diasCh = 0;
                if (it.CHEQUE_FECHA == null)
                {
                    diasCh = 0;
                }
                else
                {
                    TimeSpan ts = it.CHEQUE_FECHA.Value - fechaRecibo;
                    if (ts.Days < 0)
                    {
                        diasCh = 0;
                    }
                    else
                    {
                        diasCh = ts.Days;
                    }
                }
                diasPP = diasPP + (diasCh * it.IMP_RECIBO);
            }
            if (importeComputo == 0)
                return 0;
            return Convert.ToInt32(diasPP / importeComputo);
        }
        public int CalculoDiasPromedioPago(int idCob)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fechaCob = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCob).FECHA;
                var listCobranza = db.T0206_COBRANZA_I.Where(c => c.IDCOB == idCob).ToList();
                return CalculaDiasPromedioPago(listCobranza, fechaCob);
            }
        }
        public void GuardaDiasPP_TCobranza(int idCob, int diasPP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCob);
                x.DIAS_PP = diasPP;
                db.SaveChanges();
            }
        }
        public T0201_CTACTE GetT0201FromCobranza(int idCob)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0201_CTACTE.SingleOrDefault(c => c.TDOC == "CO" && c.IDT2 == idCob);
                return data;
            }
        }

        public DiasImputacion DiasPromedioPagoFacturaImputada(int idCtaCte)
        {

            DiasImputacion rtn;
            rtn.DiasPP_FacturaRecibo = null;
            rtn.DiasPP_ReciboPago = null;
            rtn.ImputacionCompleta = false;
            rtn.ErrorDetectado = false;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cc = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);

                if (cc?.SALDOFACTURA != 0)
                {
                    //Si el documento no esta imputada al 100% no realiza calculo y retorna null.
                    return rtn;
                }

                rtn.ImputacionCompleta = true; //SalldoFactura ==0

                if (cc.TDOC == "FA" || cc.TDOC == "ND")
                {

                }
                else
                {
                    if (cc.TDOC == "AJ")
                    {
                        rtn.ErrorDetectado = false;
                        rtn.DiasPP_FacturaRecibo = 0;
                        rtn.DiasPP_ReciboPago = 0;
                    }

                    //Si el documento no es FA o ND no realiza calculo
                    //Esta condicion debiera ser un error porque solo se pueden imputar FA/ND
                    rtn.ErrorDetectado = true;
                    return rtn;
                }

                var importeDoc = cc.IMPORTE_ORI;
                var data207 = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCte && c.MontoImputado != 0)
                    .ToList();
                decimal accImpu = 0;
                decimal accRecibo = 0;
                decimal importeCk = 0;
                foreach (var d207 in data207)
                {
                    if (d207.PFECHA == null)
                        d207.PFECHA = DateTime.Today;
                    //Esto es un FIX por las dudas pero a la fecha 2019-04-03 no hay ningun issue.

                    var difPagoFact = (d207.PFECHA.Value - cc.Fecha.Value);
                    var diasPagoFactura = difPagoFact.Days;
                    accImpu += (diasPagoFactura * d207.MontoImputado);
                    importeCk += d207.MontoImputado;

                    if (d207.IDCOB != null)
                    {
                        var idCob = Convert.ToInt32(d207.IDCOB.Value);
                        var diasRecibo = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCob);
                        if (diasRecibo.DIAS_PP == null)
                        {
                            rtn.DiasPP_ReciboPago = null;
                        }
                        else
                        {
                            accRecibo += (diasRecibo.DIAS_PP.Value * d207.MontoImputado);
                        }
                    }
                    else
                    {
                        rtn.DiasPP_ReciboPago = null;
                    }
                    if (importeDoc == 0) return rtn;
                    rtn.DiasPP_FacturaRecibo = Convert.ToInt32(accImpu / importeDoc);
                    rtn.DiasPP_ReciboPago = Convert.ToInt32(accRecibo / importeDoc);
                }
                return rtn;
            }
        }
        public DiasImputacion GetInfoDiasPPFromTable201(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rtn = new DiasImputacion();
                var info = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                rtn.DiasPP_FacturaRecibo = info.DiasPImputacion;
                rtn.DiasPP_ReciboPago = info.DiasPAcreditacion;
                return rtn;
            }
        }
        public void SetInfoDiasPPToTable201(int idCtaCte, int? diasFacturaRecibo, int? diasReciboPago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var info = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                info.DiasPImputacion = diasFacturaRecibo;
                info.DiasPAcreditacion = diasFacturaRecibo;
                db.SaveChanges();
            }
        }



        /// <summary>
        /// Funcion que calcula de una Factura el % de Pago/Imputacion y su TC Real PP a fecha de Recibo Pago
        /// El % Total de Pago es en Pesos (como se contabiliza) pero el importe pagado en USD podria ser menor de acuerdo al TC de Cobranza
        /// </summary>
        public EstadisticasCobro GetValorImputacion(int idFactura)
        {
            var rtn = new EstadisticasCobro()
            {
                ArsTotalCobrado = 0,
                ArsValorImpuestos = 0,
                ArsValorProductos = 0,
                UsdValorProductos = 0,
                UsdValorImpuestos = 0,
                PorcPagoTotalArs = 0,
                ArsSaldoImpago = 0,
                ArsCobradoImpuestos = 0,
                ArsCobradoProductos = 0,
                UsdCobradoProductos = 0,
                UsdTotalCobrado = 0,
                XratePp = 1,
                PorcPagoImpuestos = 0,
                ValidacionPorcPago = false,
                PorcPagoProductos = 0,
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var facH = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                var ctacte = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == facH.IdCtaCte.Value);
                var imputacion = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == facH.IdCtaCte.Value && c.MontoImputado > 0).ToList();
                if (facH == null)
                    return rtn;

                decimal valorFacturaARS = facH.TotalFacturaN;
                decimal valorFacturaUSD = Math.Round(facH.TotalFacturaN / facH.TC, 2);  //Tipo de Cambio Facturacion

                rtn.ArsTotalCobrado = ctacte.IMPORTE_ARS - ctacte.SALDOFACTURA;
                rtn.ArsValorImpuestos = facH.TotalIIBB + facH.TotalIVA21;
                rtn.ArsValorProductos = facH.TotalFacturaN - rtn.ArsValorImpuestos;
                rtn.UsdValorImpuestos = Math.Round(rtn.ArsValorImpuestos / facH.TC, 3);
                rtn.UsdValorProductos = Math.Round(rtn.ArsValorProductos / facH.TC, 3);
                rtn.ArsSaldoImpago = ctacte.SALDOFACTURA;

                decimal valorImputacion207 = imputacion.Sum(c => c.MontoImputado);
                if (rtn.ArsTotalCobrado != valorImputacion207)
                {
                    //No Coincide el valor de lo cobrado entre la T201  y la sumatorio T207
                    return rtn;
                }

                if (facH.TotalFacturaN == 0)
                {
                    //se puede tratar de una entrega s/c
                    rtn.ArsTotalCobrado = 0;
                    rtn.UsdTotalCobrado = 0;
                    rtn.PorcPagoProductos = 1;
                    rtn.PorcPagoImpuestos = 1;
                    rtn.PorcPagoTotalArs = 1;
                    rtn.XratePp = facH.TC;
                    rtn.ValidacionPorcPago = true;
                    return rtn;
                }
                else
                {
                    rtn.PorcPagoTotalArs = Math.Round(rtn.ArsTotalCobrado / facH.TotalFacturaN, 5);//porcentaje pago pesos
                }

                decimal saldoImpuestos = rtn.ArsValorImpuestos;
                decimal valorPago207 = 0;
                decimal valorPagadoProductosARS = 0;
                decimal valorPagadoProductosUSD = 0;
                decimal porcentajePagoProductos = 0;
                decimal porcentajePagoImpuestos = 0;

                //Primero salda Impuestos de la factura y Luego Salda los Productos (ARS)
                foreach (var ximpu in imputacion)
                {
                    valorPago207 += ximpu.MontoImputado;
                    decimal valorImputarAProductos = 0;
                    if (saldoImpuestos > 0)
                    {
                        //Primero salda los Impuestos
                        if (ximpu.MontoImputado >= saldoImpuestos)
                        {
                            valorImputarAProductos = ximpu.MontoImputado - saldoImpuestos;
                            saldoImpuestos = 0;
                        }
                        else
                        {
                            saldoImpuestos = saldoImpuestos - ximpu.MontoImputado;
                        }
                    }
                    else
                    {
                        //Impuestos ya han sido cubiertos -> Imputa directo a Productos
                        valorImputarAProductos = ximpu.MontoImputado;
                    }

                    decimal cobTC = new ExchangeRateManager().GetExchangeRate(ximpu.FECHA_FACT);
                    //voy a recalcular el valor USD de la cobranza porque veo diferencias - chequear
                    if (ximpu.IDCOB != null)
                    {
                        var xcob = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == ximpu.IDCOB.Value);
                        if (xcob != null)
                        {
                            cobTC = xcob.TC;
                            ximpu.USDImpu = Math.Round(ximpu.MontoImputado / xcob.TC, 3);
                        }
                    }
                    else
                    {
                        if (ximpu.USDImpu == null || ximpu.USDImpu == 0)
                        {
                            //Esto es una especie de FIX porque las NC viene con TC Null
                            ximpu.USDImpu = Math.Round(ximpu.MontoImputado / cobTC, 3);
                        }
                    }
                    valorPagadoProductosARS += valorImputarAProductos;
                    valorPagadoProductosUSD += Math.Round(valorImputarAProductos / cobTC, 3);
                    rtn.ArsCobradoImpuestos += rtn.ArsValorImpuestos - saldoImpuestos;
                    rtn.ArsCobradoProductos += valorImputarAProductos;
                    rtn.UsdCobradoProductos = valorPagadoProductosUSD;
                    rtn.UsdTotalCobrado += ximpu.USDImpu.Value;
                }
                db.SaveChanges();  //update valor USDImpu
                rtn.ValidacionPorcPago = valorPago207 == rtn.ArsTotalCobrado;
                rtn.PorcPagoImpuestos = rtn.ArsValorImpuestos == 0 ? 1 : Math.Round(rtn.ArsCobradoImpuestos / rtn.ArsValorImpuestos, 5);
                rtn.PorcPagoProductos = rtn.ArsValorProductos == 0 ? 1 : Math.Round(rtn.ArsCobradoProductos / rtn.ArsValorProductos, 5);
                if (rtn.UsdTotalCobrado == 0)
                {
                    rtn.XratePp = facH.TC;
                }
                else
                {
                    rtn.XratePp = Math.Round(rtn.ArsTotalCobrado / rtn.UsdTotalCobrado, 3);
                }
                return rtn;
            }
        }
    }
}
