using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TMXLoader.Classes
{
    public class Email
    {
        MailMessage mail;
        SmtpClient smtp;

        public Email(string from, string to, string host, int port = 25)
        {
            mail = new MailMessage(from, to);
            smtp = new SmtpClient();
            smtp.Port = port;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Host = host;
        }

        public void addSubject(string subject)
        {
            mail.Subject = subject;         
        }

        public void addBody(string body)
        {
            mail.Body = body;
        }

        public void send()
        {
            smtp.Send(mail);
            Logger.Info("Error email has been sent!");
        }

    }
}
