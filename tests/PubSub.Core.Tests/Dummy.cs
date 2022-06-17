using PubSub.Core.EventBus.Local;
using PubSub.Core.EventBus.Local.Contracts;

namespace PubSub.Core.Tests;

public class Dummy
{
    public class Message
    {
        public string From { get; set; }
        public string Body { get; set; }
    }

    public class DummySubscriber : Subscriber<Message>
    {
        public DummySubscriber(ILocalEventBus bus) : base(bus)
        {
        }

        public override void Notify(Message message)
        {
        }
    }
}