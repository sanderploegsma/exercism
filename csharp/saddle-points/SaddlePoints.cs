using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        for (var row = 0; row < matrix.RowCount(); row++)
            for (var col = 0; col < matrix.ColumnCount(); col++)
                if (IsSaddlePoint(row, col))
                    yield return (row + 1, col + 1);

        bool IsSaddlePoint(int row, int col)
        {
            var value = matrix[row, col];
            return matrix.Row(row).All(n => n <= value) &&
                   matrix.Column(col).All(n => n >= value);
        }
    }
}

internal static class MatrixExtensions
{
    public static int RowCount<T>(this T[,] matrix) => matrix.GetLength(0);
    
    public static int ColumnCount<T>(this T[,] matrix) => matrix.GetLength(1);
    
    public static T[] Row<T>(this T[,] matrix, int row) => 
        Enumerable
            .Range(0, matrix.ColumnCount())
            .Select(col => matrix[row, col])
            .ToArray();
    
    public static T[] Column<T>(this T[,] matrix, int column) => 
        Enumerable
            .Range(0, matrix.RowCount())
            .Select(row => matrix[row, column])
            .ToArray();
}
