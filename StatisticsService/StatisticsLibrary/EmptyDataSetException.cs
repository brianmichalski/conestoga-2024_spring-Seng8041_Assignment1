using System;

public class EmptyDataSetException: Exception
{ 
    public EmptyDataSetException()
    {
    }

    public EmptyDataSetException(string message)
        : base(message)
    {
    }

    public EmptyDataSetException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
