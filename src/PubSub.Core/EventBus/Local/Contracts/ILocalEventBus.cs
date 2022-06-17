namespace PubSub.Core.EventBus.Local.Contracts;

/// <summary>
/// Local Event Bus that can be used to publish and subscribe locally
/// </summary>
public interface ILocalEventBus
{
    /// <summary>
    /// Publishes a message, so that all subscribers can receive that message 
    /// </summary>
    /// <param name="message">Message to publish</param>
    /// <typeparam name="TMessage">Message object type that is going to be published</typeparam>
    void Publish<TMessage>(TMessage message);

    /// <summary>
    /// Subscribes to a message
    /// </summary>
    /// <param name="action">Action that should be run when a message arises</param>
    /// <typeparam name="TMessage">Message object type</typeparam>
    /// <returns>when <see cref="Subscription{TMessage}"/> object, when <typeparam name="TMessage"/> is subscribed it returns the <see cref="Subscription{TMessage}"/> instance.</returns>
    Subscription<TMessage> Subscribe<TMessage>(Action<TMessage> action);

    /// <summary>
    /// Unsubscribe from a message
    /// </summary>
    /// <param name="subscription"><see cref="Subscription{TMessage}"/> object that should be unsubscribed</param>
    /// <typeparam name="TMessage">Message type that need to be unsubscribed</typeparam>
    void Unsubscribe<TMessage>(Subscription<TMessage> subscription);
}