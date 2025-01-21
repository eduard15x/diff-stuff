using AzureServiceBusWebApisDemo.ServiceBusDelivery.AzureServiceBus;
using AzureServiceBusWebApisDemo.ServiceBusDelivery.Models;
using Newtonsoft.Json;

namespace EmailAPI.BackgroundService
{
    public class AzureServiceBusListener : Microsoft.Extensions.Hosting.BackgroundService
    {
        protected readonly IServiceBusQueue _serviceBusQueue;
        private readonly ILogger<AzureServiceBusListener> _logger;

        public AzureServiceBusListener(ILogger<AzureServiceBusListener> logger, IServiceBusQueue serviceBusQueue)
        {
            _logger = logger;
            _serviceBusQueue = serviceBusQueue;
        }

        // Receive single queue
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Listener Started");

            while (!stoppingToken.IsCancellationRequested)
            {
                var messageReceived = await _serviceBusQueue.ReceiveMessage("emailorderqueue");
                Console.WriteLine(messageReceived.OrderId);
                Console.WriteLine(messageReceived.OrderName);
            }
        }

        // Receive batch of messages
        // protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        // {
        //     _logger.LogInformation("Listener Started For Batch of messages");

        //     while (!stoppingToken.IsCancellationRequested)
        //     {
        //         var messagesList = await _serviceBusQueue.ReceiveMessagesBatch<Order>("emailorderqueue");
        //         foreach (var message in messagesList)
        //         {
        //             Console.WriteLine(message.ToString());
        //             Console.WriteLine(message.OrderId);
        //             Console.WriteLine(message.OrderName);
        //             Console.WriteLine("--------------");
        //         }
        //     }
        // }
    }
}