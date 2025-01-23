using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    // HostName = "localhost",
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
    ClientProvidedName = "Rabbit Receiver App"
};
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

string exchangeName = "DemoExchange";
string routingKey = "demo-routing-key";
string queueName = "DemoQueue";

Console.WriteLine($" [*] Waiting for messages from queue - {queueName}.");

await channel.ExchangeDeclareAsync(
    exchangeName,
    ExchangeType.Direct
);
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

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += async (sender, args) =>
{
    Task.Delay(TimeSpan.FromSeconds(3)).Wait();
    var body = args.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    Console.WriteLine($" [*] Received {message}");

    await channel.BasicAckAsync(args.DeliveryTag, false);
};

var consumerTag = await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);

await channel.BasicCancelAsync(consumerTag);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();



await channel.CloseAsync();
await connection.CloseAsync();