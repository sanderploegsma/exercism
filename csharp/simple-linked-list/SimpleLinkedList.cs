using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    public SimpleLinkedList(T value)
    {
        Value = value;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        Value = values.FirstOrDefault();
        values.Skip(1).ToList().ForEach(value => Add(value));
    }

    public T Value { get; }

    public SimpleLinkedList<T> Next { get; private set; }

    public SimpleLinkedList<T> Add(T value)
    {
        if (Next == null)
        {
            Next = new SimpleLinkedList<T>(value);
        }
        else
        {
            Next.Add(value);
        }

        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var instance = this;

        while (instance != null)
        {
            yield return instance.Value;
            instance = instance.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}