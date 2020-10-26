using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        var count = 0;
        foreach (var item in input) 
        {
            count++;
        }
        return count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        var result = new List<T>();
        foreach (var item in input) 
        {
            result = Append(new List<T> { item }, result);
        }
        return result;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        var result = new List<TOut>();
        foreach (var item in input)
        {
            result = Append(result, new List<TOut> { map.Invoke(item ) });
        }
        return result;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var item in input)
        {
            if (predicate.Invoke(item))
            {
                result = Append(result, new List<T> { item });
            }
        }
        return result;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        var result = start;
        foreach (var item in input)
        {
            result = func.Invoke(result, item);
        }
        return result;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        var result = start;
        foreach (var item in Reverse(input))
        {
            result = func.Invoke(item, result);
        }
        return result;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var result = new List<T>();
        foreach (var list in input) 
        {
            result = Append(result, list);
        }
        return result;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        var result = new List<T>();
        foreach (var item in left)
        {
            // Is this allowed? I wasn't allowed to use built-in functions, but it's not very clear which functions...
            result.Add(item);
        }

        foreach (var item in right)
        {
            result.Add(item);
        }

        return result;
    }
}