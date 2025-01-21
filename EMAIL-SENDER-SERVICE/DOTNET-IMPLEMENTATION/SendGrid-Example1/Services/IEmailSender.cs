
namespace SendGrid_Example1.Services
{
    public interface IEmailSender
    {
        Task SendEmail(string subject, string receiverEmail, string receiverName, string message);
    }
}