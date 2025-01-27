using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionLocalProject
{
    public class MyServiceBusQueueTriggerExample1
    {
        private readonly ILogger<MyServiceBusQueueTriggerExample1> _logger;

        public MyServiceBusQueueTriggerExample1(ILogger<MyServiceBusQueueTriggerExample1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(MyServiceBusQueueTriggerExample1))]
        public async Task Run(
            [ServiceBusTrigger("firstqueuetest", Connection = "ServiceBusConnectionString")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
