using Microsoft.Extensions.DependencyInjection;
using PubSub.Core.EventBus.Local;
using PubSub.Core.EventBus.Local.Contracts;
using PubSub.Domain.EventBus.Contracts;
using PubSub.Domain.EventBus.Subscribers;

namespace PubSub.Application;

public class Ioc
{
    private readonly ServiceProvider _serviceProvider;

    public Ioc()
    {
        //setup DI simulation
        _serviceProvider = new ServiceCollection()
            .AddSingleton<ILocalEventBus, LocalEventBus>()
            .AddSingleton<IGoogleSubscriber, GoogleSubscriber>()
            .AddSingleton<IAppleSubscriber, AppleSubscriber>()
            .AddScoped<IPublisher, Publisher>()
            .BuildServiceProvider();
        _serviceProvider.GetService<ILocalEventBus>();
    }

    public T Resolve<T>() => _serviceProvider.GetService<T>();
}