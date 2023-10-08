using Confluent.Kafka;
using eHealthClinic.Core.Event.Interface;

namespace eHealthClinic.Core.Event.Implementation.Kafka
{
	public class KafkaProducer: IEventProducer
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducer(string bootstrapServers)
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceAsync(string eventName, string message)
        {
            await _producer.ProduceAsync(eventName, new Message<Null, string> { Value = message });
        }
    }
}

