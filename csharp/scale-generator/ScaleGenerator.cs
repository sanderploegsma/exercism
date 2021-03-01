using System;
using System.Collections.Generic;
using System.Linq;

public static class ScaleGenerator
{
    private static readonly string[] ScaleSharps =
        {"A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"};

    private static readonly string[] ScaleFlats =
        {"A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab"};

    private static readonly string[] TonicsUsingFlats =
        {"F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb"};

    public static string[] Chromatic(string tonic)
    {
        var scale = TonicsUsingFlats.Contains(tonic) ? ScaleFlats : ScaleSharps;
        return scale.Concat(scale)
            .SkipWhile(note => !string.Equals(note, tonic, StringComparison.CurrentCultureIgnoreCase))
            .Take(12)
            .ToArray();
    }

    public static string[] Interval(string tonic, string pattern)
    {
        var scale = Chromatic(tonic);

        var result = new List<string>();
        var i = 0;
        foreach (var interval in pattern.Select(GetInterval))
        {
            result.Add(scale[i]);
            i = (i + interval) % scale.Length;
        }

        return result.ToArray();
    }

    private static int GetInterval(char interval) => interval switch
    {
        'A' => 3,
        'M' => 2,
        'm' => 1,
        _ => throw new ArgumentException()
    };
}