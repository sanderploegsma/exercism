using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Largest(int min, int max)
    {
        var palindromes = GetPalindromes(min, max);

        if (!palindromes.Any())
            throw new ArgumentException("No palindromes in the given range");
        
        return palindromes.OrderByDescending(x => x.Item1).First();
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int min, int max)
    {
        var palindromes = GetPalindromes(min, max);

        if (!palindromes.Any())
            throw new ArgumentException("No palindromes in the given range");
        
        return palindromes.OrderBy(x => x.Item1).First();
    }

    private static IReadOnlyCollection<(int, IEnumerable<(int, int)>)> GetPalindromes(int min, int max) =>
        GetProducts(min, max)
            .GroupBy(x => x.Item1 * x.Item2)
            .Select(g => (g.Key, g.AsEnumerable()))
            .ToList();

    private static IEnumerable<(int, int)> GetProducts(int min, int max)
    {
        if (min > max)
            throw new ArgumentException("Invalid bounds");
        
        for (var x = min; x <= max; x++)
            for (var y = min; y <= max; y++)
                if (x <= y && IsPalindrome(x * y))
                    yield return (x, y);
    }

    private static bool IsPalindrome(int n)
    {
        var digits = n.ToString();
        return digits == string.Concat(digits.Reverse());
    }
}
