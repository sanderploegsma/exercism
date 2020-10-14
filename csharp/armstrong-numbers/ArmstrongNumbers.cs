using System;
using System.Collections.Generic;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var digits = GetDigits(number);
        return digits.Reverse<int>().Select(digit => Math.Pow(digit, digits.Count)).Sum() == number;
    }

    private static List<int> GetDigits(int number) =>
        number.ToString().ToCharArray().Select(Char.ToString).Select(int.Parse).ToList();
}