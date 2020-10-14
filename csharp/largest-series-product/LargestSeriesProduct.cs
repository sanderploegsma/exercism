using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (span < 0 || span > digits.Length)
        {
            throw new ArgumentException("Span must be between 1 and number of input digits");
        }

        if (!digits.All(char.IsDigit))
        {
            throw new ArgumentException("Digits contain invalid characters");
        }

        if (digits.Length < 1)
        {
            return 1;
        }

        return Enumerable
            .Range(0, digits.Length - span + 1)
            .Select(idx => digits.Substring(idx, span))
            .Max(SeriesProduct);
    }

    private static long SeriesProduct(string series) => series
        .Select(char.GetNumericValue)
        .Select(Convert.ToInt64)
        .Aggregate(1L, (a, b) => a * b);
}