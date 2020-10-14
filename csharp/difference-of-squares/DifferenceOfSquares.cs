using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) => (int) Math.Pow(Enumerable.Range(1, max).Sum(), 2);

    public static int CalculateSumOfSquares(int max) => (int) Enumerable.Range(1, max).Sum(x => Math.Pow(x, 2));

    public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
}