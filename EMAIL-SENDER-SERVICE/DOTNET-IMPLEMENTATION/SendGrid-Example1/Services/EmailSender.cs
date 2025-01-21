using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGrid_Example1.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmail(string subject, string receiverEmail, string receiverName, string message)
        {
            var apiKey = ""; // API KEY FROM SENDGRID
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("eduard.precup@devuard.com", "Devuard Company");
            var to = new EmailAddress(receiverEmail, receiverName);
            var plainTextContent = message;
            // var htmlContent = "<h1>This is part of htmlContent variable from email sender class</h1><p><strong>and easy to do anywhere, even with C#</strong></p>";
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine("Debug class");
        }
    }
}