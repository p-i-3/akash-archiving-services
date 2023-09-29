using System;
using System.Threading;

public class ThreadSafeCounter
{
    private int count = 0;
    public int goal {get;set;}
    public int Count
    {
        get { return count; }
    }

    public void Increment()
    {
        Interlocked.Increment(ref count);
    }

    public void Decrement()
    {
        Interlocked.Decrement(ref count);
    }
}