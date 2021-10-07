using System;
using System.IO;

namespace WebServicesAFIP
{
    //Esta clase admnistra el servicio WSAA que es necesario para acceder al resto de los servicios de negocios(ej.Factura Electrónica) ofrecidos por la AFIP.
    //Se debe generar un Ticket de Requerimiento de Acceso (TRA), firmarlo criptográficamente(generando un mensaje CMS) que es envía al servicio web para obtener un Ticket de Acceso(TA).
    //Esta interfase crea el mensaje en XML, lo firma criptográficamente y lo codifica en base-64 como lo requiere la AFIP, por lo que en general no es necesario realizar ninguno de estos pasos.
    public class WsaaManagement
    {
        public WsaaManagement(ModoEjecucion modo, string servicioAFIP = "wsfe", bool autoConecta = true,
            bool forceNewTicket = false)
        {
            _modo = modo;
            if (_modo == ModoEjecucion.Produccion)
            {
                _path = @"C:\FE\CERTIFICADOS\PRODU\";
                _serverWsaa = "https://wsaa.afip.gov.ar/ws/services/LoginCms";
                _certificado = "AFIP.crt";
                _clavePrivada = "privada.key";
                CUIT = "30709669091";
            }
            else
            {
                _path = @"C:\FE\CERTIFICADOS\HOMO\";
                _serverWsaa = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?wsdl";
                _serverWsaa = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";
                _certificado = "PRUEBA.CRT";
                _clavePrivada = "MiClavePrivada";
                CUIT = "23251522839"; //cuit andres
            }

            //' Crear objeto interface Web Service Autenticación y Autorización
            _wsaa = Activator.CreateInstance(Type.GetTypeFromProgID("WSAA"));
            WsaaVersion = _wsaa.version;
            WsaaInstallDir = _wsaa.InstallDir;
            string ticketFileName;

            if (servicioAFIP == "wsfe")
            {
                ticketFileName = "ta.xml";
            }
            else
            {
                ticketFileName = "constancia.xml";
            }

            if (autoConecta)
            {
                if (forceNewTicket)
                {
                    GetNewTicket(servicioAFIP);
                    SaveTicket(ticketFileName);
                }
                else
                {
                    //Obtiene nuevo ticket o no de acuerdo a necesidad/expiracion
                    ManageTicketUseOrReuse(servicioAFIP, ticketFileName);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private readonly ModoEjecucion _modo;
        public string Token { get; private set; }
        public string Sign { get; private set; }
        public string CUIT { get; private set; }
        public string Expira { get; private set; }
        public string Generado { get; private set; }
        public string _serverWsaa { get; private set; }

        private readonly int ttl = 36000; //en segundo >10 horas
        private readonly string _path;
        private string _certificado;
        private string _clavePrivada;

        private string _proxy = ""; // "usuario:clave@localhost:8000"

        //private string _serverWsfe;
        public bool TicketReusado;
        public string WsaaVersion;
        public string WsaaInstallDir;
        //private string _wSfEv1Version;
        //public string WSFEv1InstallDir;
        //
        public bool WsaaStatus;
        //public bool WsafeV1Status;
        private string _ticketRequerimientoAcceso;
        private string _mensajeFirmadoCms;
        private string _ticketAcceso;

        private dynamic _wsaa;
        //private dynamic _wsfev1;
        public string StatusServerApp;
        public string StatusServerDb;
        public string StatusServerAuth;
        //-----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Obtiene ticket nuevo debido a que el ticket guardado esta expirado
        /// </summary>
        private void GetNewTicket(string servicioAfip)
        {
            try
            {
                //Genero un ticket de requerimiento de acceso (TRA) para wsfev1
                _ticketRequerimientoAcceso = _wsaa.CreateTRA(servicioAfip, ttl);

                //genera el mensaje firmado
                _mensajeFirmadoCms = _wsaa.SignTRA(_ticketRequerimientoAcceso, _path + _certificado, _path + _clavePrivada);
                //https://wsaahomo.afip.gov.ar/ws/services/LoginCms
                //Autentifica el mensaje
                string cache = "";
                _wsaa.Conectar(cache, _serverWsaa, _proxy);
                _ticketAcceso = _wsaa.LoginCMS(_mensajeFirmadoCms);
                this.Token = _wsaa.Token;
                this.Sign = _wsaa.Sign;
                Expira = _wsaa.ObtenerTagXml("expirationTime");
                string nombreTicket;
                if (servicioAfip == "wsfe")
                {
                    nombreTicket = "ta.xml";
                }
                else
                {
                    nombreTicket = "constancia.xml";
                }
                SaveTicket(nombreTicket);
                WsaaStatus = true;
            }
            catch (Exception)
            {
                if (_wsaa.Excepcion != "")
                    //MsgBox(wsaa.Traceback, vbExclamation, wsaa.Excepcion)
                    Console.WriteLine(_wsaa.Excepcion);
                throw new Exception(_wsaa.Excepcion);
            }
        }
        private bool CheckValidTicket()
        {
            var ok = _wsaa.AnalizarXml(_ticketAcceso);
            if (_wsaa.Expirado == false)
            {
                //el ticket acceso es valido
                this.Token = _wsaa.ObtenerTagXml("token");
                this.Sign = _wsaa.ObtenerTagXml("sign");
                Expira = _wsaa.ObtenerTagXml("expirationTime");
                Generado = _wsaa.ObtenerTagXml("generationTime");
                return true;
            }
            else
            {
                //el ticket acceso no es validado (expirado)
                return false;
            }
        }
        private void SaveTicket(string nombreTicket = "ta.xml")
        {
            System.IO.File.WriteAllText(_path + nombreTicket, this._ticketAcceso);
        }
        private bool LoadTicket(string nombreTicket = "ta.xml")
        {
            if (File.Exists(_path + nombreTicket))
            {
                _ticketAcceso = System.IO.File.ReadAllText(_path + nombreTicket);
                return true;
            }
            _ticketAcceso = null;
            return false;
        }
        private void ManageTicketUseOrReuse(string servicioAfip, string nombreTicket = "ta.xml")
        {
            if (LoadTicket(nombreTicket) == false)
            {
                GetNewTicket(servicioAfip);
                TicketReusado = false;
            }
            else
            {
                if (CheckValidTicket() == true)
                {
                    //Se puede reusar el ticket de acceso
                    TicketReusado = true;
                }
                else
                {
                    GetNewTicket(servicioAfip);
                    TicketReusado = false;
                }
            }
        }
    }
}
