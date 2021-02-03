using System.Collections.Generic;
using System.Linq;

public class CustomSet
{
    private readonly IEnumerable<int> _values;

    public CustomSet(params int[] values) => _values = values;
    
    public bool Empty() => !_values.Any();

    public bool Contains(int value) => _values.Contains(value);

    public bool Subset(CustomSet right) => _values.All(right.Contains);

    public bool Disjoint(CustomSet right) => Intersection(right).Empty();
    
    public CustomSet Add(int value)
    {
        var values = _values.Where(n => n != value).Append(value);
        return new CustomSet(values.ToArray());
    }

    public CustomSet Intersection(CustomSet right)
    {
        var values = _values.Where(right.Contains);
        return new CustomSet(values.ToArray());
    }

    public CustomSet Difference(CustomSet right)
    {
        var values = _values.Except(_values.Where(right.Contains));
        return new CustomSet(values.ToArray());
    }

    public CustomSet Union(CustomSet right) =>
        _values.Aggregate(right, (set, value) => set.Add(value));

    public override bool Equals(object obj)
    {
        if (obj is CustomSet right)
        {
            return this.Subset(right) && right.Subset(this);
        }

        return false;
    }

    public override int GetHashCode() => _values.GetHashCode();
}