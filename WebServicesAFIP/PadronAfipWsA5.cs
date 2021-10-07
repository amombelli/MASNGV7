using System;
using System.Collections.Generic;

namespace WebServicesAFIP
{
    public class PadronAfipWsA5
    {
        public PadronAfipWsA5(ModoEjecucion modo)
        {
            _modo = modo;
            ConfiguraServerWsdl();
        }

        //------------------------------------------------------------------------
        private readonly ModoEjecucion _modo;
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._path' is never used
        private string _path;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._path' is never used
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._certificado' is never used
        private string _certificado;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._certificado' is never used
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._clavePrivada' is never used
        private string _clavePrivada;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._clavePrivada' is never used
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._cuit' is never used
        private string _cuit;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._cuit' is never used
        private readonly string _proxy = ""; // "usuario:clave@localhost:8000"
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._serverWsaa' is never used
        private string _serverWsaa;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._serverWsaa' is never used
        private string ServerWsdl;
        //
        public string WsaaVersion;
        public string WsaaInstallDir;
        private string WsPadronVersion;
        public string WsPadronInstallDir;
        //
        public bool WsaaStatus;
        public bool WsPadronStatus;
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._ticketRequerimientoAcceso' is never used
        private string _ticketRequerimientoAcceso;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._ticketRequerimientoAcceso' is never used
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._mensajeFirmadoCms' is never used
        private string _mensajeFirmadoCms;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._mensajeFirmadoCms' is never used
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._ticketAcceso' is never used
        private string _ticketAcceso;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._ticketAcceso' is never used
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._token' is never used
        private string _token;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._token' is never used
#pragma warning disable CS0169 // The field 'PadronAfipWsA5._sign' is never used
        private string _sign;
#pragma warning restore CS0169 // The field 'PadronAfipWsA5._sign' is never used
        //private dynamic _wsaa;
        private dynamic _wsPadron;
        //------------------------------------------------------------------------

        private void ConfiguraServerWsdl()
        {
            //ServerWsdl = _modo == ModoEjecucion.Produccion
            //    ? "https://aws.afip.gov.ar/sr-padron/webservices/personaServiceA5?wsdl"
            //    : "https://awshomo.afip.gov.ar/sr-padron/webservices/personaServiceA4?wsdl";

            //Modificacion 2019.09.03
            ServerWsdl = _modo == ModoEjecucion.Produccion
                ? "https://aws.afip.gov.ar/sr-padron/webservices/personaServiceA5?wsdl"
                : "https://awshomo.afip.gov.ar/sr-padron/webservices/personaServiceA5?WSDL";
        }

        /// <summary>
        /// wsaa que se pasa por parametro tiene que ser un wssa ya conectado
        /// </summary>
        private bool ConectarPadronA5(WsaaManagement wsaa)
        {
            _wsPadron = Activator.CreateInstance(Type.GetTypeFromProgID("WSSrPadronA5")); //modifiqueaca 
            var cache = ""; //default cache path;
            try
            {

                _wsPadron.Token = wsaa.Token;
                _wsPadron.Sign = wsaa.Sign;
                _wsPadron.Cuit = wsaa.CUIT; // Mombelii e Hijos SRL
                WsPadronInstallDir = _wsPadron.InstallDir;
                WsPadronVersion = _wsPadron.Version;
                var ok = _wsPadron.Conectar(cache, ServerWsdl, _proxy);
                //ok=_wsPadron.Consultar("30500001735");

                //'Debug.Print(ok, Err.Description)

                //'If Padron.Excepcion = "" Then
                //'        MsgBox Padron.denominacion & " " & Padron.Estado & vbCrLf & Padron.direccion & vbCrLf & Padron.localidad & vbCrLf & Padron.provincia & vbCrLf & Padron.cod_postal, vbInformation, "Resultado CUIT " & Cuit & " (online AFIP)"
                //'Else
                //'        ' respuesta del servidor(para depuración)
                //'        Debug.Print Padron.response
                //'    MsgBox "Error AFIP: " & Padron.Excepcion, vbCritical, "Resultado CUIT " & Cuit & " (online)"
                //'End If

                if (ok == true)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EstructuraPadronAfipA5 ObtieneDatosPadronA5(string cuit)
        {
            if (_modo == ModoEjecucion.Produccion)
            {
                ConectarPadronA5(new WsaaManagement(_modo, "ws_sr_constancia_inscripcion"));
            }
            else
            {
                ConectarPadronA5(new WsaaManagement(_modo, "ws_sr_padron_a5"));
            }
            var ok = _wsPadron.Consultar(cuit);
            var retorno = new EstructuraPadronAfipA5
            {
                Denominacion = _wsPadron.denominacion,
                Direccion = _wsPadron.direccion,
                TipoDocumento = _wsPadron.tipo_doc,
                TipoPersona = _wsPadron.tipo_persona,
                Estado = _wsPadron.Estado,
                Localidad = _wsPadron.localidad,
                Provincia = _wsPadron.provincia,
                CodPostal = _wsPadron.cod_postal,
                IVA = _wsPadron.imp_iva,
                Monotributo = _wsPadron.monotributo,
                Empleador = _wsPadron.empleador,
                Impuestos = new List<int>(),
                Actividad = new List<int>()
            };

            foreach (var actividad in _wsPadron.actividades)
            {
                retorno.Actividad.Add(actividad);
            }

            foreach (var impuesto in _wsPadron.impuestos)
            {
                retorno.Impuestos.Add(impuesto);
            }
            return retorno;
        }
    }
}