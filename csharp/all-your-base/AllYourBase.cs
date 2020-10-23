using System;
using System.Collections.Generic;
using System.Linq;

public static class AllYourBase
{
    /// <summary>
    /// Convert the given list of digits in the given input base to the given output base.
    /// </summary>
    /// <param name="inputBase">Base of the given digits. Values below 2 are not valid.</param>
    /// <param name="inputDigits">List of digits to convert</param>
    /// <param name="outputBase">Base to convert to. Values below 2 are not valid.</param>
    /// <returns>The given list of digits, converted to the given output base</returns>
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2 || outputBase < 2)
        {
            throw new ArgumentException("Base should be at least 2");
        }

        if (inputDigits.Any(d => d < 0 || d >= inputBase))
        {
            throw new ArgumentException("Input contains invalid digits");
        }

        return FromBase(inputDigits.Truncate(), inputBase).ToBase(outputBase);
    }

    /// <summary>
    /// Remove leading zeroes from a list of digits. 
    /// If the list contains only zeroes, the result will be reduced to a single zero.
    /// </summary>
    /// <param name="digits">List of positive integers</param>
    /// <returns>List of positive integers without any leading zeroes</returns>
    private static int[] Truncate(this int[] digits)
    {
        var truncated = digits.SkipWhile(x => x == 0).ToArray();
        return truncated.Count() > 0 ? truncated : new[] { 0 };
    }

    /// <summary>
    /// Convert a list of positive digits that are in the given base to base 10.
    /// For example: given the digits [1,0,1,0,1,0] in base 2, this will return 42.
    /// </summary>
    /// <param name="digits">List of positive integers</param>
    /// <param name="b">The base of the given digits</param>
    /// <returns>The value of the digits in base 10</returns>
    private static int FromBase(int[] digits, int b) => 
        digits.Reverse().Select((n, i) => n * (int) Math.Pow(b, i)).Sum();

    /// <summary>
    /// Convert this positive value in base 10 to a list of digits in the given base.
    /// For example: given the value 42 and base 2, this will return [1,0,1,0,1,0].
    /// </summary>
    /// <param name="value">A positive integer</param>
    /// <param name="b">The base to convert the value to</param>
    /// <returns>List of positive integers that together make the value in the given base</returns>
    private static int[] ToBase(this int value, int b)
    {
        return GetDigits().ToArray();

        IEnumerable<int> GetDigits()
        {
            var n = value == 0 ? 0 : (int) Math.Floor(Math.Log(value) / Math.Log(b));
            var remaining = value;

            for (int i = n; i >= 0; i--)
            {
                var exp = (int) Math.Pow(b, i);
                yield return remaining / exp;
                remaining %= exp;
            }
        }
    }
}