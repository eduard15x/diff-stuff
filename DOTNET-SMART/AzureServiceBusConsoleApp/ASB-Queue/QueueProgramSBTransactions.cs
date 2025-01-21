// // See https://aka.ms/new-console-template for more information
// // * A transaction is a multitude of operations, and if anyone fail it will revert/rollback the transaction

// using System.Transactions;
// using Azure.Messaging.ServiceBus;

// // Create Connection
// await using var client = new ServiceBusClient(
//     "Endpoint=sb://learn-servicebus-queue.servicebus.windows.net/;SharedAccessKeyName=ConnectionStringQueue;SharedAccessKey=TYi2ti3sgMh8cPWT/+cD24cmJxIl9fby8+ASbDj9W4Y=;EntityPath=firstqueuetest"
// );

// // Create Sender
// ServiceBusSender sender = client.CreateSender("firstqueuetest"); // you need to pass the quename

// // Send Message
// await sender.SendMessageAsync(new ServiceBusMessage("learn about transactions."));

// // Create Receiver
// ServiceBusReceiver receiver = client.CreateReceiver("firstqueuetest");

// ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
// {
//     await sender.SendMessageAsync(new ServiceBusMessage("Exception In transaction"));
//     await receiver.CompleteMessageAsync(receivedMessage);

//     // throw new Exception("Invalid Operation");
//     var a = 0;
//     var b = 1;
//     var c = b / a;

//     transaction.Complete(); // it will commit everything
//     // transaction.Dispose(); // when you have done with transaction it will remove out of scope
// }


// Console.ReadLine();