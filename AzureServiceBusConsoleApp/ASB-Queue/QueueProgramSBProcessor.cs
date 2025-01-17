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
// await sender.SendMessageAsync(new ServiceBusMessage("learn about the processor."));

// // Create Processor
// await using ServiceBusProcessor serviceBusProcessor = client.CreateProcessor("firstqueuetest", new ServiceBusProcessorOptions
// {
//     AutoCompleteMessages = true, // complete messages when they are done
//     MaxConcurrentCalls = 1 // how many messages you want to process in paralel

// });

// // Configure message
// serviceBusProcessor.ProcessMessageAsync += MessageHandler; // this is a delegate
// serviceBusProcessor.ProcessErrorAsync += ErrorHandler; // this is a delegate

// // Configure Handler
// async Task MessageHandler(ProcessMessageEventArgs processMessageEventArgs)
// {
//     // Process your message
//     Console.WriteLine(processMessageEventArgs.Message.Body.ToString());
// }

// // Configure Error
// Task ErrorHandler(ProcessErrorEventArgs processErrorEventArgs)
// {
//     // Process your error
//     Console.WriteLine(processErrorEventArgs.ErrorSource);

//     return Task.CompletedTask;
// }

// // Start processing
// await serviceBusProcessor.StartProcessingAsync();

// Console.ReadLine();