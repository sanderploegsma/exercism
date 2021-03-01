using System.Linq;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var result = "";
        var count = 1;

        for (var i = 0; i < input.Length; i++)
        {
            if (i + 1 < input.Length && input[i] == input[i + 1])
            {
                count++;
                continue;
            }

            result += count > 1 ? count.ToString() : "";
            result += input[i];
            count = 1;
        }
        
        return result;
    }

    public static string Decode(string input)
    {
        var result = "";
        
        while (input.Any())
        {
            var digits = input.TakeWhile(char.IsDigit).ToArray();
            var count = digits.Any() ? int.Parse(string.Concat(digits)) : 1;
            var token = input.Skip(digits.Length).First();

            result += string.Concat(Enumerable.Repeat(token, count));
            input = input.Substring(digits.Length + 1);
        }

        return result;
    }
}
