using System;
namespace eHealthClinic.Core.Event.Interface
{
	public interface IEventConsumer
	{
        string Consume();
        void Subscribe(string eventName);
        void Subscribe(string[] eventNames);

    }
}

