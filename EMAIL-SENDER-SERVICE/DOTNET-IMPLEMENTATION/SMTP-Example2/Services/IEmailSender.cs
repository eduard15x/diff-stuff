using SMTP_Example2.Models;

namespace SMTP_Example2.Services
{
    public interface IEmailSender
    {
        Task SendEmail(string receptor, string subject, string body);
    }
}