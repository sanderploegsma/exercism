using System;
using System.Linq;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value) =>
        string.Join("", Enumerable.Repeat("I", value))
            .Replace("IIIII", "V")
            .Replace("IIII", "IV")
            .Replace("VV", "X")
            .Replace("VIV", "IX")
            .Replace("XXXXX", "L")
            .Replace("XXXX", "XL")
            .Replace("LL", "C")
            .Replace("LXL", "XC")
            .Replace("CCCCC", "D")
            .Replace("CCCC", "CD")
            .Replace("DD", "M")
            .Replace("DCD", "CM")
        ;
}