using System;

public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    private int _readHead;
    private int _writeHead;
    private int _itemCount;

    public CircularBuffer(int capacity)
    {
        _buffer = new T[capacity];
    }

    public T Read()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Buffer is empty");
        }

        var item = _buffer[_readHead];
        if (_itemCount-- > 0)
        {
            AdvanceRead();
        }

        return item;
    }

    public void Write(T value)
    {
        if (IsFull)
        {
            throw new InvalidOperationException("Buffer is full");
        }

        _buffer[_writeHead] = value;
        _itemCount++;
        AdvanceWrite();
    }

    public void Overwrite(T value)
    {
        if (!IsFull) {
            Write(value);
        } else {
            _buffer[_readHead] = value;
            AdvanceRead();
        }
    }

    public void Clear()
    {
        _readHead = 0;
        _writeHead = 0;
        _itemCount = 0;
    }

    private bool IsEmpty => _itemCount == 0;
    private bool IsFull => _itemCount == _buffer.Length;

    private void AdvanceRead()
    {
        _readHead = Next(_readHead);
    }

    private void AdvanceWrite()
    {
        _writeHead = Next(_writeHead);
    }
    
    private int Next(int position) => (position + 1) % _buffer.Length;
}