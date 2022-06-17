using System.Collections;
using System.Collections.Concurrent;

namespace PubSub.Core.EventBus.Local;

public class LocalEventBus
{
    private readonly ConcurrentDictionary<Type, IList> _subscriber = new();

    public void Publish<TMessage>(TMessage message)
    {
        var type = typeof(TMessage);
        if (!_subscriber.ContainsKey(type)) return;
        var subscriptions =
            new List<Subscription<TMessage>>(_subscriber[type].Cast<Subscription<TMessage>>());
        foreach (var subscription in subscriptions)
        {
            subscription.Action(message);
        }
    }

    public Subscription<TMessage> Subscribe<TMessage>(Action<TMessage> action)
    {
        var subscription = new Subscription<TMessage>(action, this);
        var type = typeof(TMessage);
        if (!_subscriber.TryGetValue(type, out var actions))
        {
            actions = new List<Subscription<TMessage>>
            {
                subscription
            };
            _subscriber.TryAdd(type, actions);
        }
        else
        {
            actions.Add(subscription);
        }

        return subscription;
    }

    public void Unsubscribe<TMessage>(Subscription<TMessage> subscription)
    {
        var type = typeof(TMessage);
        // removes the subscriber if it exists
        _subscriber[type]?.Remove(subscription);
    }
}