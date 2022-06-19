using PubSub.Core.EventBus.Local.Contracts;

namespace PubSub.Core.EventBus.Local;

/// <summary>
/// The subscriber that subscribed to a message of type <typeparam name="TMessage"/>,
/// receives and processes the messages published to a topic.
/// </summary>
/// <typeparam name="TMessage">The message type <remarks>Message type is used as topics</remarks></typeparam>
public abstract class Subscriber<TMessage> : IDisposable
{
    private readonly Subscription<TMessage> _subscription;

    /// <summary>
    /// Create a new instance of subscriber by injecting a LocalEventBus
    /// </summary>
    /// <param name="localEventBus"><inheritdoc cref="ILocalEventBus"/></param>
    protected Subscriber(ILocalEventBus localEventBus)
    {
        _subscription = localEventBus.Subscribe<TMessage>(Handle);
    }

    /// <summary>
    /// Each subscriber should implement <see cref="Handle"/> to get notified about any arose messages 
    /// </summary>
    /// <remarks>When you publish a message through a publisher, all subscribers will get notified and their <see cref="Handle"/> action will be called</remarks>
    /// <param name="message"><typeparam name="TMessage"/> is the type of the message that is arisen or published</param>
    public abstract void Handle(TMessage message);

    ///<inheritdoc/>
    void IDisposable.Dispose()
    {
        _subscription.Dispose();
    }
}