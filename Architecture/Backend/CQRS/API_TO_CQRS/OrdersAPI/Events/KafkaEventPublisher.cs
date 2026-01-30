using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace OrdersAPI.Events;

public class KafkaEventPublisher : IEventPublisher
{
    private readonly IConfiguration _config;
    private readonly IProducer<string, string> _producer;

    public KafkaEventPublisher(IConfiguration config)
    {
        _config = config;
        var bootstrapServers = config.GetValue<string>("Kafka:BootstrapServers");
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = bootstrapServers,
            Acks = Acks.All,
            MessageSendMaxRetries = 2,
            EnableIdempotence = true
            // Retries = 3
        };
        _producer = new ProducerBuilder<string, string>(producerConfig).Build();
    }

    public async Task PublishAsync<TEvent>(TEvent evt)
    {
        var topicName = GetTopicName(typeof(TEvent));
        var payload = JsonSerializer.Serialize(evt);

        Console.WriteLine($"---Publishing event {typeof(TEvent).Name} to topic {topicName}");

        var message = new Message<string, string>
        {
            Key = evt?.GetHashCode().ToString() ?? Guid.NewGuid().ToString(),
            Value = payload
        };

        var result = await _producer.ProduceAsync(topicName, message);

        if (result.Status == PersistenceStatus.NotPersisted)
        {
            throw new Exception($"Failed to publish event {typeof(TEvent).Name} to Kafka topic {topicName}");
        }
    }

    private string GetTopicName(Type eventType)
    {
        return eventType.Name switch
        {
            nameof(OrderCreatedEvent) => _config.GetValue<string>("Kafka:Topics:OrderCreated") ?? "order-created",
            _ => "events"
        };
    }
}
