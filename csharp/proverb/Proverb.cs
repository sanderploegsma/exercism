using System;
using System.Collections.Generic;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0)
        {
            return Array.Empty<string>();
        }

        return subjects
            .Pairwise()
            .Select(pieces => $"For want of a {pieces.Item1} the {pieces.Item2} was lost.")
            .Append($"And all for the want of a {subjects.First()}.")
            .ToArray();
    }
}

internal static class EnumerableExtensions
{
    public static IEnumerable<Tuple<T, T>> Pairwise<T>(this IEnumerable<T> items)
    {
        var i = 0;
        T previous = default;

        foreach (var item in items)
        {
            if (i > 0)
            {
                yield return new Tuple<T, T>(previous, item);
            }

            previous = item;
            i++;
        }
    }
}