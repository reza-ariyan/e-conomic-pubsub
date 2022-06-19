using Moq;
using PubSub.Core.EventBus.Local;
using PubSub.Core.EventBus.Local.Contracts;

namespace PubSub.Core.Tests;

public class SubscriberTests
{
    private readonly ILocalEventBus _localEventBus;

    //Setup
    public SubscriberTests()
    {
        var localEventBusMock = new Mock<LocalEventBus> {CallBase = true};
        _localEventBus = localEventBusMock.Object;
    }

    [Fact]
    public void DummySubscriber_Should_Subscribe_To_A_Message()
    {
        // Arrange
        var dummy = new Dummy.Message();
        var subscriberGotTheMessage = false;
        Mock<Subscriber<Dummy.Message>> subscriberMock = new(_localEventBus) {CallBase = true};
        subscriberMock.Setup(r => r.Handle(It.IsAny<Dummy.Message>()))
            .Callback<Dummy.Message>(_ => { subscriberGotTheMessage = true; });

        // Act
        var action = subscriberMock.Object; //this line forces moq to call constructor of the mocked subscriber 
        _localEventBus.Publish(dummy);

        // Assert
        Assert.NotNull(action);
        Assert.True(subscriberGotTheMessage);
    }


    [Fact]
    public void When_DummySubscriber_Is_Disposed_It_Should_Be_Unsubscribed()
    {
        // Arrange
        var dummy = new Dummy.Message();
        var subscriberGotTheMessage = false;
        Mock<Subscriber<Dummy.Message>> subscriberMock = new(_localEventBus) {CallBase = true};
        subscriberMock.Setup(r => r.Handle(It.IsAny<Dummy.Message>()))
            .Callback<Dummy.Message>(_ => { subscriberGotTheMessage = true; });

        // Act
        using (subscriberMock.Object)
        {
        }

        _localEventBus.Publish(dummy);

        // Assert
        Assert.False(subscriberGotTheMessage);
    }
}