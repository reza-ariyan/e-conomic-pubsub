using Moq;
using PubSub.Core.EventBus.Local;
using PubSub.Core.EventBus.Local.Contracts;

namespace PubSub.Core.Tests;

public class PublisherTests
{
    [Fact]
    public void Publisher_Should_Publish_A_Message_To_Provided_Local_Event_Bus_When_It_Is_Called()
    {
        // Arrange
        var dummy = new Dummy.Message();
        var publishInvoked = false;
        var localEventBusMock = new Mock<ILocalEventBus>();
        localEventBusMock
            .Setup(r => r.Publish(It.IsAny<Dummy.Message>()))
            .Callback<Dummy.Message>(_ => { publishInvoked = true; });
        Mock<Publisher> publisherMock = new(localEventBusMock.Object) {CallBase = true};
        var publisher = publisherMock.Object;

        // Act
        publisher.Publish(dummy);

        // Assert
        Assert.True(publishInvoked);
    }
}