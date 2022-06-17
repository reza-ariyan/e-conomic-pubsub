namespace PubSub.Core.EventBus.Local;

//Does used by LocalEventBus to reserve subscription  
public class Subscription<TMessage> : IDisposable
{
    public Action<TMessage> Action { get; }
    private readonly LocalEventBus _localEventBus;

    public Subscription(Action<TMessage> action, LocalEventBus localEventBus)
    {
        Action = action;
        _localEventBus = localEventBus;
    }

    public void Dispose()
    {
        _localEventBus.Unsubscribe(this);
    }
}