using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        if (IsQuestion(statement) && IsYelling(statement))
        {
            return "Calm down, I know what I'm doing!";
        }

        if (IsYelling(statement))
        {
            return "Whoa, chill out!";
        }

        if (IsQuestion(statement))
        {
            return "Sure.";
        }

        if (string.IsNullOrWhiteSpace(statement))
        {
            return "Fine. Be that way!";
        }

        return "Whatever.";
    }

    private static bool IsQuestion(string statement) => 
        statement.Trim().EndsWith('?');

    private static bool IsYelling(string statement) => 
        statement.ToUpper() == statement && statement.Any(char.IsLetter);
}