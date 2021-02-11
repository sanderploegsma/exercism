using System;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string strand) =>
        string.Concat(strand.Select(ToRna));

    private static char ToRna(char nucleotide) => nucleotide switch
    {
        'G' => 'C',
        'C' => 'G',
        'T' => 'A',
        'A' => 'U',
        _ => throw new ArgumentException($"Invalid nucleotide {nucleotide}", nameof(nucleotide))
    };
}