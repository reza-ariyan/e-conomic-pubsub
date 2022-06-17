using PubSub.Core.EventBus.Local.Contracts;

namespace PubSub.Core.EventBus.Local;

/// <summary>
/// Subscription that is stored into <b>storage</b> that has an action to be called when a message is published
/// </summary>
/// <typeparam name="TMessage">The message type</typeparam>
public class Subscription<TMessage> : IDisposable
{
    public Action<TMessage> Action { get; }
    private readonly ILocalEventBus _localEventBus;

    /// <summary>
    /// Create a new instance of Subscription
    /// </summary>
    /// <param name="action">The action that should be called when a message is published</param>
    /// <param name="localEventBus"><inheritdoc cref="ILocalEventBus"/></param>
    public Subscription(Action<TMessage> action, ILocalEventBus localEventBus)
    {
        Action = action;
        _localEventBus = localEventBus;
    }

    ///<inheritdoc/>
    public void Dispose()
    {
        _localEventBus.Unsubscribe(this);
    }
}