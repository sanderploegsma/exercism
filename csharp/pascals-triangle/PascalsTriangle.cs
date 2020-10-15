using System;
using System.Collections.Generic;
using System.Linq;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows) => Enumerable.Range(1, rows).Select(CalculateRow);

    private static IEnumerable<int> CalculateRow(int row) => Enumerable.Range(0, row).Select(pos => BinomialCoefficient(row - 1, pos));

    /// <summary>
    /// Calculate the binomial coefficient for a given <code>n</code> and <code>k</code>, which is defined as: n! / (k! * (n - k)!)
    /// Found <a href="https://blog.plover.com/math/choose.html">here</a>.
    /// </summary>
    /// <param name="n">The total number of items</param>
    /// <param name="k">The size of the group</param>
    /// <returns></returns>
    private static int BinomialCoefficient(int n, int k)
    {
        if (k > n) return 0;

        var r = 1;
        
        for (var i = 1; i <= k; i++)
        {
            r *= n--;
            r /= i;
        }
        
        return r;
    }
}