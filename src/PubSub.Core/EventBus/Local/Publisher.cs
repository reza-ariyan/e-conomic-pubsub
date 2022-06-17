namespace PubSub.Core.EventBus.Local;

public class Publisher
{
    private readonly LocalEventBus _localEventBus;

    public Publisher(LocalEventBus localEventBus)
    {
        _localEventBus = localEventBus;
    }

    public void Publish<TMessage>(TMessage message)
    {
        _localEventBus.Publish(message);
    }
}