using System;
using System.Collections;
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
    // TODO: Not finished
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1.IsEqualTo(list2))
            return SublistType.Equal;

        if (list2.Count > list1.Count && list1.IsSubSetOf(list2))
            return SublistType.Sublist;
        
        if (list1.Count > list2.Count && list2.IsSubSetOf(list1))
            return SublistType.Superlist;

        return SublistType.Unequal;
    }
}

internal static class Extensions
{
    public static bool IsSubSetOf<T>(this List<T> list, List<T> other) where T : IComparable
    {
        // TODO - this fails when list=[1,2,3] and other=[0,1,1,2,3]
        var sub = other
            .SkipWhile(x => Comparer.Default.Compare(x, list.First()) != 0)
            .Take(list.Count)
            .ToList();

        return list.IsEqualTo(sub);
    }

    public static bool IsEqualTo<T>(this List<T> list, List<T> other) where T : IComparable => 
        list.Count == other.Count && 
        list.Zip(other).All(pair => Comparer.Default.Compare(pair.First, pair.Second) == 0);
}