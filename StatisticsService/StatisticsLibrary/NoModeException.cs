using System;

public class NoModeException: Exception
{ 
    public NoModeException()
    {
    }

    public NoModeException(string message)
        : base(message)
    {
    }

    public NoModeException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
