using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.Customers;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    public enum ModoImputacion
    {
        Completa, //Imputa si la factura mas vieja esta completa
        HastaImporte //Imputa de mas vieja a mas nueva el importe total de la factura. (puede quedar incompleto)
    };


    public class CobranzaImputacion
    {
        //todo:cobranza sin imputar
        public List<T0208_COB_NO_APLICADA> GetCobranzasPendientesImputacion(int idCliente = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return idCliente == 0
                    ? db.T0208_COB_NO_APLICADA.ToList()
                    : db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == idCliente).ToList();
            }
        }

        //todo se calcula en propiedad con GetSaldoSinImputar
        public decimal GetSaldoAImputar208(int idCliente, string lx = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (string.IsNullOrEmpty(lx))
                {
                    var x = db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == idCliente).ToList();
                    return x.Count == 0 ? 0 : x.Sum(c => c.MONTO.Value);
                }
                else
                {
                    var x = db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == idCliente && c.TIPOCUENTA == lx).ToList();
                    return x.Count == 0 ? 0 : x.Sum(c => c.MONTO.Value);
                }

            }
        }
        public List<T0207_SPLITFACTURAS> GetDocumentosAImputar(int idCliente, string tipoLX = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (string.IsNullOrEmpty(tipoLX))
                {
                    return db.T0207_SPLITFACTURAS.Where(c => c.CLIENTE == idCliente && c.MontoImputado == 0 && c.ImporteAImputar != 0).ToList();
                }
                else
                {
                    return db.T0207_SPLITFACTURAS.Where(c => c.CLIENTE == idCliente && c.TIPO == tipoLX && c.MontoImputado == 0 && c.ImporteAImputar != 0).ToList();
                }
            }
        }
        
        
        
        public bool ImputaCobranzaAutomatica(int idCobranza, ModoImputacion modo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t208 = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.IDRECIBO == idCobranza);
                var cob201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDT2 == idCobranza);
                if (t208 == null || cob201 == null)
                    return false;

                if (t208.MONTO != (cob201.SALDOFACTURA * -1))
                    return false;

                if (t208.CLIENTE != cob201.IDCLI)
                    return false;

                var idCliente = t208.CLIENTE.Value;
                var importeImputar = t208.MONTO.Value;
                var lxImputar = t208.TIPOCUENTA;

                var fact =
                    db.T0201_CTACTE.Where(c => c.IDCLI == idCliente && c.TIPO == lxImputar && c.SALDOFACTURA > 0)
                        .OrderBy(c => c.Fecha).ToList();

                if (fact.Count == 0)
                {
                    MessageBox.Show(@"No Existen Facturas para Imputar!", @"Sin Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }


                var t0207 = new T0207_SPLITFACTURAS();
                int idctacteFact;
                decimal importeTotalImputar = 0;
                switch (modo)
                {
                    case ModoImputacion.Completa:
                        //Solo Imputa si Facturas esta completa de mas antiguo a mas nuevo
                        foreach (var fa in fact)
                        {
                            if (fa.SALDOFACTURA > importeImputar) return false;
                            idctacteFact = fa.IDCTACTE;
                            t0207 = db.T0207_SPLITFACTURAS.SingleOrDefault(c =>
                                c.IDCTACTE == idctacteFact && c.MontoImputado == 0);
                            if (t0207 == null) return false;
                            if (t0207.ImporteAImputar != fa.SALDOFACTURA) return false;
                            if (new PercepcionesManager().ValidaImputacionFacturaPermitida(idctacteFact,
                                cob201.IDCTACTE) == false) return false;
                            importeTotalImputar = importeImputar;
                            ImputarCobranza(idctacteFact, t0207.FACTSPLIT, cob201.IDCTACTE, importeTotalImputar);
                            importeTotalImputar -= fa.SALDOFACTURA;
                            if (importeTotalImputar <= 0)
                                return true;
                        }

                        break;
                    case ModoImputacion.HastaImporte:
                        //Imputa de mas vieja a mas nueva el importe total de la factura. (puede quedar incompleto)
                        foreach (var fa in fact)
                        {
                            importeTotalImputar = t208.MONTO.Value;
                            idctacteFact = fa.IDCTACTE;
                            t0207 = db.T0207_SPLITFACTURAS.SingleOrDefault(c =>
                                c.IDCTACTE == idctacteFact && c.MontoImputado == 0);
                            if (t0207 == null) return false;
                            if (t0207.ImporteAImputar != fa.SALDOFACTURA) return false;
                            if (new PercepcionesManager().ValidaImputacionFacturaPermitida(idctacteFact,
                                cob201.IDCTACTE) == false)
                                return false;
                            ImputarCobranza(idctacteFact, t0207.FACTSPLIT, cob201.IDCTACTE, importeTotalImputar);
                            importeTotalImputar -= fa.SALDOFACTURA;
                            if (importeTotalImputar <= 0)
                                return true;
                        }

                        return true;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(modo), modo, null);
                }
                return true;
            }
        }

        public bool ValidacionOKImputar(int idCtaCteImputar, int split207, int id208)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t207 = db.T0207_SPLITFACTURAS.SingleOrDefault(c => c.IDCTACTE == idCtaCteImputar && c.FACTSPLIT == split207);
                if (t207 == null)
                    return false;

                var t201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteImputar);
                if (t201 == null)
                    return false;

                var t208 = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.ID == id208);
                if (t208 == null)
                    return false;

                if (t201.TIPO != t208.TIPOCUENTA)
                    return false;

                if (t201.MONEDA != t208.MONEDA)
                    return false;

                if (t207.MontoImputado != 0)
                    return false;

                if (t207.ImporteAImputar <= 0)
                    return false;

                if (t208.IDCTACTE == null)
                {
                    MessageBox.Show(@"Debe ejecutar el FIX para agregar el IDCTACTE en T0208", @"FIX Pendiente de Ejecucion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                var t0201Cob = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == t208.IDCTACTE);
                if (t0201Cob == null)
                    return false;

                if (t0201Cob.IDCLI != t208.CLIENTE.Value)
                    return false;

                if (Math.Abs(t0201Cob.SALDOFACTURA) != Math.Abs(t208.MONTO.Value))
                {
                    MessageBox.Show(@"El Saldo de la Cobranza no coincide con el importe No imputado");
                    return false;
                }

                if (t201.TDOC !="AJ" && t201.TIPO =="L1")
                    if (new PercepcionesManager().ValidaImputacionFacturaPermitida(idCtaCteImputar, t208.IDCTACTE.Value) == false)
                    return false; //new valida de nuevo la percepcion esta ok para imputar
            }
            return true;
        }


        /// <summary>
        /// Imputar un Pago/NC a una Factura sin determinar la linea split
        /// No utilizado para imputacion COBR.-
        /// </summary>
        public bool ImputaCobranzaBasico(int idCtaCteImputar, int idCtaCtePaymentOrNc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var doc = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteImputar);
                var pay = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.IDCTACTE == idCtaCtePaymentOrNc);
                if (doc == null) return false;
                if (pay == null) return false;
                if (doc.SALDOFACTURA == 0) return false;
                var t207 = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCteImputar && c.MontoImputado == 0).ToList();
                if (!t207.Any()) return false;
                if (t207.Count > 1)
                {
                    if (new CobranzaImputacion().ConsolidaSplits207(idCtaCteImputar))
                    {
                        t207 = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCteImputar && c.MontoImputado == 0).ToList();
                        if (!t207.Any()) return false;
                    }
                }
                ImputarCobranza(idCtaCteImputar, t207[0].FACTSPLIT, pay.ID, pay.MONTO.Value);
            }
            return true;
        }

        
        public bool ImputarCobranza(int idCtaCteImputar, int split207, int id208, decimal importeImputar)
        {
            if (ValidacionOKImputar(idCtaCteImputar,split207,id208) == false)
                return false;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t207 = db.T0207_SPLITFACTURAS.SingleOrDefault(c =>
                    c.IDCTACTE == idCtaCteImputar && c.FACTSPLIT == split207);
                var t201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteImputar);
                var t208 = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.ID == id208);
                var t0201Cob = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == t208.IDCTACTE);
                decimal importeAImputarFactura;
                decimal importeRestanteCobranzaNc = 0;

                //Actualiza T0208 y Define Saldo a Imputar
                if (t201.SALDOFACTURA >= t208.MONTO.Value)
                {
                    if (importeImputar >= t208.MONTO.Value)
                    {
                        importeAImputarFactura = t208.MONTO.Value;
                        db.T0208_COB_NO_APLICADA.Remove(t208);
                    }
                    else
                    {
                        importeAImputarFactura = importeImputar;
                        t208.MONTO = t208.MONTO.Value - importeAImputarFactura;
                        importeRestanteCobranzaNc = t208.MONTO.Value;
                    }
                }
                else
                {
                    if (importeImputar >= t201.SALDOFACTURA)
                    {
                        importeAImputarFactura = t201.SALDOFACTURA;
                    }
                    else
                    {
                        importeAImputarFactura = importeImputar;
                    }
                    t208.MONTO = t208.MONTO.Value - importeAImputarFactura;
                    importeRestanteCobranzaNc = t208.MONTO.Value;
                }
                
                //Completa en T0207 Datos Recibo/Fecha Pago
                switch (t208.TIPODOC)
                {
                    case "COB":
                        var cobData = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == t208.IDRECIBO.Value);
                        t207.PFECHA = t208.FECHA;
                        t207.IDCOB = t208.IDRECIBO;
                        t207.IDNC = null;
                        t207.NRECIBO = t208.NRECIBO; //numero de Recibo o Numero de Nota de Credito
                        t207.TipoDocCancel = "COB"; //cobranza o Nota de Credito
                        t207.NumeroDoc = string.IsNullOrEmpty(cobData.NRECIBOOFI) ? cobData.NRECIBO:cobData.NRECIBOOFI;
                        t207.DiasPPCob = cobData.DIAS_PP.Value; //dias promedio de pago en la cobranza
                        t207.DiasImpu = (t208.FECHA.Value - t207.FECHA_FACT).Days;
                        t207.USDImpu = Math.Round(importeAImputarFactura/cobData.TC,2);
                        break;
                    case "NCD":
                    case "NC":
                        var idFix1 = t208.IDNCD == null ? t208.IDRECIBO.Value : t208.IDNCD.Value;
                        var ncData1 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idFix1);
                        t207.PFECHA = ncData1.FECHA;
                        t207.IDCOB = null;
                        t207.IDNC = idFix1;
                        t207.NRECIBO = t208.NRECIBO;
                        t207.TipoDocCancel = @"NC";
                        t207.NumeroDoc = t208.NRECIBO;
                        t207.DiasPPCob = 0;
                        t207.DiasImpu = (t208.FECHA.Value - t207.FECHA_FACT).Days;
                        t207.USDImpu = Math.Round(importeAImputarFactura / ncData1.TC, 2);
                        break;
                    case "AJ":
                        //se deberia comportar como NCD.- Es lo mismo.
                        var idFix2 = t208.IDNCD == null ? t208.IDRECIBO.Value : t208.IDNCD.Value;
                        var ncData2 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idFix2);
                        t207.PFECHA = ncData2.FECHA;
                        t207.IDCOB = null;
                        t207.IDNC = idFix2;
                        t207.NRECIBO = t208.NRECIBO;
                        t207.TipoDocCancel = @"AJ";
                        t207.NumeroDoc = t208.NRECIBO;
                        t207.DiasPPCob = 0;
                        t207.DiasImpu = (t208.FECHA.Value - t207.FECHA_FACT).Days;
                        t207.USDImpu = Math.Round(importeAImputarFactura / ncData2.TC, 2);
                        break;
                }

                if (t207.ImporteAImputar > importeAImputarFactura)
                {
                    //split 207
                    var newLine = new T0207_SPLITFACTURAS()
                    {
                        INTDOC = db.T0207_SPLITFACTURAS.Max(c => c.INTDOC) + 1,
                        TDOC = t207.TDOC,
                        IDCTACTE = idCtaCteImputar,
                        NDOC = t207.NDOC,
                        FACTSPLIT = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCteImputar).Max(c => c.FACTSPLIT) + 1,
                        FACT_MONEDA = t207.FACT_MONEDA,
                        ImporteDocumento = t207.ImporteDocumento,
                        ImporteAImputar = t207.ImporteAImputar - importeAImputarFactura,
                        MontoImputado = 0,
                        TIPO = t207.TIPO,
                        CLIENTE = t207.CLIENTE,
                        FECHA_FACT = t207.FECHA_FACT,
                        FECHA_VENC = t207.FECHA_VENC,
                        DIAS_VENC = t207.DIAS_VENC,
                        NRECIBO = null,
                        PFECHA = null,
                        XCOMENTARIO = null,
                        ZTERM = 0,
                        IDCOB = null,
                        IDNC = null,
                        NumeroDoc = null,
                        TipoDocCancel = null,
                        DiasPPCob = 0,
                        DiasImpu = 0,
                        USDImpu = 0,
                        IDDOC = t207.IDDOC,
                    };
                    db.T0207_SPLITFACTURAS.Add(newLine);
                    t207.ImporteAImputar = importeAImputarFactura;
                }
                t207.MontoImputado = importeAImputarFactura;
                db.SaveChanges();

                t0201Cob.SALDOFACTURA = importeRestanteCobranzaNc * -1;
                t201.SALDOFACTURA = t201.SALDOFACTURA - importeAImputarFactura;
                db.SaveChanges();

                if (t201.TIPO == "L1" && t201.TDOC !="AJ")
                {
                    if (new PercepcionesManager().ImputaPagoUpdatePercepcion(idCtaCteImputar, t208.IDCTACTE.Value) ==
                        false)
                    {
                        //MessageBox.Show(@"Ha Ocurrido un error en la imputacion de Percepciones",
                        //  @"Error en Imputacion de Percepciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                return true;
            }
        }
        
        public decimal GetSaldoImpago(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte).SALDOFACTURA;
            }
        }
        public List<T0207_SPLITFACTURAS> GetListaRecibosImputanFactura(int idCtaCteFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCteFactura).ToList();
            }
        }

        /// <summary>
        /// Funcion Chequea que una cuenta corriente imputacion este correcta
        /// </summary>
        public bool CheckFacturaSaldosImputacionOK(int idCtaCteDocumento, bool AutoConsolida=true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var c201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteDocumento);
                if (c201 == null)
                    return false;
                decimal importeDoc201 = c201.IMPORTE_ORI;
                decimal saldoImputacion = c201.SALDOFACTURA;
                decimal importePago201 = c201.IMPORTE_ORI - c201.SALDOFACTURA;
                var c207 = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCteDocumento).ToList();
                decimal importeDocSplit = 0;
                decimal importePago7 = 0;
                int ImporteCero = 0;
                foreach (var i in c207)
                {
                    if (i.ImporteDocumento != importeDoc201)
                        return false;

                    importeDocSplit += i.ImporteAImputar;

                    if (i.ImporteAImputar != i.MontoImputado)
                    {
                        if (i.MontoImputado != 0)
                            return false;
                        ImporteCero++;

                    }
                    importePago7 += i.MontoImputado;
                }

                if (importeDocSplit != importeDoc201)
                    return false;

                if (importePago7 != importePago201)
                    return false;

                if (ImporteCero > 1 && AutoConsolida)
                {
                    ConsolidaSplits207(idCtaCteDocumento);
                }
            }
            return true;
        }
        
        /// <summary>
        /// Tool - Consolida Montos T0207 (usado despues de desimputar)
        /// </summary>
        public bool ConsolidaSplits207(int idCtaCteDocumento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var c207 = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCteDocumento).ToList();
                decimal montoConsolidado = 0;
                int firstSplit = 0;
                foreach (var i in c207.Where(c => c.MontoImputado == 0).ToList())
                {
                    montoConsolidado += i.ImporteAImputar;
                    if (firstSplit == 0)
                        firstSplit = i.FACTSPLIT;
                }

                var xdel = db.T0207_SPLITFACTURAS.Where(c =>
                    c.IDCTACTE == idCtaCteDocumento && c.MontoImputado == 0 && c.FACTSPLIT != firstSplit).ToList();
                db.T0207_SPLITFACTURAS.RemoveRange(xdel);

                var xupd = db.T0207_SPLITFACTURAS.SingleOrDefault(c =>
                    c.IDCTACTE == idCtaCteDocumento && c.FACTSPLIT == firstSplit && c.MontoImputado == 0);
                xupd.ImporteAImputar = montoConsolidado;

                return db.SaveChanges() > 0;
            }
        }

    }
}
