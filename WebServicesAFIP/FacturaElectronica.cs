using System;
using System.IO;
using System.Xml;

namespace WebServicesAFIP
{
    public enum ModoEjecucion
    {
        Produccion,
        Testeo
    }

    public enum TipoComprobante
    {
        Factura, //1
        NotaDebito, //2
        NotaCredito, //3
        Recibo, //4
        FacturaM, //5
        NotaDebitoM, //6
        NotaCreditoM, //7
        FacturaB, //8
        NotaCreditoB, //9
        NotaDebitoB, //10
        NoDefinido
    };

    public class FacturaElectronicaWs
    {
        public FacturaElectronicaWs(ModoEjecucion modo)
        {
            _modo = modo;
            ConfiguraParametrosFE();
        }

        //-----------------------------------------------------------------------------------------------------
        private readonly ModoEjecucion _modo;
#pragma warning disable CS0414 // The field 'FacturaElectronicaWs._path' is assigned but its value is never used
        private string _path;
#pragma warning restore CS0414 // The field 'FacturaElectronicaWs._path' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FacturaElectronicaWs._certificado' is assigned but its value is never used
        private string _certificado;
#pragma warning restore CS0414 // The field 'FacturaElectronicaWs._certificado' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FacturaElectronicaWs._clavePrivada' is assigned but its value is never used
        private string _clavePrivada;
#pragma warning restore CS0414 // The field 'FacturaElectronicaWs._clavePrivada' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FacturaElectronicaWs._cuit' is assigned but its value is never used
        private string _cuit;
#pragma warning restore CS0414 // The field 'FacturaElectronicaWs._cuit' is assigned but its value is never used
        private string _proxy = ""; // "usuario:clave@localhost:8000"

