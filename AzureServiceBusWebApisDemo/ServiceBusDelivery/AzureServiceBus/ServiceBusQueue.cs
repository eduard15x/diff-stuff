using System.Text;
using System.Text.Json.Serialization;
using Azure.Messaging.ServiceBus;
using AzureServiceBusWebApisDemo.ServiceBusDelivery.Models;
using Newtonsoft.Json;

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

        public async Task<Order> ReceiveMessage(string queueName)
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
                    var deserializedObject = JsonConvert.DeserializeObject<Order>(receivedMessage.Body.ToString());
                    // var messageBody = Encoding.UTF8.GetString(receivedMessage.Body);
                    return deserializedObject;
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
