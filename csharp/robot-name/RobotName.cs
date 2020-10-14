using System;
using System.Collections.Generic;

public class Robot
{
    private string _name;

    public Robot() => _name = RobotNameGenerator.GenerateUniqueName();

    public string Name => _name;

    public void Reset() => _name = RobotNameGenerator.GenerateUniqueName();
}

internal static class RobotNameGenerator {
    private const string Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Numeric = "0123456789";

    private static readonly ISet<string> UsedNames = new HashSet<string>();

    public static string GenerateUniqueName()
    {
        var name = GenerateName();
        while (!UsedNames.Add(name))
        {
            name = GenerateName();
        }
        return name;
    }

    private static string GenerateName()
    {
        var rand = new Random();

        char RandomAlpha() => Alpha[rand.Next(Alpha.Length - 1)];
        char RandomNumeric() => Numeric[rand.Next(Numeric.Length - 1)];

        return string.Join("", RandomAlpha(), RandomAlpha(), RandomNumeric(), RandomNumeric(), RandomNumeric());
    }
}