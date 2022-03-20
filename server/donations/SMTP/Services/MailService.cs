using Microsoft.Extensions.Options;
using SMTP.Models;
using System.Net;
using System.Net.Mail;

namespace SMTP.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public void SendEmail(MailRequest mailRequest)
        {
            try
            {
                var smtpClient = new SmtpClient(_mailSettings.Host)
                {
                    Port = _mailSettings.Port,
                    Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password),
                    EnableSsl = true,
                };

                smtpClient.Send("DoNotReply@donations.org.il", mailRequest.MailReciepient, mailRequest.Subject, mailRequest.Body);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
