using System.Linq;

public static class TwelveDays
{
    private static readonly string[] Nth =
    {
        "first",
        "second",
        "third",
        "fourth",
        "fifth",
        "sixth",
        "seventh",
        "eighth",
        "ninth",
        "tenth",
        "eleventh",
        "twelfth",
    };

    private static readonly string[] Parts =
    {
        "a Partridge in a Pear Tree",
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming",
    };

    public static string Recite(int verseNumber) =>
        $"On the {Nth[verseNumber - 1]} day of Christmas my true love gave to me: {ComposeParts(verseNumber)}.";

    public static string Recite(int startVerse, int endVerse)
    {
        var verses = Enumerable
            .Range(startVerse, endVerse - startVerse + 1)
            .Select(verse => Recite(verse));
        
        return string.Join("\n", verses);
    }

    private static string ComposeParts(int n) => n switch
    {
        1 => Parts[n - 1],
        2 => $"{Parts[n - 1]}, and {ComposeParts(n - 1)}",
        _ => $"{Parts[n - 1]}, {ComposeParts(n - 1)}"
    };
}