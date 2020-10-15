using System;
using System.Collections.Generic;
using System.Linq;

public static class PrimeFactors
{
    public static long[] Factors(long number) => CalculateFactors(number).ToArray();

    private static IEnumerable<long> CalculateFactors(long number)
    {
        var divisor = 2;
        var left = number;

        while (left > 1)
        {
            if (left % divisor == 0)
            {
                left /= divisor;
                yield return divisor;
            }
            else
            {
                divisor++;
            }
        }
    }
}