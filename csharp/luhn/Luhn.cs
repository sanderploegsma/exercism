using System.Collections.Generic;
using System.Linq;

public static class Luhn
{
    public static bool IsValid(string number) => 
        ValidateNumber(number, out var digits) && HasValidChecksum(digits);

    private static bool ValidateNumber(string number, out IEnumerable<int> digits)
    {
        var withoutSpaces = number.Replace(" ", "");

        if (!withoutSpaces.All(char.IsDigit))
        {
            digits = Enumerable.Empty<int>();
            return false;
        }

        if (withoutSpaces.Length < 2)
        {
            digits = Enumerable.Empty<int>();
            return false;
        }
        
        digits = withoutSpaces.Select(c => (int)char.GetNumericValue(c));
        return true;
    }

    private static bool HasValidChecksum(IEnumerable<int> digits)
    {
        var checksum = Checksum(digits);
        return checksum % 10 == 0;
    }
    
    private static int Checksum(IEnumerable<int> digits)
    {
        return digits
            .Reverse()
            .Select((digit, index) => index % 2 == 1 ? Double(digit) : digit)
            .Sum();

        static int Double(int n)
        {
            var x = n * 2;
            return x > 9 ? x - 9 : x;
        }
    }
}