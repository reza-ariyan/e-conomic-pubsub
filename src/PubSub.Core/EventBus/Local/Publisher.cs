using PubSub.Core.EventBus.Local.Contracts;

namespace PubSub.Core.EventBus.Local;

///<inheritdoc/>
public class Publisher : IPublisher
{
    private readonly ILocalEventBus _localEventBus;

    /// <summary>
    /// Create a new instance of publisher by injecting a LocalEventBus
    /// </summary>
    /// <param name="localEventBus">A local event bus (an implementation of<see cref="ILocalEventBus"/>)</param>
    public Publisher(ILocalEventBus localEventBus)
    {
        _localEventBus = localEventBus;
    }

    ///<inheritdoc/>
    public void Publish<TMessage>(TMessage message)
    {
        _localEventBus.Publish(message);
    }
}