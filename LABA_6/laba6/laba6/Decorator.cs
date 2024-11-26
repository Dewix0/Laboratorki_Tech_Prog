namespace laba6;

public interface IMessage
{
    string GetMessage();
}

public class BasicMessage : IMessage
{
    public string GetMessage()
    {
        return "Hello, World!";
    }
}

public class ExclamationDecorator : IMessage
{
    private readonly IMessage _message;

    public ExclamationDecorator(IMessage message)
    {
        _message = message;
    }

    public string GetMessage()
    {
        return _message.GetMessage() + "!!!";
    }
}

