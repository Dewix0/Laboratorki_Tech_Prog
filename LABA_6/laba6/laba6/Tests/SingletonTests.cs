namespace laba6.Tests;

using Xunit;

public class SingletonTests
{
    [Fact]
    public void Singleton_ShouldReturnSameInstance()
    {
        // Arrange
        var instance1 = Singleton.Instance;
        var instance2 = Singleton.Instance;

        // Assert
        Assert.Same(instance1, instance2); // Проверка, что экземпляры одинаковы
    }

    [Fact]
    public void Singleton_ShouldReturnCorrectMessage()
    {
        // Arrange
        var instance = Singleton.Instance;

        // Act
        var message = instance.GetMessage();

        // Assert
        Assert.Equal("Singleton instance", message);
    }
}