using eHealthClinic.Core.Event.Implementation.Kafka;
using eHealthClinic.Core.Event.Interface;
using Notification;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IEventConsumer>(serviceProvider => new KafkaConsumer("kafka-server:9092", "eHealthClinic"));
        services.AddHostedService<EventWorker>();

    })
    .Build();
host.Run();

