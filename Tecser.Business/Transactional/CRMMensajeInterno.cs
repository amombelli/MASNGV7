using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Network;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.CRM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional
{
    public class CRMMensajeInterno
    {
        public string GetMensajeInterno(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                if (x == null)
                    return null;
                return x.MensajeInterno;
            }
        }
        public void SetMensajeInterno(int idCliente, string textoInterno, bool appendMsg = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                if (x == null)
                {
                    new Gesco().CreateEmptyHeaderRecord(idCliente);
                    x = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                }

                if (string.IsNullOrEmpty(textoInterno))
                {
                    if (!appendMsg)
                        RemoveMessage(idCliente, false);
                }
                else
                {
                    if (appendMsg)
                    {
                        if (string.IsNullOrEmpty(x.MensajeInterno))
                        {
                            x.MensajeInterno = textoInterno;
                        }
                        else
                        {
                            x.MensajeInterno = x.MensajeInterno + "##" + textoInterno;
                        }
                    }
                    else
                    {
                        x.MensajeInterno = textoInterno;
                    }

                    x.MensajeInternoUser = GlobalApp.AppUsername;
                    x.MensajeInternoDate = DateTime.Now;
                }

                db.SaveChanges();
            }
        }
        public void RemoveMessage(int idCliente, bool enviarEmail)
        {

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var gescoH = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                if (gescoH == null)
                    return;

                if (enviarEmail)
                {
                    var user = gescoH.MensajeInternoUser;
                    var hr = new HumanResourcesManager().GetEmployeeDataByShortname(user);
                    var email = hr.EMAILCORP;
                    if (email != null)
                    {
                        var nombre = hr.NOMBRE;
                        var msg =
                            $"El Mensaje {gescoH.MensajeInterno} ha sido leido/removido por el usuario {GlobalApp.AppUsername}";
                        new EmailManager().SendEmail(email, nombre, "Mas-Crm@mombellisrl.com.ar", "MAS-Crm", "", "", "Mensaje Leido/Removido", msg, false, "", null);
                    }
                }
                gescoH.MensajeInterno = null;
                gescoH.MensajeInternoUser = null;
                gescoH.MensajeInternoDate = null;
                db.SaveChanges();
            }
        }
    }
}
