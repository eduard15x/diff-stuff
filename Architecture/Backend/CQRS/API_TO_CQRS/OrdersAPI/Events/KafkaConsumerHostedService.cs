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
    private readonly ILogger<KafkaConsumerHostedService> _logger;

    public KafkaConsumerHostedService(IConfiguration config, IServiceProvider serviceProvider, ILogger<KafkaConsumerHostedService> logger)
    {
        _config = config;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            var bootstrapServers = _config.GetValue<string>("Kafka:BootstrapServers");
            var topic = _config.GetValue<string>("Kafka:Topics:OrderCreated") ?? "order-created";

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = "orders-api-group",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true,
                // AllowAutoCreateTopics = true,
                AllowAutoCreateTopics = false,
                SessionTimeoutMs = 6000,
                ReconnectBackoffMs = 100,
                ReconnectBackoffMaxMs = 10000
            };

            IConsumer<Ignore, string> consumer = null;
            int retries = 0;
            const int maxRetries = 10;

            while (consumer == null && retries < maxRetries && !stoppingToken.IsCancellationRequested)
            {
                try
                {
                    consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
                    consumer.Subscribe(topic);
                    Console.WriteLine($"Successfully subscribed to topic '{topic}'");
                    _logger.LogInformation($"Successfully subscribed to topic '{topic}'");

                    // Wait for partition assignment after subscription
                    await Task.Delay(2000, stoppingToken);
                    break;
                }
                catch (Exception ex)
                {
                    retries++;
                    _logger.LogWarning($"Failed to connect to Kafka (attempt {retries}/{maxRetries}): {ex.Message}");
                    consumer?.Dispose();
                    consumer = null;
                    await Task.Delay(2000, stoppingToken);
                }
            }

            if (consumer == null)
            {
                Console.WriteLine("Failed to connect to Kafka after maximum retries");
                _logger.LogError("Failed to connect to Kafka after maximum retries. Consumer will not start.");
                return;
            }

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
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
                                Console.WriteLine($"Successfully processed OrderCreatedEvent for Order ID: {evt.OrderId}");
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
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ConsumeException cex)
                    {
                        _logger.LogWarning($"Kafka consume exception: {cex.Error.Reason}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Kafka consumer error: {ex.Message}");
                        await Task.Delay(1000, stoppingToken);
                    }
                }
            }
            finally
            {
                consumer?.Close();
                consumer?.Dispose();
                Console.WriteLine("Kafka consumer stopped");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected error in KafkaConsumerHostedService: {ex.Message}");
        }
    }
}
