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

        if (list1.Count < list2.Count && list1.IsSubSetOf(list2))
            return SublistType.Sublist;
        
        if (list1.Count > list2.Count && list2.IsSubSetOf(list1))
            return SublistType.Superlist;

        return SublistType.Unequal;
    }
}

internal static class Extensions
{
    public static bool IsSubSetOf<T>(this List<T> a, List<T> b) where T : IComparable
        => Enumerable
            .Range(0, b.Count - a.Count + 1)
            .Any(x => b.Skip(x).Take(a.Count).SequenceEqual(a));
}