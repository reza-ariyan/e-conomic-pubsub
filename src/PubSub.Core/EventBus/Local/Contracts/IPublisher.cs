namespace PubSub.Core.EventBus.Local.Contracts;

/// <summary>
/// Publisher that can publish messages
/// </summary>
public interface IPublisher
{
    ///<inheritdoc cref="ILocalEventBus.Publish{TMessage}"/>
    void Publish<TMessage>(TMessage message);
}