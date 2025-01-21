// // See https://aka.ms/new-console-template for more information
// using Azure.Messaging.ServiceBus;
// using Azure.Messaging.ServiceBus.Administration;

// // Create Connection
// await using var client = new ServiceBusClient(
//     "Endpoint=sb://learn-servicebus-topic.servicebus.windows.net/;SharedAccessKeyName=NewConnectionTopic;SharedAccessKey=CRRjFDdmTIzY9hG5HC5a/NqDeLcHBWqUL+ASbK2QPqc=;EntityPath=firsttopic"
// );

// ServiceBusAdministrationClient administrationClient = new ServiceBusAdministrationClient(
//     "Endpoint=sb://learn-servicebus-topic.servicebus.windows.net/;SharedAccessKeyName=NewConnectionTopic;SharedAccessKey=CRRjFDdmTIzY9hG5HC5a/NqDeLcHBWqUL+ASbK2QPqc=;EntityPath=firsttopic"
// );


// // SQL Filters
// await administrationClient.CreateSubscriptionAsync(
//     new CreateSubscriptionOptions("firsttopic", "SubscriptionSQLFilter"),
//     new CreateRuleOptions("sqlrules", new SqlRuleFilter("name='Eduard'"))
// ); // when the name is Eduard the condition will be accepted (the rule will pass)


// var sender = client.CreateSender("firsttopic");
// // Send Message 1
// Customer customerObject_one = new Customer { Age = 25, Name = "Eduard" };
// var createdMessage_one = new ServiceBusMessage()
// {
//     ApplicationProperties = { { "name", customerObject_one.Name }, { "age", customerObject_one.Age } },
// };
// await sender.SendMessageAsync(createdMessage_one);

// // Send Message 2
// Customer customerObject_two = new Customer { Age = 30, Name = "Maris" };
// var createdMessage_two = new ServiceBusMessage()
// {
//     ApplicationProperties = { { "name", customerObject_two.Name }, { "age", customerObject_two.Age } },
// };
// await sender.SendMessageAsync(createdMessage_two);

// // Send Message 2
// Customer customerObject_three = new Customer { Age = 31, Name = "Eduard" };
// var createdMessage_three = new ServiceBusMessage()
// {
//     ApplicationProperties = { { "name", customerObject_three.Name }, { "age", customerObject_three.Age } },
// };
// await sender.SendMessageAsync(createdMessage_three);

// class Customer
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
// }