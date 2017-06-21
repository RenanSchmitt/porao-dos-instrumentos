using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace PoraoDosInstrumentos.Models
{
    public class SendEmail
    {
        private const string EMAIL_FROM = "willian85pereira@gmail.com";
        private const string HOTMAIL_SMTP = "smtp.gmail.com";
        private const int PORT = 587;
        private const string PASSWORD_FROM = "willp.85@dev";

        public static bool CreateMailMessage(string emailTo, string subject, string contentHTML)
        {
            try
            {

                //create the object about the email.
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(EMAIL_FROM);
                    mail.To.Add(emailTo);
                    mail.IsBodyHtml = true;
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.BodyEncoding = Encoding.UTF8;

                    mail.Subject = subject;
                    mail.Body = string.Format("Usuário {0} enviou uma mensagem: {1}", emailTo, contentHTML );

                    bool result = Send(mail);

                    return result;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool Send(MailMessage mail)
        {
            try
            {
                if (mail == null)
                    return false;

                //create the client.
                using (SmtpClient client = new SmtpClient(HOTMAIL_SMTP))
                {
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.Port = PORT;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(EMAIL_FROM, PASSWORD_FROM);
                    client.EnableSsl = true;
                    //send the email.
                    client.Send(mail);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}