        public string ServerWsfe { get; private set; }
        public string Version { get; private set; }
        public string InstallDir { get; private set; }

#pragma warning disable CS0169 // The field 'FacturaElectronicaWs._ticketRequerimientoAcceso' is never used
        private string _ticketRequerimientoAcceso;
#pragma warning restore CS0169 // The field 'FacturaElectronicaWs._ticketRequerimientoAcceso' is never used
#pragma warning disable CS0169 // The field 'FacturaElectronicaWs._mensajeFirmadoCms' is never used
        private string _mensajeFirmadoCms;
#pragma warning restore CS0169 // The field 'FacturaElectronicaWs._mensajeFirmadoCms' is never used
#pragma warning disable CS0169 // The field 'FacturaElectronicaWs._ticketAcceso' is never used
        private string _ticketAcceso;
#pragma warning restore CS0169 // The field 'FacturaElectronicaWs._ticketAcceso' is never used
#pragma warning disable CS0169 // The field 'FacturaElectronicaWs._token' is never used
        private string _token;
#pragma warning restore CS0169 // The field 'FacturaElectronicaWs._token' is never used
#pragma warning disable CS0169 // The field 'FacturaElectronicaWs._sign' is never used
        private string _sign;
#pragma warning restore CS0169 // The field 'FacturaElectronicaWs._sign' is never used
#pragma warning disable CS0169 // The field 'FacturaElectronicaWs._wsaa' is never used
        private dynamic _wsaa;
#pragma warning restore CS0169 // The field 'FacturaElectronicaWs._wsaa' is never used
        private dynamic _wsfev1;
        public string StatusServerApp { get; private set; }
        public string StatusServerDb { get; private set; }
        public string StatusServerAuth { get; private set; }
        //-----------------------------------------------------------------------------------------------------
        private void ConfiguraParametrosFE()
        {
            if (_modo == ModoEjecucion.Produccion)
            {
                _path = @"C:\FE\CERTIFICADOS\PRODU\";
                ServerWsfe = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL";
                _certificado = "AFIP.crt";
                _clavePrivada = "privada.key";
                _cuit = "30709669091"; //CUIT SRL
            }
            else
            {
                _path = @"C:\FE\CERTIFICADOS\HOMO\";
                ServerWsfe = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx";
                _certificado = "prueba.crt";
                _clavePrivada = "claveprueba.key";
                _cuit = "23251522839"; //CUIT AM
            }
        }
        private static int GetIdTipoComprobanteAfip(TipoComprobante tipoComprobante)
        {
            switch (tipoComprobante)
            {
                case TipoComprobante.Factura:
                    return 1;
                case TipoComprobante.NotaCredito:
                    return 3;
                case TipoComprobante.NotaDebito:
                    return 2;
                case TipoComprobante.Recibo:
                    return 4;
                case TipoComprobante.FacturaM:
                    return 51;
                case TipoComprobante.NotaDebitoM:
                    return 52;
                case TipoComprobante.NotaCreditoM:
                    return 53;
                case TipoComprobante.FacturaB:
                    return 6;
                case TipoComprobante.NotaCreditoB:
                    return 8;
                case TipoComprobante.NotaDebitoB:
                    return 7;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoComprobante), tipoComprobante, null);
            }
        }
        private void ConectarWSFEv1(WsaaManagement wsaa)
        {
            _wsfev1 = Activator.CreateInstance(Type.GetTypeFromProgID("WSFEv1"));
            var cache = ""; //default cache path
            try
            {
                _wsfev1.Token = wsaa.Token;
                _wsfev1.Sign = wsaa.Sign;
                _wsfev1.Cuit = wsaa.CUIT;

                InstallDir = _wsfev1.InstallDir;
                Version = _wsfev1.Version;

                var ok = _wsfev1.Conectar(cache, ServerWsfe, _proxy);
                _wsfev1.Dummy();

                StatusServerApp = _wsfev1.AppServerStatus;
                StatusServerAuth = _wsfev1.DbServerStatus;
                StatusServerAuth = _wsfev1.AuthServerStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene los ultimos comprobantes registrados en la AFIP para el punto de venta informado
        /// </summary>
        public UltimosComprobantes ObtieneUltimosComprobantesAFIP(int puntoVenta)
        {
            ConectarWSFEv1(new WsaaManagement(_modo, "wsfe"));
            if (_wsfev1.AppServerStatus != "OK")
                return null;

            var result = new UltimosComprobantes
            {
                UltimaFactura = _wsfev1.CompUltimoAutorizado(1, puntoVenta),
                UltimaNotaCredito = _wsfev1.CompUltimoAutorizado(3, puntoVenta),
                UltimaNotaDebito = _wsfev1.CompUltimoAutorizado(2, puntoVenta)
            };
            return result;
        }

        /// <summary>
        /// Metodo usado solo para chequear una conexion (desarrollo de algun testeo)
        /// Sino unsar directamente el metodo publico disponible que hace la conexion adentro
        /// </summary>
        public void SoloConnectToCheck(WsaaManagement wsaaConectado)
        {
            ConectarWSFEv1(wsaaConectado);
        }
        public FEGetDataStructure ObtieneDatosComprobanteAFIP(TipoComprobante tipoComprobante, int sucursal, int numeroComprobante)
        {
            var respuesta = new FEGetDataStructure();
            ConectarWSFEv1(new WsaaManagement(_modo, "wsfe"));

            _wsfev1.Dummy();
            if (_wsfev1.AppServerStatus != "OK") return respuesta;

            respuesta.CAE = _wsfev1.CompConsultar(GetIdTipoComprobanteAfip(tipoComprobante).ToString(), sucursal.ToString(), numeroComprobante.ToString());
            if (string.IsNullOrEmpty(respuesta.CAE))
            {
                respuesta.ImporteNeto = 0;
                respuesta.ImporteIva = 0;
                respuesta.ImporteTotal = 0;
                respuesta.ImporteTributos = 0;
                respuesta.VencimientoCAE = DateTime.Today;
                respuesta.DocNumero = null;
                respuesta.DocTipo = null;
                return respuesta;
            }
            respuesta.ImporteNeto = Convert.ToDecimal(_wsfev1.impneto);

            respuesta.ImporteIva = Convert.ToDecimal(_wsfev1.impiva);

            respuesta.ImporteTotal = Convert.ToDecimal(_wsfev1.imptotal);

            respuesta.ImporteTributos = Convert.ToDecimal(_wsfev1.imptrib);

            respuesta.Resultado = _wsfev1.resultado;

            respuesta.VencimientoCAE = DateTime.ParseExact(_wsfev1.vencimiento, "yyyyMMdd", null);

            var z1 = _wsfev1.AnalizarXml("XmlResponse");
            if (z1)
            {
                respuesta.DocNumero = _wsfev1.ObtenerTagXml("DocNro");
                respuesta.DocTipo = _wsfev1.ObtenerTagXml("DocTipo");
                respuesta.PuntoVenta = _wsfev1.ObtenerTagXml("PtoVta");
                string formatString = "yyyyMMddHHmmss";
                respuesta.FechaProceso = DateTime.ParseExact(_wsfev1.ObtenerTagXml("FchProceso"), formatString, null);


                respuesta.ComprobanteDesde = _wsfev1.ObtenerTagXml("CbteDesde");
                respuesta.ComprobanteHasta = _wsfev1.ObtenerTagXml("CbteHasta");
                respuesta.FechaComprobante = DateTime.ParseExact(_wsfev1.ObtenerTagXml("CbteFch"), "yyyyMMdd", null);
                respuesta.Moneda = _wsfev1.ObtenerTagXml("MonId");
                respuesta.Cotizacion = Convert.ToDecimal(_wsfev1.ObtenerTagXml("MonCotiz"));
            }

            if (respuesta.ImporteTributos > 0)
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(_wsfev1.XmlResponse)))
                {
                    var item = new TributosAfip();
                    reader.MoveToFirstAttribute();
                    reader.ReadToFollowing("Tributos");
                    reader.Read();
                    bool primerElemento = true;

                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "Tributo")
                            {
                                if (primerElemento == false)
                                {
                                    respuesta.TributosDetalle.Add(item);
                                    item = new TributosAfip();
                                }
                                primerElemento = false;
                                reader.Read();
                            }
                            switch (reader.Name)
                            {
                                case "Id":
                                    item.IdTributo = reader.ReadElementContentAsString();
                                    break;
                                case "Desc":
                                    item.Descripcion = reader.ReadElementContentAsString();
                                    break;
                                case "BaseImp":
                                    item.BaseImponible = reader.ReadElementContentAsString();
                                    break;
                                case "Alic":
                                    item.Alicuota = reader.ReadElementContentAsString();
                                    break;
                                case "Importe":
                                    item.Importe = reader.ReadElementContentAsString();
                                    break;
                            }
                        }
                        else
                        {
                            reader.Read();
                        }
                    }
                    if (primerElemento == false)
                    {
                        respuesta.TributosDetalle.Add(item);
                    }
                }
            }

            using (XmlReader reader = XmlReader.Create(new StringReader(_wsfev1.XmlResponse)))
            {
                //Estructura IVA
                var itemIva = new TributosAfip();
                reader.MoveToFirstAttribute();
                reader.ReadToFollowing("Iva");
                reader.Read();
                bool primerElemento = true;

                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "AlicIva")
                        {
                            if (primerElemento == false)
                            {
                                respuesta.IvaDetalle.Add(itemIva);
                                itemIva = new TributosAfip();
                            }
                            primerElemento = false;
                            reader.Read();
                        }
                        switch (reader.Name)
                        {
                            case "Id":
                                itemIva.IdTributo = reader.ReadElementContentAsString();
                                break;
                            case "Desc":
                                itemIva.Descripcion = reader.ReadElementContentAsString();
                                break;
                            case "BaseImp":
                                itemIva.BaseImponible = reader.ReadElementContentAsString();
                                break;
                            case "Alic":
                                itemIva.Alicuota = reader.ReadElementContentAsString();
                                break;
                            case "Importe":
                                itemIva.Importe = reader.ReadElementContentAsString();
                                break;
                        }
                    }
                    else
                    {
                        reader.Read();
                    }
                }
                respuesta.IvaDetalle.Add(itemIva);


                //  < Iva >< AlicIva >< Id > 5 </ Id >< BaseImp > 10146.24 </ BaseImp >< Importe > 2130.71 </ Importe ></ AlicIva ></ Iva >
            }

            return respuesta;
        }


        public FEGetDataStructure SolicitaCAEAfip(FESetDataStructure dataStructure)
        {
            var resultado = new FEGetDataStructure();
            resultado.NumeroDocumentoOtorgadoCompleto = @"0000-00000000";
            ConectarWSFEv1(new WsaaManagement(_modo));
            try
            {
                object concepto, tipoDoc, nroDoc, tipoCbte;
                object puntoVta, cbtDesde, cbtHasta, impTotal;
                object impTotConc, impNeto, impTrib;
                object impOPEx, fechaCbte, fechaVencPago;
                object fechaServDesde, fechaServHasta;
                object monedaId, monedaCtz;
                object tipo_cbte_asoc, punto_vta_asoc, cbte_nro_asoc;
                object tipo, ptoVta, nro, fecha, cbteNro;
                object id, desc, baseImp, alic, importe;
                object cae;
                long lcbteNro;
                object impIVA;


                // Establezco los valores de la factura a autorizar:

                tipoCbte = GetIdTipoComprobanteAfip(dataStructure.TipoComprobante); //Factura =1
                puntoVta = dataStructure.PuntoVenta; //4002
                var ultimoComprobante = _wsfev1.CompUltimoAutorizado(tipoCbte, puntoVta);
                ultimoComprobante = string.IsNullOrEmpty(ultimoComprobante) ? 0 : Convert.ToInt64(ultimoComprobante);
                concepto = dataStructure.Concepto.ToString(); //1;
                tipoDoc = dataStructure.TipoDocumento; //80; 
                nroDoc = dataStructure.NumeroDocumento; //"33693450239";
                cbtDesde = Convert.ToInt64(ultimoComprobante + 1);
                cbtHasta = Convert.ToInt64(ultimoComprobante + 1);
                impTotal = dataStructure.ImporteTotal; //"122.00";
                impTotConc = dataStructure.ImporteNoGravado;        //# Conceptos No Gravados
                impNeto = dataStructure.BaseImponible; //"100.00";  //# importe neto gravado (todas las alicuotas)
                impIVA = dataStructure.ImporteIVA; //"21.00";
                impTrib = dataStructure.ImporteTributos; //"1.00";
                impOPEx = "0.00";
                fechaCbte = DateTime.Today.ToString("yyyyMMdd"); //cambiar a fecha del documento 
                fechaVencPago = "";
                fechaServDesde = ""; // Fechas del período del servicio facturado (solo si concepto = 1?)
                fechaServHasta = ""; // Fechas del período del servicio facturado (solo si concepto = 1?)
                monedaId = dataStructure.MonedaId; //"PES";
                monedaCtz = dataStructure.Cotizacion; //"1.000";

                var ok = _wsfev1.CrearFactura(concepto, tipoDoc, nroDoc, tipoCbte, puntoVta, cbtDesde, cbtHasta,
                    impTotal, impTotConc, impNeto, impIVA, impTrib, impOPEx, fechaCbte, fechaVencPago, fechaServDesde,
                    fechaServHasta, monedaId, monedaCtz);

                //RG Para notas de credito o debito se debe informar o comprobante que modifica o periodo al que modifica
                if (dataStructure.CompAsociadoTipo !=TipoComprobante.NoDefinido)
                {
                    //tiene un comprobante asociado y lo agrega
                    tipo_cbte_asoc = GetIdTipoComprobanteAfip(dataStructure.CompAsociadoTipo);
                    punto_vta_asoc = dataStructure.CompAsociadoPtoVta;
                    cbte_nro_asoc = dataStructure.CompAsociadoNumero;
                    ok = _wsfev1.AgregarCmpAsoc(tipo_cbte_asoc, punto_vta_asoc, cbte_nro_asoc);
                }
                else
                {
                    if (!string.IsNullOrEmpty(dataStructure.CompAsociadoFechaPeriodoDesde))
                    {
                        //tiene periodo Asociado y lo agrega (usado para ND=
                        ok = _wsfev1.AgregarPeriodoComprobantesAsociados(dataStructure.CompAsociadoFechaPeriodoDesde,
                            dataStructure.CompAsociadoFechaPeriodoHasta);
                    }
                }
                //Agrega IVA
                foreach (var item in dataStructure.IvaDetalle)
                {
                    id = item.IdTributo; //5 >>21%
                    baseImp = item.BaseImponible;
                    importe = item.Importe;
                    ok = _wsfev1.AgregarIva(id, baseImp, importe);
                }

                //Agrega TRIBUTOS (IIBB, etc)
                foreach (var item in dataStructure.TributosDetalle)
                {
                    id = item.IdTributo;
                    desc = item.Descripcion;
                    baseImp = item.BaseImponible;
                    alic = item.Alicuota;
                    importe = item.Importe;
                    ok = _wsfev1.AgregarTributo(id, desc, baseImp, alic, importe);
                }
                
                // Habilito reprocesamiento automático (predeterminado):
                _wsfev1.Reprocesar = true;

                // Solicito CAE:
                resultado.CAE = _wsfev1.CAESolicitar();
                resultado.Resultado = _wsfev1.Resultado;
                resultado.EmisionTipo = _wsfev1.EmisionTipo;
                resultado.XmlResponse = _wsfev1.XmlResponse;
                resultado.XmlRequest = _wsfev1.XmlRequest;
                resultado.ComprobanteDesde = _wsfev1.CbteNro.ToString();
                resultado.ComprobanteHasta = _wsfev1.CbteNro.ToString();
                resultado.Reprocesar = _wsfev1.Reprocesar;
                if (_wsfev1.Reproceso == "")
                {
                    resultado.Reproceso = false;
                }
                else
                {
                    resultado.Reproceso = _wsfev1.Reproceso;
                }
                if (resultado.Resultado == "A")
                {
                    resultado.VencimientoCAE = DateTime.ParseExact(_wsfev1.vencimiento, "yyyyMMdd", null);
                    resultado.PuntoVenta = dataStructure.PuntoVenta.ToString();
                    resultado.NumeroDocumentoOtorgadoCompleto =
                        resultado.PuntoVenta.PadLeft(4, '0') + "-" + resultado.ComprobanteHasta.PadLeft(8, '0');
                }
                // Imprimo pedido y respuesta XML para depuración (errores de formato)
                //Console.WriteLine(_wsfev1.XmlRequest);
                //Console.WriteLine(_wsfev1.XmlResponse);
                //Console.WriteLine("Resultado" + _wsfev1.Resultado);
                //Console.WriteLine("CAE", _wsfev1.CAE);
                //Console.WriteLine("Numero de comprobante:" + _wsfev1.CbteNro);
                //Console.WriteLine("Reprocesar:" + _wsfev1.Reprocesar);
                //Console.WriteLine("Reproceso:" + _wsfev1.Reproceso);
                //Console.WriteLine("EmisionTipo:" + _wsfev1.EmisionTipo);


                //MsgBox("Resultado:" & WSFEv1.Resultado & " CAE: " & CAE & " Venc: " & WSFEv1.Vencimiento & " Reproceso: " & WSFEv1.Reproceso, vbInformation + vbOKOnly)

                if (_wsfev1.ErrMsg != "")
                    resultado.Wsfev1Error = _wsfev1.ErrMsg;
                Console.WriteLine(_wsfev1.ErrMsg);

                if (_wsfev1.Obs != "")
                    resultado.Wsfev1Observacion = _wsfev1.Obs;
                Console.WriteLine(_wsfev1.Obs);

                return resultado;
            }
            catch
            {
                if (_wsfev1.ErrMsg != "")
                    resultado.Wsfev1Error = _wsfev1.ErrMsg;
                Console.WriteLine(_wsfev1.ErrMsg);

                if (_wsfev1.Obs != "")
                    resultado.Wsfev1Observacion = _wsfev1.Obs;
                Console.WriteLine(_wsfev1.Obs);

                // Muestro los errores
                if (_wsfev1.Traceback != "")
                    //MsgBox(WSFEv1.Traceback, vbExclamation, "Error")
                    Console.WriteLine(_wsfev1.Traceback);
                return resultado;
            }
        }

    }
}




