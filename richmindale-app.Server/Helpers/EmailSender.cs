using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace richmindale_app.Server.Helpers
{   
    // IMPORTANT: Make sure this implements IEmailSender
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value; 
        }
        public void SendMail(string sendTo, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_emailSettings.From, _emailSettings.DisplayName);
            mail.To.Add(new MailAddress(sendTo));
            mail.Subject = subject;  // THIS WAS MISSING!
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_emailSettings.From, _emailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = _emailSettings.EnableSsl;
            smtp.Timeout = 20000;
            smtp.Send(mail);
        }

        public void SendBulkMail(string[] sendTo, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_emailSettings.From, _emailSettings.DisplayName);

            for (var i = 0; i < sendTo.Length; i++)
            {
                mail.To.Add(new MailAddress(sendTo[i]));
            }
            mail.Subject = subject; 
            mail.Body = body;
            mail.IsBodyHtml = true;

            NetworkCredential nc = new NetworkCredential(_emailSettings.From, _emailSettings.Password);
            SmtpClient smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port);
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = nc;
            smtp.EnableSsl = _emailSettings.EnableSsl;
            smtp.Timeout = 20000;
            smtp.Send(mail);
        }
    }
}