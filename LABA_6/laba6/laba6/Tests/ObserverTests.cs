namespace laba6.Tests;

using Moq;
using Xunit;

public class ObserverTests
{
    [Fact]
    public void Observer_ShouldReceiveNotification()
    {
        // Arrange
        var subject = new Subject();
        var observer = new ConcreteObserver("Observer 1");
        subject.Attach(observer);

        // Act
        subject.Notify("New message");

        // Assert
        Assert.Equal("New message", observer.Message);
    }

    [Fact]
    public void Observer_ShouldNotReceiveNotification_WhenDetached()
    {
        // Arrange
        var subject = new Subject();
        var observer = new ConcreteObserver("Observer 1");
        subject.Attach(observer);
        subject.Detach(observer);

        // Act
        subject.Notify("New message");

        // Assert
        Assert.Null(observer.Message);
    }

    [Fact]
    public void Observer_Mock_ShouldReceiveNotification()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();
        var subject = new Subject();
        subject.Attach(mockObserver.Object);

        // Act
        subject.Notify("Mock notification");

        // Assert
        mockObserver.Verify(o => o.Update("Mock notification"), Times.Once);
    }
}