using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class WordCount
{
    private const string Pattern = @"\w+'\w+|\w+";

    public static IDictionary<string, int> CountWords(string phrase) =>
        Regex.Matches(phrase, Pattern)
            .Select(match => match.Value.ToLower())
            .GroupBy(word => word)
            .ToDictionary(group => group.Key, group => group.Count());
}