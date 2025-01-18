using System.Text;
using Azure.Messaging.ServiceBus;

namespace AzureServiceBusWebApisDemo.ServiceBusDelivery.AzureServiceBus
{
    public class ServiceBusQueue : IServiceBusQueue
    {
        private readonly string _connectionString;
        public ServiceBusQueue(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task SendMessage(string queueName, string message)
        {
            try
            {
                var serviceBusClient = new ServiceBusClient(_connectionString, new ServiceBusClientOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets
                });

                var serviceBusSender = serviceBusClient.CreateSender(queueName);

                await serviceBusSender.SendMessageAsync(new ServiceBusMessage(message));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<string> ReceiveMessage(string queueName)
        {
            try
            {
                var serviceBusClient = new ServiceBusClient(_connectionString, new ServiceBusClientOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets
                });

                var serviceBusReceiver = serviceBusClient.CreateReceiver(queueName);
                var receivedMessage = await serviceBusReceiver.ReceiveMessageAsync();

                if (receivedMessage is null)
                {
                    throw new ArgumentException("No message received");
                }
                else
                {
                    var messageBody = Encoding.UTF8.GetString(receivedMessage.Body);
                    return messageBody;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
