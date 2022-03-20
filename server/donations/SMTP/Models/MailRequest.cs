using System;
using System.Collections.Generic;
using System.Text;

namespace SMTP.Models
{
    public class MailRequest
    {
       public string MailReciepient { get; set; }
       public string Subject { get; set; }
       public string Body { get; set; }
    }
}
