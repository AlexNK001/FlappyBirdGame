using System;

public class EventElement<T>
{
    public event Action<T> Invoked;

    public void Raise(T value)
    {
        Invoked?.Invoke(value);
    }
}

public class EventElement
{
    public event Action Invoked;

    public void Raise()
    {
        Invoked?.Invoke();
    }
}