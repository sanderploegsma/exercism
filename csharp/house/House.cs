using System;
using System.Collections.Generic;
using System.Linq;

public static class House
{
    private static readonly string[] verses = new[] {
        "the house that Jack built.",
        "the malt that lay in",
        "the rat that ate",
        "the cat that killed",
        "the dog that worried",
        "the cow with the crumpled horn that tossed",
        "the maiden all forlorn that milked",
        "the man all tattered and torn that kissed",
        "the priest all shaven and shorn that married",
        "the rooster that crowed in the morn that woke",
        "the farmer sowing his corn that kept",
        "the horse and the hound and the horn that belonged to",
    };

    public static string Recite(int verseNumber) => "This is " + Compose(verseNumber - 1);

    public static string Recite(int startVerse, int endVerse) => string.Join("\n", ReciteMultiple(startVerse, endVerse));

    private static string Compose(int verseNumber)
    {
        if (verseNumber == 0)
        {
            return verses[0];
        }

        return string.Join(" ", verses[verseNumber], Compose(verseNumber - 1));
    }

    private static IEnumerable<string> ReciteMultiple(int startVerse, int endVerse)
    {
        for (int verse = startVerse; verse <= endVerse; verse++)
        {
            yield return Recite(verse);
        }
    }
}