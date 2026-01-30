namespace OrdersAPI.Events;

public class ConsoleEventPublisher : IEventPublisher
{
    Task IEventPublisher.PublishAsync<TEvent>(TEvent evt)
    {
        Console.WriteLine($"---> Event Published: {evt}");
        return Task.CompletedTask;
    }
}