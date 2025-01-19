using AzureServiceBusWebApisDemo.ServiceBusDelivery.AzureServiceBus;
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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Listener Started");

            while (!stoppingToken.IsCancellationRequested)
            {
                var messageReceived = await _serviceBusQueue.ReceiveMessage("emailorderqueue");
                Console.WriteLine(messageReceived.OrderId);
                Console.WriteLine(messageReceived.OrderName);
                Console.ReadLine();
            }
        }
    }
}