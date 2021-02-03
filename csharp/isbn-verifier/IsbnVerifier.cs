using System.Linq;
using System.Text.RegularExpressions;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var digits = number.Replace("-", "");
        return IsValidFormat(digits) && IsValidChecksum(digits);
    }

    private static bool IsValidFormat(string digits) =>
        Regex.IsMatch(digits, @"^\d{9}[\dX]$");

    private static bool IsValidChecksum(string digits)
    {
        static int DigitValue(char digit) => digit == 'X' ? 10 : (int)char.GetNumericValue(digit);

        var sum = digits
            .Select(DigitValue)
            .Reverse()
            .Select((n, i) => n * (i + 1))
            .Sum();

        return sum % 11 == 0;
    }
}