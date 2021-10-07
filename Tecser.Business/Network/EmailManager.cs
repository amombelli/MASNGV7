using System;
using System.Net;
using System.Net.Mail;

namespace Tecser.Business.Network
{
    public struct SmtpConfig
    {
        public string SmtpServer;
        public string Username;
        public string Password;
        public int Port;
        public bool EnableSSL;
        public SmtpDeliveryMethod DeliveryMethod;
        public int TimeOut;
        public bool UseDefaultCredentials;

    }
    public class EmailManager
    {
        /// <summary>
        /// ccAddress va separado por ;
        /// </summary>
        public void SendEmail(string toAddress, string displayNameTo, string fromAddress, string displayNameFrom, string ccAddress, string bccAddres,
            string emailSubject, string bodyText, bool highPriority, string replyTo, string fileToSend)
        {
            var mailMsg = new MailMessage
            {
                Subject = emailSubject,
                Body = bodyText,
                From = new MailAddress(fromAddress, displayNameFrom),
                IsBodyHtml = true,
            };
            mailMsg.To.Add(new MailAddress(toAddress, displayNameTo));

            if (!String.IsNullOrEmpty(ccAddress))
            {
                String[] arrCC = ccAddress.Split(';');
                for (int i = 0; i < arrCC.Length; i++)
                    if (!String.IsNullOrEmpty(arrCC[i]))
                        mailMsg.CC.Add(new MailAddress(arrCC[i]));
            }

            if (!String.IsNullOrEmpty(bccAddres))
            {
                String[] arrBCC = bccAddres.Split(';');
                for (int i = 0; i < arrBCC.Length; i++)
                    if (!String.IsNullOrEmpty(arrBCC[i]))
                        mailMsg.Bcc.Add(new MailAddress(arrBCC[i]));
            }

            mailMsg.Priority = highPriority ? MailPriority.High : MailPriority.Normal;

            if (!string.IsNullOrEmpty(fileToSend))
            {
                var archivoExiste = System.IO.File.Exists(fileToSend);

                if (archivoExiste)
                {
                    mailMsg.Attachments.Add(new Attachment(fileToSend));
                }

                mailMsg.ReplyToList.Add(replyTo);
            }
            SendEmailAsync(mailMsg);
            //SendEmailInBackgroundThread(mailMsg);
        }

        private void SendEmailAsync(object mailMsg)
        {
            var mailMessage = (MailMessage)mailMsg;
            //var config = MasterTecserConfig();
            var config = GmailConfig();
            try
            {
                var smtpClient = new SmtpClient(config.SmtpServer, config.Port)
                {
                    UseDefaultCredentials = config.UseDefaultCredentials,
                    Credentials = new NetworkCredential(config.Username, config.Password),
                    EnableSsl = config.EnableSSL,
                    DeliveryMethod = config.DeliveryMethod,
                    Timeout = config.TimeOut,

                };
                smtpClient.SendMailAsync(mailMessage);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (SmtpException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                // Code to Log error
            }
        }
        private SmtpConfig GmailConfig()
        {
            var config = new SmtpConfig()
            {
                SmtpServer = "smtp.gmail.com",
                Username = "tecsermasterbatch.app@gmail.com",
                Password = "TecserMb3475",
                Port = 587,
                EnableSSL = true,
                TimeOut = 30000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
            };
            return config;
        }
        private SmtpConfig MasterTecserConfig()
        {
            var config = new SmtpConfig()
            {
                SmtpServer = "mail.mastertecser.com.ar",
                Username = "mas@mastertecser.com.ar",
                Password = "TecserMasApp",
                Port = 465,
                EnableSSL = true,
                TimeOut = 9000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
            };
            return config;
        }
    }
}
