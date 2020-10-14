using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) =>
        Enumerable.Range(1, max - 1)
            .Where(a => multiples.Any(b => a.IsMultipleOf(b)))
            .Sum();
}

internal static class Extensions
{
    public static bool IsMultipleOf(this int self, int other) => other switch
    {
        0 => false,
        _ => self % other == 0
    };
}