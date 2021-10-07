using System.Net;
using System.Net.Mail;

namespace Tecser.Business.Network
{
    public class Email2
    {


        public void SendEmail()
        {
            var fromAddress = new MailAddress("tecsermasterbatch.app@gmail.com", "TecserAPP");
            var toAddress = new MailAddress("amombelli@gmail.com", "Andrews");
            const string fromPassword = "TecserMb3475";
            const string subject = "ReciboXX";
            const string body = "Texto0001";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }


    }
}
