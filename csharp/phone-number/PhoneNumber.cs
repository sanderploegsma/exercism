using System;
using System.Linq;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var digits = new string(phoneNumber.Where("0123456789".Contains).ToArray());
        if (digits.Length == 11 && digits.StartsWith('1'))
        {
            digits = digits.Substring(1);
        }

        if (digits.Length != 10)
        {
            throw new ArgumentException("Not a valid phone number: invalid length");
        }

        if (char.GetNumericValue(digits[0]) < 2)
        {
            throw new ArgumentException("Not a valid phone number: area code should start with a digit between 2 and 9");
        }

        if (char.GetNumericValue(digits[3]) < 2)
        {
            throw new ArgumentException("Not a valid phone number: exchange code should start with a digit between 2 and 9");
        }

        return digits;
    }
}