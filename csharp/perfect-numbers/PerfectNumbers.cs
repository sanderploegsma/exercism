using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException($"{number} is not a natural number");
        }

        var factors = Factors(number);
        var aliquotSum = factors.Where(f => f <= number / 2).Sum();
        
        if (aliquotSum == number)
        {
            return Classification.Perfect;
        }

        return aliquotSum < number ? Classification.Deficient : Classification.Abundant;
    }

    private static IEnumerable<int> Factors(int number) => Enumerable.Range(1, number).Where(i => number % i == 0);
}
