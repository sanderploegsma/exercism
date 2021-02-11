using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    private const int BoardSize = 8;
    
    public static bool CanAttack(Queen white, Queen black) =>
        IsSameRow(white, black) ||
        IsSameColumn(white, black) ||
        IsSameDiagonal(white, black);

    public static Queen Create(int row, int column)
    {
        if (!IsInBounds(row))
        {
            throw new ArgumentOutOfRangeException(nameof(row), row, "Row is out of bounds");
        }
        
        if (!IsInBounds(column))
        {
            throw new ArgumentOutOfRangeException(nameof(column), column, "Column is out of bounds");
        }
        
        return new Queen(row, column);
    }

    private static bool IsInBounds(int n) => 
        n >= 0 && n < BoardSize;
    
    private static bool IsSameRow(Queen white, Queen black) => 
        white.Row == black.Row;
    
    private static bool IsSameColumn(Queen white, Queen black) => 
        white.Column == black.Column;
    
    private static bool IsSameDiagonal(Queen white, Queen black) => 
        Math.Abs(white.Row - black.Row) == Math.Abs(white.Column - black.Column);
}