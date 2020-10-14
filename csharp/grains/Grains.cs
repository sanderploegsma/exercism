using System;
using System.Linq;

public static class Grains
{
    private const int Size = 64;

    public static ulong Square(int n)
    {
        if (n < 1 || n > Size) {
            throw new ArgumentOutOfRangeException($"Square should be between 1 and {Size}");
        }

        return Convert.ToUInt64(Math.Pow(2, n - 1));
    }

    public static ulong Total() => Enumerable.Range(1, Size).Select(Square).Aggregate(0UL, (a, b) => a + b);
}