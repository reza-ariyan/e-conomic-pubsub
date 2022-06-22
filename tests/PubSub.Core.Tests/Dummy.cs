using PubSub.Core.EventBus.Local;
using PubSub.Core.EventBus.Local.Contracts;

namespace PubSub.Core.Tests;

public class Dummy
{
    public class Message
    {
        public string From { get; init; } = "Reza Ariyan";
        public string Body { get; init; } = "Hello World.";
    }

    public class DummySubscriber : Subscriber<Message>
    {
        public DummySubscriber(ILocalEventBus bus) : base(bus)
        {
        }

        public override void Handle(Message message)
        {
        }
    }
}