using System;
using System.Collections.Generic;
using System.Linq;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts) =>
        texts.AsParallel()
            .Select(CountCharacters)
            .Aggregate(new Dictionary<char, int>(), Merge);

    private static Dictionary<char, int> CountCharacters(string text) =>
        text.ToLowerInvariant()
            .Where(char.IsLetter)
            .GroupBy(c => c)
            .ToDictionary(group => group.Key, group => group.Count());

    private static Dictionary<char, int> Merge(Dictionary<char, int> a, Dictionary<char, int> b) =>
        new[] { a, b }
            .SelectMany(dict => dict)
            .ToLookup(pair => pair.Key, pair => pair.Value)
            .ToDictionary(group => group.Key, group => group.Sum());
}