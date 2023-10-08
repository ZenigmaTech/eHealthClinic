using System;
namespace eHealthClinic.Core.Event.Interface
{
	public interface IEventProducer
	{
        Task ProduceAsync(string eventName, string message);
    }
}

