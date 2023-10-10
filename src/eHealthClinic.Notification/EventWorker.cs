using eHealthClinic.Core.Event.Interface;

namespace Notification;

public class EventWorker : BackgroundService
{
    private readonly ILogger<EventWorker> _logger;
    private readonly IEventConsumer _consumer;

    public EventWorker(ILogger<EventWorker> logger, IEventConsumer consumer)
    {
        _logger = logger;
        _consumer = consumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe( new string[] { "patient-created", "appointment-created"});
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = _consumer.Consume();
            _logger.LogInformation("Message arrived!: {0}.", message);
        }
    }
}

