using Rebus.Bus;
using Rebus.Bus.Advanced;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class MockBus : IBus
{
    private readonly ILogger<MockBus> _logger;

    public MockBus(ILogger<MockBus> logger)
    {
        _logger = logger;
    }

    public Task Publish(object eventMessage, IDictionary<string, string> optionalHeaders = null)
    {
        // Log do evento ao invés de publicar
        _logger.LogInformation("Event Published: {EventType} - {EventData}",
            eventMessage.GetType().Name,
            JsonSerializer.Serialize(eventMessage));

        return Task.CompletedTask;
    }

    // Implementações vazias para outros métodos obrigatórios da interface
    public Task Send(object commandMessage, IDictionary<string, string> optionalHeaders = null)
    {
        _logger.LogInformation("Command Sent: {CommandType}", commandMessage.GetType().Name);
        return Task.CompletedTask;
    }

    public Task SendLocal(object commandMessage, IDictionary<string, string> optionalHeaders = null)
    {
        _logger.LogInformation("Local Command Sent: {CommandType}", commandMessage.GetType().Name);
        return Task.CompletedTask;
    }

    public Task Reply(object replyMessage, IDictionary<string, string> optionalHeaders = null)
    {
        _logger.LogInformation("Reply Sent: {ReplyType}", replyMessage.GetType().Name);
        return Task.CompletedTask;
    }

    public Task Defer(TimeSpan delay, object message, IDictionary<string, string> optionalHeaders = null)
    {
        _logger.LogInformation("Message Deferred: {MessageType} for {Delay}", message.GetType().Name, delay);
        return Task.CompletedTask;
    }

    public Task DeferLocal(TimeSpan delay, object message, IDictionary<string, string> optionalHeaders = null)
    {
        _logger.LogInformation("Local Message Deferred: {MessageType} for {Delay}", message.GetType().Name, delay);
        return Task.CompletedTask;
    }

    public Task Subscribe<TEvent>()
    {
        _logger.LogInformation("Subscribed to event: {EventType}", typeof(TEvent).Name);
        return Task.CompletedTask;
    }

    public Task Subscribe(Type eventType)
    {
        _logger.LogInformation("Subscribed to event: {EventType}", eventType.Name);
        return Task.CompletedTask;
    }

    public Task Unsubscribe<TEvent>()
    {
        _logger.LogInformation("Unsubscribed from event: {EventType}", typeof(TEvent).Name);
        return Task.CompletedTask;
    }

    public Task Unsubscribe(Type eventType)
    {
        _logger.LogInformation("Unsubscribed from event: {EventType}", eventType.Name);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        // Nada para fazer aqui
    }

    public IAdvancedApi Advanced => throw new NotSupportedException("Advanced API not supported in mock");
}