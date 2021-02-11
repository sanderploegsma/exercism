using System.Linq;
using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var builder = new StringBuilder();
        
        for (var i = input.Length - 1; i >= 0; i--)
        {
            builder = builder.Append(input[i]);
        }

        return builder.ToString();
    }

    // This would be my preferred method, but I'm sure using a built-in Reverse() function
    // is not what this exercise is about
    public static string ReverseLinq(string input) => 
        string.Concat(input.Reverse());
}