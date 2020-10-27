using System.Linq;

public static class RotationalCipher
{
    private const string alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static string Rotate(string text, int shiftKey)
    {
        return string.Join("", text.Select(c => Shift(c, shiftKey)));
    }

    private static char Shift(char original, int shiftKey)
    {
        var index = alphabet.IndexOf(char.ToLowerInvariant(original));
        if (index < 0)
        {
            return original;
        }

        var shiftedIndex = (index + alphabet.Length + shiftKey) % alphabet.Length;
        var shifted = alphabet[shiftedIndex];

        return char.IsLower(original) ? shifted : char.ToUpperInvariant(shifted);
    }
}