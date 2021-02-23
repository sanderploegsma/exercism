using System.Collections.Generic;
using System.Linq;

public static class AtbashCipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    private const string ReverseAlphabet = "zyxwvutsrqponmlkjihgfedcba";

    public static string Encode(string plainValue)
    {
        var encoded = plainValue
            .Where(char.IsLetterOrDigit)
            .Select(char.ToLower)
            .Select(c => Encode(c, Alphabet, ReverseAlphabet));

        return string.Join(" ", encoded.Chunked(5).Select(cs => string.Concat(cs)));
    }

    public static string Decode(string encodedValue)
    {
        var decoded = encodedValue
            .Where(char.IsLetterOrDigit)
            .Select(c => Encode(c, ReverseAlphabet, Alphabet));

        return string.Concat(decoded);
    }

    /// <summary>
    /// Encode a character by looking up its position in `fromKey` and returning the character in that same position
    /// in `toKey`. Encoding digits returns the original digit.
    /// </summary>
    private static char Encode(char c, string fromKey, string toKey)
    {
        if (char.IsDigit(c))
        {
            return c;
        }

        var i = fromKey.IndexOf(c);
        return toKey[i];
    }
}

internal static class EnumerableExtensions
{
    /// <summary>
    /// Split the given enumerable into chunks containing at most chunkSize items.
    /// </summary>
    public static IEnumerable<IEnumerable<T>> Chunked<T>(this IEnumerable<T> items, int chunkSize)
    {
        var result = new List<T>();
        foreach (var item in items)
        {
            result.Add(item);

            if (result.Count == chunkSize)
            {
                yield return result;
                result = new List<T>();
            }
        }

        if (result.Any())
        {
            yield return result;
        }
    }
}