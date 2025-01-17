// using Azure.Messaging.ServiceBus;
// using Azure.Messaging.ServiceBus.Administration;

// // Create Connection
// await using var client = new ServiceBusClient(
//     "Endpoint=sb://learn-servicebus-topic.servicebus.windows.net/;SharedAccessKeyName=NewConnectionTopic;SharedAccessKey=CRRjFDdmTIzY9hG5HC5a/NqDeLcHBWqUL+ASbK2QPqc=;EntityPath=firsttopic"
// );

// ServiceBusAdministrationClient administrationClient = new ServiceBusAdministrationClient(
//     "Endpoint=sb://learn-servicebus-topic.servicebus.windows.net/;SharedAccessKeyName=NewConnectionTopic;SharedAccessKey=CRRjFDdmTIzY9hG5HC5a/NqDeLcHBWqUL+ASbK2QPqc=;EntityPath=firsttopic"
// );

// // Correlation Filters
// await administrationClient.CreateSubscriptionAsync(
//     new CreateSubscriptionOptions("firsttopic", "SubscriptionCorrelationFilter2"),
//     new CreateRuleOptions("correlationfilters", new CorrelationRuleFilter() { Subject = "Eduard-Correlation" })
// // TrueRuleFilter() default -> all messages are accepted
// );


// var sender = client.CreateSender("firsttopic");
// // Send Message 1
// await sender.SendMessageAsync(new ServiceBusMessage("Boolean message test."));

// Customer obj = new Customer { Age = 30, Name = "Eduard" };
// var createdMessage = new ServiceBusMessage()
// {
//     Subject = "Eduard-Correlation",
//     ApplicationProperties = { { "name", obj.Name }, { "age", obj.Age } }
// };
// await sender.SendMessageAsync(createdMessage);

// class Customer
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
// }