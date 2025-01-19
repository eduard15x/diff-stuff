using AzureServiceBusWebApisDemo.ServiceBusDelivery.Models;

namespace AzureServiceBusWebApisDemo.ServiceBusDelivery.AzureServiceBus
{
    public interface IServiceBusQueue
    {
        Task SendMessage(string queueName, string message);
        Task<Order> ReceiveMessage(string queueName);
    }
}
