using System;
using System.Collections.Generic;
using System.Linq;

public static class AffineCipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    
    public static string Encode(string plainText, int a, int b)
    {
        if (!a.IsCoprimeTo(Alphabet.Length))
            throw new ArgumentException("a and m must be coprime");
        
        var normalized = Normalize(plainText);
        var encoded = normalized.Select(c => Encode(c, a, b));
        return string.Join(" ", encoded.Chunked(5).Select(x => string.Concat(x)));
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        if (!a.IsCoprimeTo(Alphabet.Length))
            throw new ArgumentException("a and m must be coprime");

        var normalized = Normalize(cipheredText);
        var decoded = normalized.Select(c => Decode(c, a, b));
        return string.Concat(decoded);
    }

    private static char Encode(char character, int a, int b)
    {
        if (char.IsDigit(character))
            return character;
        
        // E(x) = (ax + b) mod m
        var x = Alphabet.IndexOf(character);
        var y = (a * x + b).Mod(Alphabet.Length);
        return Alphabet[y];
    }

    private static char Decode(char character, int a, int b)
    {
        if (char.IsDigit(character))
            return character;

        // D(y) = a^-1(y - b) mod m
        var y = Alphabet.IndexOf(character);
        var x = (a.ModInverse(Alphabet.Length) * (y - b)).Mod(Alphabet.Length);
        return Alphabet[x];
    }

    private static string Normalize(string plainText)
    {
        var normalized = plainText
            .ToLower()
            .Where(char.IsLetterOrDigit);

        return string.Concat(normalized);
    }
    
    private static int Gcd(this int a, int b) => 
        b == 0 ? a : b.Gcd(a % b);

    private static bool IsCoprimeTo(this int a, int b) => 
        a.Gcd(b) == 1;

    private static int Mod(this int a, int m)
    {
        var x = a % m;
        while (x < 0)
            x += m;
        return x;
    }

    private static int ModInverse(this int a, int m)
    {
        if (m == 1) return 0;
        var m0 = m;
        var (x, y) = (1, 0);
 
        while (a > 1) {
            var q = a / m;
            (a, m) = (m, a % m);
            (x, y) = (y, x - q * y);
        }
        
        return x < 0 ? x + m0 : x;
    }
    
    private static IEnumerable<IEnumerable<T>> Chunked<T>(this IEnumerable<T> items, int chunkSize)
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