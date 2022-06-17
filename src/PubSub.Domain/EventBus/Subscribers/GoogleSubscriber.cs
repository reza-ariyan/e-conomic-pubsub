using PubSub.Core.EventBus.Local;
using PubSub.Core.EventBus.Local.Contracts;
using PubSub.Domain.EventBus.Contracts;
using PubSub.Domain.EventBus.Models;

namespace PubSub.Domain.EventBus.Subscribers;

public class GoogleSubscriber : Subscriber<Google>, IGoogleSubscriber
{
    public GoogleSubscriber(ILocalEventBus eve) : base(eve)
    {
    }

    protected override void Notify(Google message)
    {
        Console.WriteLine($"{message.Symbol,-5}-->{message.Name,7} new price is {message.Price}");
    }
}