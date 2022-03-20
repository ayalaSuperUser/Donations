using SMTP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMTP.Services
{
    public interface IMailService
    {
        void SendEmail(MailRequest mailRequest);
    }
}
