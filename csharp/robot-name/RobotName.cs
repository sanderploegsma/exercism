using System;
using System.Collections.Generic;
using System.Linq;

public class Robot
{
    public string Name { get; private set; }

    public Robot() => Name = RobotNameGenerator.GenerateUniqueName();

    public void Reset() => Name = RobotNameGenerator.GenerateUniqueName();
}

internal static class RobotNameGenerator
{
    private const string Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Numeric = "0123456789";

    private static readonly string[] Recipe = { Alpha, Alpha, Numeric, Numeric, Numeric };
    private static readonly int NumberOfUniqueNames = Recipe.Aggregate(1, (acc, seq) => acc * seq.Length);

    private static readonly ISet<string> UsedNames = new HashSet<string>();

    public static string GenerateUniqueName()
    {
        if (UsedNames.Count == NumberOfUniqueNames)
        {
            throw new Exception("Number of unique names exhausted");
        }

        string name;
        do
        {
            name = GenerateName();
        } while (!UsedNames.Add(name));

        return name;
    }

    private static string GenerateName()
    {
        var rand = new Random();
        char RandomCharacter(string sequence) => sequence[rand.Next(sequence.Length - 1)];

        return string.Join("", Recipe.Select(RandomCharacter));
    }
}