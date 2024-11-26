namespace laba6.Tests;

using Xunit;

public class DecoratorTests
{
    [Fact]
    public void Decorator_ShouldAddExclamation()
    {
        // Arrange
        IMessage message = new BasicMessage();
        message = new ExclamationDecorator(message);

        // Act
        var result = message.GetMessage();

        // Assert
        Assert.Equal("Hello, World!!!", result);
    }

    [Fact]
    public void Decorator_ShouldReturnOriginalMessage()
    {
        // Arrange
        IMessage message = new BasicMessage();

        // Act
        var result = message.GetMessage();

        // Assert
        Assert.Equal("Hello, World!", result);
    }
}