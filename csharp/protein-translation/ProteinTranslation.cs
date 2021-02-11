using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private const string Methionine = "Methionine";
    private const string Phenylalanine = "Phenylalanine";
    private const string Leucine = "Leucine";
    private const string Serine = "Serine";
    private const string Tyrosine = "Tyrosine";
    private const string Cysteine = "Cysteine";
    private const string Tryptophan = "Tryptophan";
    private const string Stop = "STOP";

    public static string[] Proteins(string strand) =>
        strand
            .Chunked(3)
            .Select(Translate)
            .TakeWhile(protein => protein != Stop)
            .ToArray();

    private static string Translate(string codon) => codon switch
    {
        "AUG" => Methionine,
        "UUU" => Phenylalanine,
        "UUC" => Phenylalanine,
        "UUA" => Leucine,
        "UUG" => Leucine,
        "UCU" => Serine, 
        "UCC" => Serine, 
        "UCA" => Serine, 
        "UCG" => Serine, 
        "UAU" => Tyrosine,
        "UAC" => Tyrosine,
        "UGU" => Cysteine,
        "UGC" => Cysteine,
        "UGG" => Tryptophan,
        "UAA" => Stop,
        "UAG" => Stop,
        "UGA" => Stop,
        _ => throw new ArgumentException($"Unknown codon {codon}", nameof(codon))
    };
}

internal static class StringExtensions
{
    public static IEnumerable<string> Chunked(this string str, int chunkSize) =>
        Enumerable
            .Range(0, str.Length / chunkSize)
            .Select(i => i * chunkSize)
            .Select(i => str.Substring(i, chunkSize));
}