using System;
using System.Linq;

public static class ResistorColorDuo
{
    public static int Value(string[] colors)
    {
        var digits = colors.Take(2).Select(Value).Select(x => x.ToString());
        return int.Parse(string.Concat(digits));
    }

    private static int Value(string color) => color switch
    {
        "black" => 0,
        "brown" => 1,
        "red" => 2,
        "orange" => 3,
        "yellow" => 4,
        "green" => 5,
        "blue" => 6,
        "violet" => 7,
        "grey" => 8,
        "white" => 9,
        _ => throw new ArgumentException($"Unknown color {color}", nameof(color))
    };
}
