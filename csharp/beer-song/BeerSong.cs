using System.Collections.Generic;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown) =>
        string.Join("\n\n", Verses(startBottles, takeDown)).Trim();

    private static IEnumerable<string> Verses(int startBottles, int takeDown)
    {
        for (var i = startBottles; i > startBottles - takeDown; i--)
        {
            var firstPartOfSecondLine = i switch
            {
                0 => "Go to the store and buy some more",
                1 => "Take it down and pass it around",
                _ => "Take one down and pass it around"
            };

            yield return $"{NumberOfBottles(i)} of beer on the wall, {NumberOfBottles(i).ToLower()} of beer.\n" +
                $"{firstPartOfSecondLine}, {NumberOfBottles(i - 1).ToLower()} of beer on the wall.";
        }
    }

    private static string NumberOfBottles(int numberOfBottles) => numberOfBottles switch
    {
        -1 => "99 bottles",
        0 => "No more bottles",
        1 => "1 bottle",
        _ => $"{numberOfBottles} bottles"
    };
}