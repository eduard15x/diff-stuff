// // See https://aka.ms/new-console-template for more information
// // * Read the message and delete it from Azure Service Bus

// using Azure.Messaging.ServiceBus;

// // Create Connection
// await using var client = new ServiceBusClient(
//     "Endpoint=sb://learn-servicebus-queue.servicebus.windows.net/;SharedAccessKeyName=ConnectionStringQueue;SharedAccessKey=TYi2ti3sgMh8cPWT/+cD24cmJxIl9fby8+ASbDj9W4Y=;EntityPath=firstqueuetest"
// );

// // Create Sender
// ServiceBusSender sender = client.CreateSender("firstqueuetest"); // you need to pass the quename

// // Send Message
// await sender.SendMessageAsync(new ServiceBusMessage("learn about the delivery count 4."));

// ServiceBusReceiver receiver = client.CreateReceiver("firstqueuetest");

// // the process it also lock the message so it wont increment the count instant (it need to wait for the lock time to expire)
// for (int i = 0; i < 10; i++)
// {
//     ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
// }

// Console.ReadLine();