using System;
using Confluent.Kafka;
using eHealthClinic.Core.Event.Interface;

namespace eHealthClinic.Core.Event.Implementation.Kafka
{
	public class KafkaConsumer: IEventConsumer
    {
        private readonly IConsumer<Null, string> _consumer;

        public KafkaConsumer(string bootstrapServers, string groupId)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Latest
                
            };

            _consumer = new ConsumerBuilder<Null, string>(config).Build();
        }

        public string Consume()
        {
            var consumeResult = _consumer.Consume();
            return consumeResult.Message.Value;
        }

        public void Subscribe(string eventName)
        {
            _consumer.Subscribe(eventName);
        }

        public void Subscribe(string[] eventNames)
        {
            _consumer.Subscribe(eventNames);
        }
    }
}

