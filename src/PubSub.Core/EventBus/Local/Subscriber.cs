namespace PubSub.Core.EventBus.Local;

public abstract class Subscriber<TMessage> : IDisposable
{
    private readonly Subscription<TMessage> _subscription;
    private readonly LocalEventBus _localEventBus;

    protected Subscriber(LocalEventBus localEventBus)
    {
        _localEventBus = localEventBus;
        _subscription = localEventBus.Subscribe<TMessage>(Notify);
    }

    protected abstract void Notify(TMessage obj);

    void IDisposable.Dispose()
    {
        _localEventBus.Unsubscribe(_subscription);
        _subscription?.Dispose();
    }
}