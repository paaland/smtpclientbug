using System.Net.Mail;
using System.Text;

namespace Tool.SmtpTesterCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var smtpClient = new SmtpClient()
            {
                Host = "localhost",
                Port = 25,
                EnableSsl = false
            };

            var mailmessage = new MailMessage()
            {
                IsBodyHtml = true,
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8,
            };

            mailmessage.From = new MailAddress("someone@here.com", "someone@here.com");
            mailmessage.To.Add("someone@somewhere.com");
            mailmessage.Body = "<b>This is a test</b><p>This is a test of outgoing emails with special characters in subject</p>";
            mailmessage.Subject = "Async: Noe med æøå eller ÆØÅ og ß";

            smtpClient.SendMailAsync(mailmessage).Wait();

            mailmessage.Subject = "Sync: Noe med æøå eller ÆØÅ og ß";

            smtpClient.Send(mailmessage);
        }
    }
}
