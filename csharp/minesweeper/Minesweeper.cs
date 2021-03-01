using System.Collections.Generic;
using System.Linq;

public static class Minesweeper
{
    private const char Mine = '*';

    public static string[] Annotate(string[] input)
    {
        return input
            .Select((fields, row) => fields.Select((field, col) => AnnotateField(field, row, col)))
            .Select(fields => string.Concat(fields))
            .ToArray();

        char AnnotateField(char field, int row, int col)
        {
            if (field == Mine)
                return field;

            var mines = CountMinesAround(row, col);
            return mines == 0 ? ' ' : mines.ToString()[0];
        }

        int CountMinesAround(int row, int col)
        {
            var neighbours =
                from x in Neighbours((row, col))
                where x.Row >= 0 && x.Row < input.Length
                where x.Col >= 0 && x.Col < input[0].Length
                select input[x.Row][x.Col];

            return neighbours.Count(field => field == Mine);
        }
    }

    private static IEnumerable<(int Row, int Col)> Neighbours((int Row, int Col) field)
    {
        for (var row = field.Row - 1; row <= field.Row + 1; row++)
        for (var col = field.Col - 1; col <= field.Col + 1; col++)
            if ((row, col) != field)
                yield return (row, col);
    }
}