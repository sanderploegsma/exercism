using System;
using System.Linq;

public class Matrix
{
    private readonly int[][] _matrix;

    public Matrix(string input)
    {
        _matrix = input.Split("\n")
            .Select(row => row.Split(" "))
            .Select(row => row.Select(int.Parse).ToArray())
            .ToArray();
    }

    public int Rows => _matrix.Length;

    public int Cols => _matrix.Length == 0 ? 0 : _matrix[0].Length;

    public int[] Row(int row)
    {
        if (row < 1 || row > Rows)
        {
            throw new ArgumentOutOfRangeException(nameof(row), row, "Row number is out of bounds");
        }
        
        return _matrix[row - 1];
    }

    public int[] Column(int col)
    {
        if (col < 1 || col > Cols)
        {
            throw new ArgumentOutOfRangeException(nameof(col), col, "Column number is out of bounds");
        }
        
        return _matrix.Select(row => row[col - 1]).ToArray();
    }
}