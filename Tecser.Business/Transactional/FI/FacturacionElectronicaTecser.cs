using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using TecserEF.Entity;
using WebServicesAFIP;


namespace Tecser.Business.Transactional.FI
{
    public class FacturacionElectronicaTecser
    {
        public FacturacionElectronicaTecser(ModoEjecucion modoEjecucion)
        {
            _modoEjecucion = modoEjecucion;
        }
        //------------------------------------------------------------------------------------------------
        private readonly ModoEjecucion _modoEjecucion;
        private FESetDataStructure _dataFE = new FESetDataStructure(); 
        //------------------------------------------------------------------------------------------------
        public struct CheckNumeroComprobantes
        {
            public bool UltimoComprobanteIsOk { get; set; }
            public int UltimoComprobanteMAS { get; set; }
            public int UltimoComrobanteAFIP { get; set; }
        }
        private TipoComprobante Map_TDoc_TipoComprobante(string tdoc)
        {
            switch (tdoc)
            {
                case "FA":
                    return TipoComprobante.Factura;
                case "NC":
                   return TipoComprobante.NotaCredito;
                case "ND":
                    return TipoComprobante.NotaDebito;
                case "FM":
                    return TipoComprobante.FacturaM;
                case "CM":
                    return TipoComprobante.NotaCreditoM;
                case "DM":
                    return TipoComprobante.NotaDebitoM;
                default:
                    return TipoComprobante.NoDefinido;
            }
        }
        public bool CheckSiPermiteSolicitarCAE(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (data == null)
                    return false;

                if (data.TIPOFACT != "L1")
                    return false;

                if (!string.IsNullOrEmpty(data.CAE))
                    return false;

                if (data.StatusFactura.ToUpper() != DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString().ToUpper())
                    return false;

                //if (!string.IsNullOrEmpty(data.PV_AFIP))
                //{
                //    if (data.PV_AFIP != "0000")
                //        return false;
                //}

                //if (!string.IsNullOrEmpty(data.ND_AFIP))
                //{
                //    if (data.ND_AFIP != "00000000")
                //        return false;
                //}

                if (!string.IsNullOrEmpty(data.CAE))
                    return false;
                return true;
            }
        }
        private  void AddComprobanteAsociado(int idFacturaAsociadaNC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idFacturaAsociadaNC > 1)
                {
                    //Tiene un comprobante asociado
                    var docAsoc = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFacturaAsociadaNC);
                    var tx = Map_TDoc_TipoComprobante(docAsoc.TIPO_DOC);
                    if (tx == TipoComprobante.NoDefinido)
                    {
                        _dataFE.CompAsociadoNumero = @"0";
                        _dataFE.CompAsociadoPtoVta = @"0";
                        _dataFE.CompAsociadoTipo = tx;
                    }
                    else
                    {
                        //puede ser documento asociado o periodo al que aplica pero no ambos
                        _dataFE.CompAsociadoTipo = Map_TDoc_TipoComprobante(docAsoc.TIPO_DOC);
                        _dataFE.CompAsociadoNumero = docAsoc.ND_AFIP;
                        _dataFE.CompAsociadoPtoVta = docAsoc.PV_AFIP;
                        _dataFE.CompAsociadoFechaPeriodoDesde = null;
                        _dataFE.CompAsociadoFechaPeriodoHasta = null;
                    }
                }
            }
        }
        private void AddComprobanteAsociadoFechaPeriodo(DateTime fechaDesde, DateTime fechaHasta)
        {
            //puede ser documento o periodo pero no ambos
            _dataFE.CompAsociadoTipo = TipoComprobante.NoDefinido;
            _dataFE.CompAsociadoNumero = @"0";
            _dataFE.CompAsociadoPtoVta = @"0";
            _dataFE.CompAsociadoFechaPeriodoDesde = fechaDesde.ToString("yyyyMMdd");
            _dataFE.CompAsociadoFechaPeriodoHasta = fechaHasta.ToString("yyyyMMdd");
        }
        private FESetDataStructure CompletaEstructuraFE(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var doc = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                var data = new FESetDataStructure();
                if (doc == null) return data;
                if (doc.Descuento == null) doc.Descuento = 0;

                //Por cambio de signo en NC
                doc.TotalFacturaN = Math.Abs(doc.TotalFacturaN);
                doc.TotalFacturaB = Math.Abs(doc.TotalFacturaB);
                doc.Descuento = Math.Abs(doc.Descuento.Value);
                doc.TotalImpo = Math.Abs(doc.TotalImpo);
                doc.TotalIVA21 = Math.Abs(doc.TotalIVA21);
                doc.TotalIIBB = Math.Abs(doc.TotalIIBB);

                //Existe el documento.
                if (doc.TIPOFACT == "L1")
                {
                    data.Concepto = 1; //Productos
                    data.TipoDocumento = 80; //80 = CUIT (NTAX1)
                    data.NumeroDocumento = doc.CUIT; //Numero CUIT
                    data.TipoComprobante = Map_TDoc_TipoComprobante(doc.TIPO_DOC);
                    data.PuntoVenta = 4; //todo: localizar en tabla 
                    data.ImporteTotal = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalFacturaN);
                    decimal noGrav = (doc.TotalFacturaB - doc.Descuento.Value - doc.TotalImpo);
                    data.ImporteNoGravado = FormatAndConversions.DefineFormatoNumericoAFIP(noGrav);

                    //Importe Total
                    data.BaseImponible = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalImpo);
                    //No va el Neto porque es la base imponible
                    //IVA
                    data.ImporteIVA = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalIVA21);
                    var structIva = new TributosAfip();
                    if (doc.TotalIVA21 > 0)
                    {
                        //IVA es por ahora solo IVA21  
                        structIva.IdTributo = "5"; //21%
                        structIva.BaseImponible = data.BaseImponible;
                        structIva.Importe = data.ImporteIVA;
                    }
                    else
                    {
                        structIva.IdTributo = "3"; //0%
                        structIva.BaseImponible = "0.00";
                        structIva.Importe = "0.00";
                    }

                    data.IvaDetalle.Add(structIva);

                    //Manejo de Ingresos Brutos Provincia Buenos Aires
                    data.ImporteTributos = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalIIBB);
                    if (doc.TotalIIBB > 0)
                    {
                        var structIIBB = new TributosAfip
                        {
                            IdTributo = "2",
                            Alicuota = FormatAndConversions.DefineFormatoNumericoAFIP(doc.IIBB_PORC * 100),
                            Descripcion = "Percep IIBB Pcia Bs As",
                            BaseImponible = data.BaseImponible,
                            Importe = data.ImporteTributos
                        };
                        data.TributosDetalle.Add(structIIBB);
                    }

                    data.FechaComprobante = doc.FECHA;
                    data.ImporteNeto = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalImpo);
                    //>>Este no se informa >> se informa Base Imponible

                    if (doc.FacturaMoneda == "ARS")
                    {
                        data.MonedaId = "PES";
                        data.Cotizacion = "1.000";
                    }
                    else
                    {
                        data.MonedaId = "";
                        data.Cotizacion = "";
                    }

                    //Los comprobantes asociados se agregan luego con otros metodos de esta clase
                    data.CompAsociadoTipo = TipoComprobante.NoDefinido;
                    data.CompAsociadoNumero = @"0";
                    data.CompAsociadoPtoVta = @"0";
                    data.CompAsociadoFechaPeriodoDesde = null;
                    data.CompAsociadoFechaPeriodoHasta = null;
                    return data;
                }
                else
                {
                    throw new Exception("Tipo Factura no corresponde a solicitud de CAE");
                }
            }
        }
        
        /// <summary>
        /// Solicita CAE Mapeando desde T400
        /// Incluye para NC/ND IdFacturaAnula o Fecha Asociada - Si se provee ambos tiene prioridad Periodo Asociado
        /// </summary>
        public FEGetDataStructure SolicitudCAEFromT0400(int idFacturaX, int? idFacturaAnula,
            DateTime? compAsociadofechaDesde, DateTime? compAsociadofechaHasta, bool imprimeMensajeError = false)
        {
            _dataFE = this.CompletaEstructuraFE(idFacturaX);
            if (idFacturaAnula != null)
            {
                AddComprobanteAsociado(idFacturaAnula.Value);
            }

            if (compAsociadofechaDesde != null)
            {
                if (compAsociadofechaHasta == null)
                    compAsociadofechaHasta = compAsociadofechaDesde;
                AddComprobanteAsociadoFechaPeriodo(compAsociadofechaDesde.Value, compAsociadofechaHasta.Value);
            }
            return new FacturaElectronicaWs(_modoEjecucion).SolicitaCAEAfip(_dataFE);
        }

        public CheckNumeroComprobantes ValidaNumeracionComprobantes(TipoComprobante tipoComprobante)
        {
            var ultimoComprobanteMas = 0;
            var ultimoComprobanteAFIP = 0;
            var puntoVenta = 0;
            CheckNumeroComprobantes dataResult = new CheckNumeroComprobantes();

            switch (tipoComprobante)
            {
                case TipoComprobante.Factura:
                    ultimoComprobanteMas = Convert.ToInt32(ConfigurationDataT000.GetValue("NFAW"));
                    puntoVenta = Convert.ToInt32(ConfigurationDataT000.GetValue("PFAW"));
                    ultimoComprobanteAFIP =
                        Convert.ToInt32(
                            new FacturaElectronicaWs(_modoEjecucion).ObtieneUltimosComprobantesAFIP(puntoVenta)
                                .UltimaFactura);
                    break;

                case TipoComprobante.NotaCredito:
                    ultimoComprobanteMas = Convert.ToInt32(ConfigurationDataT000.GetValue("NNCW"));
                    puntoVenta = Convert.ToInt32(ConfigurationDataT000.GetValue("PNCW"));
                    ultimoComprobanteAFIP =
                        Convert.ToInt32(
                            new FacturaElectronicaWs(_modoEjecucion).ObtieneUltimosComprobantesAFIP(puntoVenta)
                                .UltimaNotaCredito);
                    break;

                case TipoComprobante.NotaDebito:
                    ultimoComprobanteMas = Convert.ToInt32(ConfigurationDataT000.GetValue("NNDW"));
                    puntoVenta = Convert.ToInt32(ConfigurationDataT000.GetValue("PNDW"));
                    ultimoComprobanteAFIP =
                        Convert.ToInt32(
                            new FacturaElectronicaWs(_modoEjecucion).ObtieneUltimosComprobantesAFIP(puntoVenta)
                                .UltimaNotaDebito);
                    break;
            }

            dataResult.UltimoComprobanteMAS = ultimoComprobanteMas;
            dataResult.UltimoComrobanteAFIP = ultimoComprobanteAFIP;
            dataResult.UltimoComprobanteIsOk = ultimoComprobanteMas == ultimoComprobanteAFIP;
            return dataResult;
        }
        public bool ActualizaUlimoComprobanteTabla(TipoComprobante tipoComprobante, string numeroDocumento)
        {
            switch (tipoComprobante)
            {
                case TipoComprobante.Factura:
                    return ConfigurationDataT000.SetData("NFAW", numeroDocumento);
                case TipoComprobante.NotaCredito:
                    return ConfigurationDataT000.SetData("NNCW", numeroDocumento);
                case TipoComprobante.NotaDebito:
                    return ConfigurationDataT000.SetData("NNDW", numeroDocumento);
                default:
                    return false;
            }
        }
        public void UpdateDataAfterDocumentNumberGetFromAFIP(int idFactura, string puntoVenta, string numeroDocumento,
            string numeroCAE, DateTime vencimientoCAE, int numeroAsiento)
        {
            int? idfx = null;

            var pv1 = Convert.ToInt32(puntoVenta).ToString("D4");
            var nd1 = Convert.ToInt64(numeroDocumento).ToString("D8");
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (t400 == null) return;

                t400.PV_AFIP = pv1;
                t400.ND_AFIP = nd1;
                t400.CAE = numeroCAE;
                t400.CAE_VTO = vencimientoCAE;
                t400.StatusFactura = DocumentFIStatusManager.StatusHeader.Aprobada.ToString().ToUpper();
                t400.NumeroDoc = pv1 +"-"+nd1;
                var items = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
                foreach (var i in items)
                {
                    i.NUMFACTURA = puntoVenta + "-" + numeroDocumento;
                }
                db.SaveChanges();
                idfx = t400.IDFACTURAX;
                if (idfx == null)
                    return;
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var idfxstr = idfx.ToString();
                var d201 = db.T0201_CTACTE.SingleOrDefault(c => c.DOC_INTERNO == idfxstr);
                if (d201 == null) return;
                d201.NUMDOC = puntoVenta + "-" + numeroDocumento;
                db.SaveChanges();
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d207 = db.T0207_SPLITFACTURAS.Where(c => c.IDDOC == idfx).ToList();
                foreach (var i in d207)
                {
                    i.TDOC = i.TDOC;
                    i.FACTSPLIT = i.FACTSPLIT;
                    i.NDOC = puntoVenta + "-" + numeroDocumento;
                    db.SaveChanges();
                }
                db.SaveChanges();
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h600 = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == numeroAsiento);
                if (h600 != null)
                {
                    h600.REFE = puntoVenta + "-" + numeroDocumento;
                }
                var h602 = db.T0602_DOCU_S.Where(c => c.IDDOCU == numeroAsiento).ToList();
                foreach (var ix in h602)
                {
                    ix.REFE = puntoVenta + "-" + numeroDocumento;
                }
                db.SaveChanges();
            }
        }
    }
}