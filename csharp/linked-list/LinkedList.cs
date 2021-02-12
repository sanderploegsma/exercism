public class Deque<T>
{
    private Node _firstNode;
    private Node _lastNode;

    public void Push(T value)
    {
        var oldLastNode = _lastNode;

        _lastNode = new Node(value) {Previous = oldLastNode};

        if (oldLastNode != null)
        {
            oldLastNode.Next = _lastNode;
        }

        _firstNode ??= _lastNode;
    }

    public T Pop()
    {
        var value = _lastNode.Value;
        _lastNode = _lastNode.Previous;
        return value;
    }

    public void Unshift(T value)
    {
        var oldFirstNode = _firstNode;

        _firstNode = new Node(value) {Next = oldFirstNode};

        if (oldFirstNode != null)
        {
            oldFirstNode.Previous = _firstNode;
        }

        _lastNode ??= _firstNode;
    }

    public T Shift()
    {
        var value = _firstNode.Value;
        _firstNode = _firstNode.Next;
        return value;
    }

    private class Node
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }
    }
}