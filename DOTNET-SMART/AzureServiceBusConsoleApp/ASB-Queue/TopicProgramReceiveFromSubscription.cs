// // See https://aka.ms/new-console-template for more information
// using Azure.Messaging.ServiceBus;

// // Create Connection
// await using var client = new ServiceBusClient(
//     "Endpoint=sb://learn-servicebus-topic.servicebus.windows.net/;SharedAccessKeyName=NewConnectionTopic;SharedAccessKey=CRRjFDdmTIzY9hG5HC5a/NqDeLcHBWqUL+ASbK2QPqc=;EntityPath=firsttopic"
// );

// // // Create Sender
// // ServiceBusSender sender = client.CreateSender("firsttopic"); // you need to pass the topic name

// // // Send Message
// // await sender.SendMessageAsync(new ServiceBusMessage("sending message to multiple subscriptions (1,2)."));

// // Create Receiver
// ServiceBusReceiver receiver = client.CreateReceiver(
//     "firsttopic", // you need to pass the topic name
//     "Subscription1" // you need to pass the subscription name
// );

// // Receive the message
// ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// // // *1 await receiver.CompleteMessageAsync(receivedMessage);
// // // *2 await receiver.AbandonMessageAsync(receivedMessage);

// // // *3 receiver.DeferMessageAsync(receivedMessage);
// // // // Read the defer message
// // // ServiceBusReceivedMessage deferMessage = await receiver.ReceiveDeferredMessageAsync(receivedMessage.SequenceNumber);

// // // *4 Send message to dlQ
// // await receiver.DeadLetterMessageAsync(receivedMessage, "reason", "This is a reason.");
// // // Receive the message from dlQ
// // ServiceBusReceiver dlqReceiver = client.CreateReceiver("firstqueuetest", new ServiceBusReceiverOptions
// // {
// //     SubQueue = SubQueue.DeadLetter
// // });
// // ServiceBusReceivedMessage dlqReceivedMessage = await dlqReceiver.ReceiveMessageAsync();

// if (receivedMessage is null)

// {
//     throw new ArgumentException("No message available");
// }
// Console.WriteLine("Received Message");
// Console.WriteLine(receivedMessage.Body.ToString());
// await receiver.CompleteMessageAsync(receivedMessage);

// // // *3 Console.WriteLine("Defer Message");
// // // Console.WriteLine(deferMessage.Body.ToString());

// // // *4 Console.WriteLine("DeadLetter Message");
// // Console.WriteLine(dlqReceivedMessage.Body.ToString());
// // Console.ReadLine();