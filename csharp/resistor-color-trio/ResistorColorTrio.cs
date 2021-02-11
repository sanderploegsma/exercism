using System;
using System.Linq;

public static class ResistorColorTrio
{
    public static string Label(string[] colors)
    {
        var value = colors.Take(2).Reverse().Select((color, index) => Value(color) * Pow10(index)).Sum();
        var ohms = value * Pow10(Value(colors[2]));

        return (ohms > 1000) ? $"{ohms / 1000} kiloohms" : $"{ohms} ohms";
    }

    private static int Pow10(int n) => (int)Math.Pow(10, n);
    
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
