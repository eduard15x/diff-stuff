namespace SMTP_Example2.Models
{
    public class Email
    {
        public string Subject { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMessage { get; set; }
    }
}