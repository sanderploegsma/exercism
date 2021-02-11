using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private readonly IDictionary<string, IEnumerable<Plant>> _garden;

    private static readonly string[] Students =
    {
        "Alice",
        "Bob",
        "Charlie",
        "David",
        "Eve",
        "Fred",
        "Ginny",
        "Harriet",
        "Ileana",
        "Joseph",
        "Kincaid",
        "Larry"
    };

    public KindergartenGarden(string diagram) => _garden = ParseDiagram(diagram);

    public IEnumerable<Plant> Plants(string student) => _garden[student];

    private static IDictionary<string, IEnumerable<Plant>> ParseDiagram(string diagram)
    {
        var rows = diagram.Split("\n");
        var dict = new Dictionary<string, IEnumerable<Plant>>();

        for (var i = 0; i < Students.Length; i++)
        {
            var cup = i * 2;
            if (cup < rows[0].Length)
            {
                dict[Students[i]] =
                    new[] {rows[0][cup], rows[0][cup + 1], rows[1][cup], rows[1][cup + 1]}.Select(ToPlant);
            }
        }

        return dict;
    }

    private static Plant ToPlant(char plant) => plant switch
    {
        'V' => Plant.Violets,
        'R' => Plant.Radishes,
        'C' => Plant.Clover,
        'G' => Plant.Grass,
        _ => throw new ArgumentException($"Unknown plant {plant}")
    };
}