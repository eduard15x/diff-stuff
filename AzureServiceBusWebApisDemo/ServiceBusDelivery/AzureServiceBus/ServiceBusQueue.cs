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

        public async Task SendMessage<T>(string queueName, T message)
        {
            try
            {
                var serviceBusClient = new ServiceBusClient(_connectionString, new ServiceBusClientOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets
                });

                var serviceBusSender = serviceBusClient.CreateSender(queueName);

                await serviceBusSender.SendMessageAsync(new ServiceBusMessage(JsonConvert.SerializeObject(message)));
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
                    await serviceBusReceiver.CompleteMessageAsync(receivedMessage);
                    return deserializedObject;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task SendMessages<T>(string queueName, List<T> messages)
        {
            try
            {
                var serviceBusClient = new ServiceBusClient(_connectionString, new ServiceBusClientOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets
                });

                var serviceBusSender = serviceBusClient.CreateSender(queueName);

                List<ServiceBusMessage> messagesList = messages
                    .Select(message => new ServiceBusMessage(JsonConvert.SerializeObject(message)))
                    .ToList();

                await serviceBusSender.SendMessagesAsync(messagesList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Order>> ReceiveMessagesBatch<Order>(string queueName)
        {

            try
            {
                var serviceBusClient = new ServiceBusClient(_connectionString, new ServiceBusClientOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets
                });

                var serviceBusReceiver = serviceBusClient.CreateReceiver(queueName);
                var receivedMessagesBatch = await serviceBusReceiver.ReceiveMessagesAsync(maxMessages: 5);

                if (receivedMessagesBatch is null || receivedMessagesBatch.Count == 0)
                {
                    throw new ArgumentException("No messages in queue.");
                }
                else
                {
                    List<Order> orderMessagesList = receivedMessagesBatch
                        .Select(message => JsonConvert.DeserializeObject<Order>(message.Body.ToString()))
                        .ToList();

                    return orderMessagesList;
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
