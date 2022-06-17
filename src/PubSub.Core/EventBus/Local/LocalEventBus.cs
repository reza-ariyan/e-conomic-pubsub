using System.Collections;
using System.Collections.Concurrent;
using PubSub.Core.EventBus.Local.Contracts;

namespace PubSub.Core.EventBus.Local;

///<inheritdoc/>
public class LocalEventBus : ILocalEventBus
{
    private readonly ConcurrentDictionary<Type, IList> _subscribers = new();

    /// <inheritdoc />
    /// <remarks>The identifier for topics is <typeparam name="TMessage"/></remarks>
    public void Publish<TMessage>(TMessage message)
    {
        var type = typeof(TMessage);
        if (!_subscribers.ContainsKey(type)) return;
        var subscriptions =
            new List<Subscription<TMessage>>(_subscribers[type].Cast<Subscription<TMessage>>());
        foreach (var subscription in subscriptions)
        {
            subscription.Action(message);
        }
    }

    /// <inheritdoc />
    /// <remarks><see cref="Action{TMessage}"/> can be also a lambda expression</remarks>
    /// <example>(message)=>{ /* do something here ... */ } whereas message is the callback value and of type <typeparam name="TMessage"/></example>
    public Subscription<TMessage> Subscribe<TMessage>(Action<TMessage> action)
    {
        var subscription = new Subscription<TMessage>(action, this);
        var type = typeof(TMessage);
        if (!_subscribers.TryGetValue(type, out var actions))
        {
            actions = new List<Subscription<TMessage>>
            {
                subscription
            };
            _subscribers.TryAdd(type, actions);
        }
        else
        {
            actions.Add(subscription);
        }

        return subscription;
    }

    /// <inheritdoc />
    public void Unsubscribe<TMessage>(Subscription<TMessage> subscription)
    {
        var type = typeof(TMessage);
        // removes the subscriber if it exists
        _subscribers[type]?.Remove(subscription);
    }
}