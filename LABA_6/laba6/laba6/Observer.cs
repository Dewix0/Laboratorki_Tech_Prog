using System;
using System.Collections.Generic;


namespace laba6;

public interface IObserver
{
    void Update(string message);
}

public class ConcreteObserver : IObserver
{
    public string Name { get; }
    public string Message { get; private set; }

    public ConcreteObserver(string name)
    {
        Name = name;
    }

    public void Update(string message)
    {
        Message = message;
    }
}

public class Subject
{
    private readonly List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}