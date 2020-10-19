using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _baseWord;

    public Anagram(string baseWord) => _baseWord = baseWord;

    public string[] FindAnagrams(string[] potentialMatches) => 
        potentialMatches
            .Where(word => word.ToLowerInvariant() != _baseWord.ToLowerInvariant())
            .Where(word => GetCharacterCount(word).Matches(GetCharacterCount(_baseWord)))
            .ToArray();

    private static IDictionary<char, int> GetCharacterCount(string word) =>
        word.ToLowerInvariant()
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());
}

internal static class Extensions
{
    public static bool Matches<K, V>(this IDictionary<K, V> a, IDictionary<K, V> b) => 
        a.Intersect(b).Count() == a.Union(b).Count();
}