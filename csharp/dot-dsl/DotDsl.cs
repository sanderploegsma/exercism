using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Node : IEnumerable
{
    private readonly IDictionary<string, string> _attrs;

    public Node(string id)
    {
        Id = id;
        _attrs = new Dictionary<string, string>();
    }

    public string Id { get; }

    public void Add(string key, string value) => _attrs[key] = value;

    public IEnumerator GetEnumerator() => _attrs.GetEnumerator();

    public override bool Equals(object obj)
    {
        if (obj is Node other)
        {
            return Id == other.Id &&
                   _attrs.ContentsEqual(other._attrs);
        }

        return false;
    }

    public override int GetHashCode() => (Id, _attrs.ContentsHashCode()).GetHashCode();
}

public class Edge : IEnumerable
{
    private readonly IDictionary<string, string> _attrs;

    public Edge(string from, string to)
    {
        From = from;
        To = to;
        _attrs = new Dictionary<string, string>();
    }

    public string From { get; }

    public string To { get; }

    public void Add(string key, string value) => _attrs[key] = value;

    public IEnumerator GetEnumerator() => _attrs.GetEnumerator();

    public override bool Equals(object obj)
    {
        if (obj is Edge other)
        {
            return From == other.From &&
                   To == other.To &&
                   _attrs.ContentsEqual(other._attrs);
        }

        return false;
    }

    public override int GetHashCode() => (From, To, _attrs.ContentsHashCode()).GetHashCode();
}

public class Attr
{
    public Attr(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; }
    public string Value { get; }

    public override bool Equals(object obj)
    {
        if (obj is Attr other)
        {
            return Key == other.Key &&
                   Value == other.Value;
        }

        return false;
    }

    public override int GetHashCode() => (Key, Value).GetHashCode();
}

public class Graph : IEnumerable
{
    private readonly List<Node> _nodes;
    private readonly List<Edge> _edges;
    private readonly List<Attr> _attrs;

    public Graph()
    {
        _nodes = new List<Node>();
        _edges = new List<Edge>();
        _attrs = new List<Attr>();
    }

    public IEnumerable<Node> Nodes => _nodes.OrderBy(n => n.Id).ToArray();
    public IEnumerable<Edge> Edges => _edges.OrderBy(n => n.From).ToArray();
    public IEnumerable<Attr> Attrs => _attrs.OrderBy(n => n.Key).ToArray();

    public void Add(Node node) => _nodes.Add(node);

    public void Add(Edge edge) => _edges.Add(edge);

    public void Add(string key, string value) => _attrs.Add(new Attr(key, value));

    public IEnumerator GetEnumerator() => throw new System.NotImplementedException();
}

internal static class DictionaryExtensions
{
    public static bool ContentsEqual<K, V>(this IDictionary<K, V> dict1, IDictionary<K, V> dict2) =>
        dict1.Count == dict2.Count && !dict1.Except(dict2).Any();

    public static int ContentsHashCode<K, V>(this IDictionary<K, V> dict)
    {
        unchecked // Allow arithmetic overflow, numbers will just "wrap around"
        {
            int hashcode = 1430287;
            foreach (var kv in dict)
            {
                hashcode = hashcode * 7302013 ^ kv.GetHashCode();
            }

            return hashcode;
        }
    }
}