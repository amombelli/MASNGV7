using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Network;
using TecserSQL.Data.EDMX.TSSecurity;
using TLogTcode = TecserSQL.Data.EDMX.TSSecurity.TLogTcode;
using TSecurityLog = TecserSQL.Data.EDMX.TSSecurity.TSecurityLog;
using TsecurityLogCheck = TecserSQL.Data.EDMX.TSSecurity.TsecurityLogCheck;

namespace Tecser.Business.Security
{
    public static class SecurityLog
    {
        /// <summary>
        /// Loguea el Acceso a la transaccion tipeada
        /// </summary>
        public static void LogTransactionIn(string tcode)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var data = new TLogTcode()
                {
                    IdLog = new TecserDataS(GlobalApp.CnnSec).TLogTcode.Max(c => c.IdLog) + 1,
                    Username = GlobalApp.AppUsername,
                    Tcode = tcode,
                    Computer = Environment.MachineName,
                    IPLog = IpAddress.GetIpV4Address(Environment.MachineName),
                    LogDate = DateTime.Now
                };
                db.TLogTcode.Add(data);
                db.SaveChanges();
            }
        }
        public static void LogRoleToCheck(string tcode, string roleChecked, bool accessIsGranted, string mensajeTolog)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var data = new TsecurityLogCheck()
                {
                    Mensaje = mensajeTolog,
                    Username = GlobalApp.AppUsername,
                    AccessGranted = accessIsGranted,
                    idMsg = db.TsecurityLogCheck.Max(c => c.idMsg) + 1,
                    Equipo = Environment.MachineName,
                    Fecha = DateTime.Now,
                    Tcode = tcode.Trim().Truncate(20),
                    RoleCheck = roleChecked.Trim().Truncate(50),
                    IP = IpAddress.GetIpV4Address(Environment.MachineName),
                };
                db.TsecurityLogCheck.Add(data);
                db.SaveChanges();
            }
        }
        public static void LogSecurityAccess(string tcode, string mensaje)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var data = new TSecurityLog()
                {
                    Username = GlobalApp.AppUsername,
                    LogDate = DateTime.Now,
                    Computer = Environment.MachineName,
                    IP = IpAddress.GetIpV4Address(Environment.MachineName),
                    TCode = tcode,
                    idLog = new TecserDataS(GlobalApp.CnnSec).TSecurityLog.Max(c => c.idLog) + 1,
                    Alert = mensaje
                };
                db.TSecurityLog.Add(data);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

    }
}
