using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private readonly int _capacity;
    private readonly Queue<T> _queue;
    
    public CircularBuffer(int capacity)
    {
        _capacity = capacity;
        _queue = new Queue<T>();
    }

    public T Read() => _queue.Dequeue();

    public void Write(T value)
    {
        if (_queue.Count == _capacity)
        {
            throw new InvalidOperationException();
        }
        
        _queue.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (_queue.Count == _capacity)
        {
            _queue.Dequeue();
        }
        
        _queue.Enqueue(value);
    }

    public void Clear() => _queue.Clear();
}