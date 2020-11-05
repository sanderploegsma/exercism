using System;
using System.Collections.Generic;
using System.Linq;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1.Count == list2.Count && list1.SequenceEqual(list2))
            return SublistType.Equal;

        if (list1.Count < list2.Count && list2.Contains(list1))
            return SublistType.Sublist;
        
        if (list1.Count > list2.Count && list1.Contains(list2))
            return SublistType.Superlist;

        return SublistType.Unequal;
    }
}

internal static class Extensions
{
    /// <summary>
    /// Contains checks whether this list `a` contains all elements of list `b`, in order.
    /// </summary>
    public static bool Contains<T>(this List<T> a, List<T> b) where T : IComparable
        => Enumerable
            .Range(0, a.Count - b.Count + 1)
            .Any(x => a.Skip(x).Take(b.Count).SequenceEqual(b));
}