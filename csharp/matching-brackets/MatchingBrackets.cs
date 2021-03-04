using System.Collections.Generic;

public static class MatchingBrackets
{
    private static readonly Dictionary<char, char> ClosingToOpeningBrackets = new Dictionary<char, char>
    {
        {'}', '{'},
        {']', '['},
        {')', '('},
    };
    
    public static bool IsPaired(string input)
    {
        var openGroups = new Stack<char>();

        foreach (var c in input)
        {
            if (ClosingToOpeningBrackets.TryGetValue(c, out var opening))
            {
                if (openGroups.Count == 0 || openGroups.Peek() != opening)
                    return false;

                openGroups.Pop();
            }
            
            if (ClosingToOpeningBrackets.ContainsValue(c))
            {
                openGroups.Push(c);
            }
        }

        return openGroups.Count == 0;
    }
}
