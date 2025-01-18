namespace AzureServiceBusWebApisDemo.ServiceBusDelivery.AzureServiceBus
{
    public interface IServiceBusQueue
    {
        Task SendMessage(string queueName, string message);
        Task<string> ReceiveMessage(string queueName);
    }
}
