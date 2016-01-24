using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace ePaila.Utility
{
    public class EmailSender
    {
        static MailAddress From;
        static MailAddress To;
        static MailMessage mail;
        static SmtpClient smtp;

        public static string Send(string from, string name, string msg)
        {
            try
            {
                From = new MailAddress(from);
                To = new MailAddress("app@epaila.com");
                mail = new MailMessage(From, To);
                smtp = new SmtpClient();

                mail.Subject = string.Format("You have message from {0}", name);
                mail.Body = msg;
                                
                smtp.Host = "mail.epaila.com";
                smtp.Port = 8889;

                smtp.Credentials = new NetworkCredential("app@epaila.com", "iam@ePaila.app");
                //smtp.EnableSsl = true;
                
                smtp.Send(mail);
            }
            catch(Exception ex)
            {
                return "Fail";
            }
            return "Sent";
        }
    }
}
