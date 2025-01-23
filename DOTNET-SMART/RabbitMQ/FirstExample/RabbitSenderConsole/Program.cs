using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
    // HostName = "localhost",
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
    ClientProvidedName = "Rabbit Sender App"
};
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();


string exchangeName = "DemoExchange";
string routingKey = "demo-routing-key";
string queueName = "DemoQueue";


await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);

await channel.QueueDeclareAsync(
    queue: queueName,
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

await channel.QueueBindAsync(
    queueName,
    exchangeName,
    routingKey,
    null
);

// when you send a message to the queue, this will send a set of bites
// we are taking the message, we are encoding it
byte[] messageBodyBytes = Encoding.UTF8.GetBytes("Hello Demo Queue3");

await channel.BasicPublishAsync(
    exchange: exchangeName,
    routingKey: routingKey,
    body: messageBodyBytes
);
Console.WriteLine($" [x] Sent message: {messageBodyBytes}");

await channel.CloseAsync();
await connection.CloseAsync();

Console.WriteLine("Press Enter to exit program.");
Console.ReadLine();
