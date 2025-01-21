using System.Net;
using System.Net.Mail;
using SMTP_Example2.Models;

namespace SMTP_Example2.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }
        public async Task SendEmail(string receptor, string subject, string body)
        {
            var email = "eduard.precup@devuard.com";
            // Go to Google Account -> Manage Account -> App Password, and create a password for your needs
            var password = "";
            var smtpServer = "smtp.gmail.com";
            var smtpPort = 587;

            // 587 (TLS): Recommended for securely sending emails. Requires the use of Transport Layer Security (TLS) encryption.
            // 465 (SSL): Used for SMTP connections encrypted with Secure Sockets Layer (SSL). Note that this port is considered less modern than TLS but is still supported.

            try
            {
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                _logger.LogInformation("Client created");

                smtpClient.Credentials = new NetworkCredential(email, password);

                var message = new MailMessage(email!, receptor, subject, body);
                await smtpClient.SendMailAsync(message);
                _logger.LogInformation("Email sent");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error occured", ex.Message);
            }
        }
    }
}