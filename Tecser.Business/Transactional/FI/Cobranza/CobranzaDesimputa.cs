using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO.Costos;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{

    public struct FacturasDesimputar
    {
        public int IdCtaCteFactura;
        public int IdFactura400;
        public decimal MontoDesimputar;
    };

    /// <summary>
    /// 2021.05.25
    /// Clase para manejar desimputacion
    /// Referenciarse a clase CobranzaManager/CobranzaManagerExt2 
    /// </summary>
    public class CobranzaDesimputa
    {

        /// <summary>
        /// Informa el monto de Imputacion de un recibo en todas las facturas
        /// Return 0 si no hay imputacion
        /// </summary>
        public decimal CheckMontoImputadoPorRecibo(int idCobranza)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0207_SPLITFACTURAS.Where(c => c.IDCOB == idCobranza).ToList();
                return data.Any() ? data.Sum(c => c.MontoImputado) : 0;
            }
        }


        /// <summary>
        /// Desimputa una cobranza completa en todas las facturas
        /// </summary>
        public bool DesimputarCobranzaCompleta(int idCobranza)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<FacturasDesimputar> aDesimputar = new List<FacturasDesimputar>();
                var cobiH = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCobranza);
                if (cobiH == null)
                    return false;

                var data = db.T0207_SPLITFACTURAS.Where(c => c.IDCOB == idCobranza).ToList();
                if (!data.Any())
                    return false;

                var ctacteCobranza = db.T0201_CTACTE.SingleOrDefault(c =>
                    c.IDT2 == idCobranza && c.TDOC == "CO" && c.IDCLI == cobiH.IdCliente.Value);
                if (ctacteCobranza == null)
                    return false;

                var montoImputado = data.Sum(c => c.MontoImputado);
                decimal importeDesimputado = 0;
                if (montoImputado > 0)
                {
                    foreach (var ix in data)
                    {
                        //ver funcion desimputa facturaCobranza(
                        var i = new FacturasDesimputar
                        {
                            IdCtaCteFactura = ix.IDCTACTE,
                            MontoDesimputar = ix.MontoImputado,
                            IdFactura400 = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == ix.IDCTACTE).IDT1.Value
                        };

                        importeDesimputado += ix.MontoImputado;
                        ix.MontoImputado = 0;
                        ix.NRECIBO = null;
                        ix.PFECHA = null;
                        ix.IDCOB = null;
                        ix.TipoDocCancel = null;
                        ix.DiasImpu = null;
                        ix.DiasPPCob = null;
                        ix.NumeroDoc = null;
                        ix.USDImpu = null;
                        if (ix.CLIENTE != cobiH.IdCliente.Value)
                            return false;
                        aDesimputar.Add(i);
                    }

                    db.SaveChanges();

                    foreach (var ii in aDesimputar)
                    {
                        var factura = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == ii.IdCtaCteFactura);
                        factura.SALDOFACTURA += ii.MontoDesimputar;
                        db.SaveChanges();
                    }

                    cobiH.DOC_DESIMPUTADO = true;
                    db.SaveChanges();

                    ctacteCobranza.SALDOFACTURA = ctacteCobranza.IMPORTE_ARS;
                    ctacteCobranza.DiasPImputacion = null;
                    ctacteCobranza.DiasPAcreditacion = null;
                    db.SaveChanges();

                    var data208 = db.T0208_COB_NO_APLICADA.Where(c => c.IDRECIBO == idCobranza).ToList();
                    if (data208.Any())
                    {
                        db.T0208_COB_NO_APLICADA.RemoveRange(data208);
                        db.SaveChanges();
                    }

                    var tx208 = new T0208_COB_NO_APLICADA()
                    {
                        ID = db.T0208_COB_NO_APLICADA.Max(c => c.ID) + 1,
                        CLIENTE = cobiH.IdCliente,
                        IDRECIBO = idCobranza,
                        IDNCD = null,
                        NRECIBO = cobiH.NRECIBO,
                        FECHA = cobiH.FECHA,
                        MONEDA = cobiH.MON,
                        MONTO = cobiH.Monto,
                        TIPOCUENTA = cobiH.CUENTA,
                        TIPODOC = "COB",
                        IDCTACTE = ctacteCobranza.IDCTACTE
                    };
                    db.T0208_COB_NO_APLICADA.Add(tx208);
                    db.SaveChanges();

                    foreach (var ii in aDesimputar)
                    {
                        var top = db.T0140_MargenOperacion.Where(c => c.IdFactura == ii.IdFactura400).ToList();
                        foreach (var iop in top)
                        {
                            iop.DiasAcreditacionValores = null;
                            iop.DiasReciboPago = null;
                            iop.PrecioCobradoTotal = 0;
                            iop.PorcentajeCobrado = 0;
                        }

                        db.SaveChanges();
                        new MargenDocument().UpdateStatusCobranza(ii.IdFactura400);
                    }

                    return true;
                }
                return false;
            }
        }






        public bool TieneImputacionRealizada(int idCtaCteDocumento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteDocumento);
                return r.SALDOFACTURA != r.IMPORTE_ORI;
            }
        }

        /// <summary>
        /// Obtiene IdCtaCte desde IdFactura T400
        /// Retorna -1 si no hay info de IdCtaCte
        /// </summary>
        public int GetIdCtaCteFromIdDocumento(int idDocumento400)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idDocumento400);
                if (r?.IdCtaCte == null)
                    return -1;
                return r.IdCtaCte.Value;
            }
        }



        /// <summary>
        /// Desimputacion de un documento (Factura/ND/NC?)
        /// </summary>
        //Desimputacion del documento Factura/NC/ND
        //Puede tener mas de una cobranza asociado
        public bool DesimputaDocumento(int idCtaCteDocumentoADesimputar)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacte = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteDocumentoADesimputar);
                if (ctacte == null) return false;
                if (ctacte.IMPORTE_ORI == ctacte.SALDOFACTURA) return false;
                var c207 = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCteDocumentoADesimputar).ToList();
                if (!c207.Any()) return false;

                foreach (var i in c207)
                {
                    if (i.IDCOB != null || i.IDNC != null)
                    {
                        if (i.ImporteAImputar == 0)
                        {
                            //No esta imputado no hay nada para hacer en esta linea
                        }
                        else
                        {
                            if (i.MontoImputado != i.ImporteAImputar)
                            {
                                //se trata de un error
                                return false;
                            }

                            //Monto Imputar == Importe a Imputar
                            ctacte.SALDOFACTURA += i.ImporteAImputar;
                            i.MontoImputado = 0;
                            i.NRECIBO = null;
                            i.PFECHA = null;
                            i.IDDOC = null;
                            i.XCOMENTARIO += i.XCOMENTARIO + "@Desimputado";
                            i.TipoDocCancel = null;
                            i.DiasPPCob = null;
                            i.DiasImpu = null;
                            i.USDImpu = 0;
                            if (i.IDCOB != null)
                            {
                                //Se imputo desde un Recibo --> Reset Cobranza
                                var cob = db.T0201_CTACTE.SingleOrDefault(c => c.TDOC == "CO" && c.IDT2 == i.IDCOB.Value);
                                cob.SALDOFACTURA += i.ImporteAImputar * -1;

                                //Add Registro sin Imputar
                                var d208 = db.T0208_COB_NO_APLICADA.FirstOrDefault(c => c.IDRECIBO == i.IDCOB.Value);
                                if (d208 == null)
                                {
                                    new CobranzaNoImputada().AddSinImputarRecord(cob.IDCTACTE, i.ImporteAImputar);
                                    //var x208 = new T0208_COB_NO_APLICADA()
                                    //{
                                    //    FECHA = cob.Fecha.Value,
                                    //    CLIENTE = cob.IDCLI,
                                    //    ID = db.T0208_COB_NO_APLICADA.Max(c => c.ID) + 1,
                                    //    IDRECIBO = i.IDCOB.Value,
                                    //    MONTO = i.ImporteAImputar,
                                    //    TIPOCUENTA = cob.TIPO,
                                    //    TIPODOC = "COB",
                                    //    IDCTACTE = cob.IDCTACTE,
                                    //    NRECIBO = cob.DOC_INTERNO,
                                    //    MONEDA = cob.MONEDA,
                                    //    IDNCD = null,
                                    //};
                                    //db.T0208_COB_NO_APLICADA.Add(x208);
                                }
                                else
                                {
                                    d208.MONTO += i.ImporteAImputar;
                                }
                            }
                            else
                            {
                                //tiene una NC asociada
                                var aNc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == i.IDNC.Value);
                                var idCtaCte1 = aNc.idCtaCte.Value;
                                var aCtaCteNc = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte1);
                                aCtaCteNc.SALDOFACTURA = i.ImporteAImputar * -1;

                                //Add Registro sin Imputar
                                var d208 = db.T0208_COB_NO_APLICADA.FirstOrDefault(c =>
                                    c.IDNCD == i.IDNC.Value);
                                if (d208 == null)
                                {
                                    new CobranzaNoImputada().AddSinImputarRecord(idCtaCte1, i.ImporteAImputar);
                                    //var x208 = new T0208_COB_NO_APLICADA()
                                    //{
                                    //    FECHA = aNc.FECHA,
                                    //    CLIENTE = aNc.IdCliente,
                                    //    ID = db.T0208_COB_NO_APLICADA.Max(c => c.ID) + 1,
                                    //    IDRECIBO = aNc.IDH,
                                    //    MONTO = i.ImporteAImputar,
                                    //    TIPOCUENTA = aNc.LX,
                                    //    TIPODOC = "NC",
                                    //    IDCTACTE = idCtaCte1,
                                    //    NRECIBO = aNc.NDOC,
                                    //    MONEDA = aNc.MON,
                                    //    IDNCD = i.IDNC.Value,
                                    //};
                                    //db.T0208_COB_NO_APLICADA.Add(x208);
                                }
                                else
                                {
                                    d208.MONTO += i.ImporteAImputar;
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                }
                return true;
            }
        }
    }
}
