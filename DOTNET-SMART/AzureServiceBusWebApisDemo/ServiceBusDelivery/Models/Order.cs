namespace AzureServiceBusWebApisDemo.ServiceBusDelivery.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string OrderName { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}