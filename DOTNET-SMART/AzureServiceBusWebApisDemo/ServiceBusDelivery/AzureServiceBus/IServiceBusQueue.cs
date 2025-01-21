using AzureServiceBusWebApisDemo.ServiceBusDelivery.Models;

namespace AzureServiceBusWebApisDemo.ServiceBusDelivery.AzureServiceBus
{
    public interface IServiceBusQueue
    {
        Task SendMessage<T>(string queueName, T message);
        Task SendMessages<T>(string queueName, List<T> messages);

        Task<Order> ReceiveMessage(string queueName);
        Task<List<T>> ReceiveMessagesBatch<T>(string queueName);
    }
}
