using System.Net.Mail;

namespace Mqeb.Application.Sender
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("zargarzadehmahdi0@gmail.com", "موسسه قرآن و عترت بینه");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("zargarzadehmahdi0@gmail.com", "m34224120zmahdi");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}