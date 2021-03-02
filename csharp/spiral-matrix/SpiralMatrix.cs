using System;

public class SpiralMatrix
{
    private readonly int _size;
    private readonly int[,] _matrix;

    private int _x;
    private int _y;
    private Direction _direction;
    
    public static int[,] GetMatrix(int size)
    {
        var matrix = new SpiralMatrix(size);
        matrix.Fill();
        return matrix._matrix;
    }

    private SpiralMatrix(int size)
    {
        _size = size;
        _matrix = new int[size, size];
        _direction = Direction.Right;
    }

    private void Fill()
    {
        var n = 1;
        while (n <= _size * _size)
        {
            _matrix[_y, _x] = n++;
            (_x, _y) = NextPosition;
            if (IsAtCorner)
                _direction = NextDirection;
        }
    }

    private bool IsAtCorner => _direction switch
    {
        Direction.Up => _y - _x == 1,
        Direction.Down => _x == _y,
        Direction.Left => _x + _y == _size - 1 && _y > _x,
        Direction.Right => _x + _y == _size - 1 && _x > _y,
        _ => throw new ArgumentOutOfRangeException()
    };

    private Direction NextDirection => _direction switch
    {
        Direction.Up => Direction.Right,
        Direction.Down => Direction.Left,
        Direction.Left => Direction.Up,
        Direction.Right => Direction.Down,
        _ => throw new ArgumentOutOfRangeException()
    };

    private (int, int) NextPosition => _direction switch
    {
        Direction.Up => (_x, _y - 1),
        Direction.Down => (_x, _y + 1),
        Direction.Left => (_x - 1, _y),
        Direction.Right => (_x + 1, _y),
        _ => throw new ArgumentOutOfRangeException()
    };
    
    private enum Direction { Up, Down, Left, Right }
}
