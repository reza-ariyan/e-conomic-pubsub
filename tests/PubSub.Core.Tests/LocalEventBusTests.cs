using Moq;
using PubSub.Core.EventBus.Local;
using PubSub.Core.EventBus.Local.Contracts;

namespace PubSub.Core.Tests;

public class LocalEventBusTests
{
    private readonly ILocalEventBus _localEventBus;

    //Setup
    public LocalEventBusTests()
    {
        var localEventBusMock = new Mock<LocalEventBus> {CallBase = true};
        _localEventBus = localEventBusMock.Object;
    }

    [Fact]
    public void Subscribe_Should_Return_Subscription_Object_When_Subscribing_To_Something()
    {
        // Arrange
        Action<Dummy.Message> action = _ => { };

        // Act
        var actual = _localEventBus.Subscribe(action);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(action, actual.Action);
    }

    [Fact]
    public void Subscribe_Should_Subscribe_To_A_Message_When_It_Is_Called()
    {
        // Arrange
        const string messageFrom = "Reza Ariyan";
        const string messageBody = "Hello World !";
        var dummy = new Dummy.Message {From = messageFrom, Body = messageBody};
        Dummy.Message? actual = null;
        Action<Dummy.Message> action = data => { actual = data; };

        // Act
        _localEventBus.Subscribe(action);
        _localEventBus.Publish(dummy);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(messageFrom, actual?.From);
        Assert.Equal(messageBody, actual?.Body);
    }

    [Fact]
    public void Publish_Should_Arise_A_Message_To_Multiple_Subscribers_When_It_Is_Called()
    {
        // Arrange
        var dummy = new Dummy.Message();
        var firstActionIsCalled = false;
        var secondActionIsCalled = false;
        Action<Dummy.Message> firstAction = _ => { firstActionIsCalled = true; };
        Action<Dummy.Message> secondAction = _ => { secondActionIsCalled = true; };

        // Act
        _localEventBus.Subscribe(firstAction);
        _localEventBus.Subscribe(secondAction);
        _localEventBus.Publish(dummy);

        // Assert
        Assert.True(firstActionIsCalled);
        Assert.True(secondActionIsCalled);
    }


    [Fact]
    public void Unsubscribe_Should_Remove_Subscription_When_Unsubscribing_A_Subscriber()
    {
        // Arrange
        var dummy = new Dummy.Message();
        var actionIsCalled = false;
        Action<Dummy.Message> action = _ => { actionIsCalled = true; };

        // Act
        var subscription = _localEventBus.Subscribe(action);
        _localEventBus.Unsubscribe(subscription);
        _localEventBus.Publish(dummy);

        // Assert
        Assert.False(actionIsCalled);
    }
}