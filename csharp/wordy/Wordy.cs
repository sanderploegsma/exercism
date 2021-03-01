using System;
using System.Text.RegularExpressions;

public static class Wordy
{
    public static int Answer(string question)
    {
        var expression = ParseExpression(question);
        return SolveExpression(expression);
    }

    private static string ParseExpression(string question)
    {
        const string pattern = @"^-?\d+(?: (?:(plus|minus|multiplied by|divided by) -?\d+))*$";
        
        var expression = question
            .Replace("What is ", "")
            .TrimEnd('?');

        if (!Regex.IsMatch(expression, pattern))
        {
            throw new ArgumentException("Invalid expression");
        }

        return expression
            .Replace("plus", "+")
            .Replace("minus", "-")
            .Replace("multiplied by", "*")
            .Replace("divided by", "/");
    }

    private static int SolveExpression(string expression)
    {
        var parts = expression.Split(" ");
        var lhs = int.Parse(parts[0]);
        
        for (int i = 1; i < parts.Length; i += 2)
        {
            var rhs = int.Parse(parts[i + 1]);
            var result = parts[i] switch
            {
                "+" => lhs + rhs,
                "-" => lhs - rhs,
                "*" => lhs * rhs,
                "/" => lhs / rhs,
                _ => throw new ArgumentException($"Invalid operator in expression {expression}")
            };

            lhs = result;
        }

        return lhs;
    }
}