using System;
using System.Collections.Generic;
using System.Linq;

public static class CryptoSquare
{
    public static string Ciphertext(string plaintext)
    {
        var normalized = NormalizedPlaintext(plaintext);
        var segments = PlaintextSegments(normalized).ToList();
        var transposed = segments
            .Transpose()
            .Select(chars => string.Concat(chars));

        return string.Join(" ", transposed);
    }
    
    private static string NormalizedPlaintext(string plaintext)
    {
        var chars = plaintext
            .ToLower()
            .Where(char.IsLetterOrDigit);

        return string.Concat(chars);
    }

    private static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        var cols = (int) Math.Ceiling(Math.Sqrt(plaintext.Length));
        
        for (var i = 0; i < plaintext.Length; i += cols)
        {
            var segment = plaintext.Substring(i).Take(cols);
            yield return string.Concat(segment).PadRight(cols, ' ');
        }
    }
}

internal static class EnumerableExtensions
{
    // Source: https://stackoverflow.com/a/65892352/1595197
    public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> items) =>
        items.Select(g => g.Select((item, i) => (item, i)))
            .SelectMany(g => g)
            .GroupBy(ii => ii.i, si => si.item);
}