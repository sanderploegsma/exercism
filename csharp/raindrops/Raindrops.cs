using System.Collections.Generic;
using System.Linq;

public static class Raindrops
{
    private static readonly Dictionary<int, string> Sounds = new Dictionary<int, string>
    {
        {3, "Pling"},
        {5, "Plang"},
        {7, "Plong"},
    };

    public static string Convert(int number)
    {
        var sounds =
            from x in Sounds
            where number % x.Key == 0
            orderby x.Key
            select x.Value;

        return string.Concat(sounds.DefaultIfEmpty(number.ToString()));
    }
}