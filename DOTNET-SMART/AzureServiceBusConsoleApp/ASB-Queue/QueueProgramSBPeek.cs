// // See https://aka.ms/new-console-template for more information
// using Azure.Messaging.ServiceBus;

// // Create Connection
// await using var client = new ServiceBusClient(
//     "Endpoint=sb://learn-servicebus-queue.servicebus.windows.net/;SharedAccessKeyName=ConnectionStringQueue;SharedAccessKey=TYi2ti3sgMh8cPWT/+cD24cmJxIl9fby8+ASbDj9W4Y=;EntityPath=firstqueuetest"
// );

// // // Create Sender
// // ServiceBusSender sender = client.CreateSender("firstqueuetest"); // you need to pass the quename

// // // Send Message
// // await sender.SendMessageAsync(new ServiceBusMessage("Hello Eduard - peek message."));

// // Create Receiver
// ServiceBusReceiver receiver = client.CreateReceiver("firstqueuetest", new ServiceBusReceiverOptions
// {
//     ReceiveMode = ServiceBusReceiveMode.PeekLock
// });

// // Receive the message
// ServiceBusReceivedMessage receivedMessage = await receiver.PeekMessageAsync();

// if (receivedMessage is not null)
// {
//     Console.WriteLine("Received Single Message");
//     Console.WriteLine(receivedMessage.Body.ToString());
// }
// else
// {
//     Console.WriteLine("No message.");
// }


// // Receive the messages list, it will start without the first because this is how the peek lock works (you need to wait time to expire)
// // If you want to receive all, comment code above that take the first message
// var receivedMessagesList = await receiver.PeekMessagesAsync(maxMessages: 10);
// if (receivedMessagesList.Count > 0)
// {
//     Console.WriteLine("Received Messages List");
//     Console.WriteLine($"Total Received Messages List: {receivedMessagesList.Count}");
//     foreach (ServiceBusReceivedMessage singleMessage in receivedMessagesList)
//     {
//         Console.WriteLine(singleMessage.SequenceNumber.ToString());
//         Console.WriteLine(singleMessage.Body.ToString());
//     }
// }
// else
// {
//     Console.WriteLine("No message.");
// }



// Console.ReadLine();