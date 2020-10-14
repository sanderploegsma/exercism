using System;
using System.Linq;

public static class Acronym
{
    private static readonly char[] delimiters = new[] { ' ', '-' };
    private static readonly char[] markup = new[] { '_', '*' };

    public static string Abbreviate(string phrase) => phrase
            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Select(word => word.Trim(markup))
            .Select(word => word[0])
            .Select(char.ToUpper)
            .Aggregate("", (acc, cur) => acc + cur);
}