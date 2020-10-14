using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word) =>
        word.ToLowerInvariant().ToCharArray()
            .Where(c => Enumerable.Range('a', 26).Contains(c))
            .GroupBy(c => c)
            .Where(g => g.Count() > 1)
            .Count() == 0;
}
