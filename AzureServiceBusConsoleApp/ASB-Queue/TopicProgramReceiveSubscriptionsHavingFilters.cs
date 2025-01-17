using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

// Create Connection
await using var client = new ServiceBusClient(
    "Endpoint=sb://learn-servicebus-topic.servicebus.windows.net/;SharedAccessKeyName=NewConnectionTopic;SharedAccessKey=CRRjFDdmTIzY9hG5HC5a/NqDeLcHBWqUL+ASbK2QPqc=;EntityPath=firsttopic"
);

var receiver = client.CreateReceiver(
    "firsttopic",
    "SubscriptionSQLFilter",
    new ServiceBusReceiverOptions()
    {
        ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete,
    }
);

// var receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(10));

// if (receivedMessage is not null)
// {
//     foreach (var prop in receivedMessage.ApplicationProperties)
//     {
//         Console.WriteLine($"{prop.Key} - {prop.Value}");
//     }
// }


var receivedMessageList = await receiver.ReceiveMessagesAsync(maxMessages: 10);

if (receivedMessageList.Count > 0)
{
    foreach (var receivedMessage in receivedMessageList)
    {
        foreach (var prop in receivedMessage.ApplicationProperties)
        {

            Console.WriteLine($"{prop.Key} - {prop.Value}");
        }
        Console.WriteLine("------");
    }
}


Console.ReadLine();
