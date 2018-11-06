using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ConfigHelper;

namespace OnlineShop.Common
{
    public class MailHelper
    {
        public static bool SendMail(string toEmail, string subject, string content)
        {
            try
            {
                var host = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
                var port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SMTPPort"]);
                var fromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmailAddress"];
                var password = System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"];
                var fromName = System.Configuration.ConfigurationManager.AppSettings["FromName"];

                var smtpClient = new SmtpClient(host, port)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 100000
                };

                var mail = new MailMessage
                {
                    Body = content,
                    Subject = subject,
                    From = new MailAddress(fromEmail, fromName)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                smtpClient.Send(mail);

                return true;
            }
            catch (SmtpException smex)
            {

                return false;
            }
        }
    }
}

