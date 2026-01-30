using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace OrdersAPI.Events;

public class KafkaConsumerHostedService : BackgroundService
{
    private readonly IConfiguration _config;
    private readonly IServiceProvider _serviceProvider;

    public KafkaConsumerHostedService(IConfiguration config, IServiceProvider serviceProvider)
    {
        _config = config;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var bootstrapServers = _config.GetValue<string>("Kafka:BootstrapServers");
        var topic = _config.GetValue<string>("Kafka:Topics:OrderCreated") ?? "order-created";

        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = "orders-api-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = true
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        consumer.Subscribe(topic);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(stoppingToken);

                if (consumeResult?.Message?.Value == null)
                    continue;

                try
                {
                    // Deserialize the message to OrderCreatedEvent
                    var evt = JsonSerializer.Deserialize<OrderCreatedEvent>(consumeResult.Message.Value);

                    if (evt != null)
                    {
                        // Create a scope for dependency injection
                        using var scope = _serviceProvider.CreateScope();
                        var handler = scope.ServiceProvider.GetRequiredService<IEventHandler<OrderCreatedEvent>>();
                        await handler.HandleAsync(evt);
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Failed to deserialize message: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing Kafka message: {ex.Message}");
                }
            }
        }
        catch (OperationCanceledException)
        {
            consumer.Close();
        }
        finally
        {
            consumer.Close();
        }
    }
}
