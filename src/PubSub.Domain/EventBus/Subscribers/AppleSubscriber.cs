using PubSub.Core.EventBus.Local;
using PubSub.Core.EventBus.Local.Contracts;
using PubSub.Domain.EventBus.Contracts;
using PubSub.Domain.EventBus.Models;

namespace PubSub.Domain.EventBus.Subscribers;

public class AppleSubscriber : Subscriber<Apple>, IAppleSubscriber
{
    public AppleSubscriber(ILocalEventBus bus) : base(bus)
    {
    }

    public override void Notify(Apple message)
    {
        Console.WriteLine($"{message.Symbol,-5}-->{message.Name,7} new price is {message.Price}");
    }
}