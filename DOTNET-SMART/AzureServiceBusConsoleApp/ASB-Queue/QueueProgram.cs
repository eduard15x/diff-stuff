// // See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

// Create Connection
await using var client = new ServiceBusClient(
    "Endpoint=sb://learn-servicebus-queue.servicebus.windows.net/;SharedAccessKeyName=ConnectionStringQueue;SharedAccessKey=TYi2ti3sgMh8cPWT/+cD24cmJxIl9fby8+ASbDj9W4Y=;EntityPath=firstqueuetest"
);

// Create Sender
ServiceBusSender sender = client.CreateSender("firstqueuetest"); // you need to pass the quename

// Send Message
await sender.SendMessageAsync(new ServiceBusMessage($"Hello Eduard, this message is send to queue to test Azure Function Service Bus Queue Trigger - {DateTime.Now}."));

// await sender.SendMessageAsync(new ServiceBusMessage($"Hello Eduard, TEST."));
// // Create Receiver
// ServiceBusReceiver receiver = client.CreateReceiver("firstqueuetest"); // you need to pass the quename

// // Receive the message
// ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// // *1 await receiver.CompleteMessageAsync(receivedMessage);
// // *2 await receiver.AbandonMessageAsync(receivedMessage);

// // *3 receiver.DeferMessageAsync(receivedMessage);
// // // Read the defer message
// // ServiceBusReceivedMessage deferMessage = await receiver.ReceiveDeferredMessageAsync(receivedMessage.SequenceNumber);

// // *4 Send message to dlQ
// await receiver.DeadLetterMessageAsync(receivedMessage, "reason", "This is a reason.");
// // Receive the message from dlQ
// ServiceBusReceiver dlqReceiver = client.CreateReceiver("firstqueuetest", new ServiceBusReceiverOptions
// {
//     SubQueue = SubQueue.DeadLetter
// });
// ServiceBusReceivedMessage dlqReceivedMessage = await dlqReceiver.ReceiveMessageAsync();


// Console.WriteLine("Received Message");
// Console.WriteLine(receivedMessage.Body.ToString());
// // *3 Console.WriteLine("Defer Message");
// // Console.WriteLine(deferMessage.Body.ToString());

// // *4 Console.WriteLine("DeadLetter Message");
// Console.WriteLine(dlqReceivedMessage.Body.ToString());
// Console.ReadLine();