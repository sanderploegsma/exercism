using System;
using System.Linq;

public static class ResistorColor
{
    private static readonly string[] _colors = new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static int ColorCode(string color) => _colors.ToList().FindIndex(c => c == color);

    public static string[] Colors() => _colors;
}