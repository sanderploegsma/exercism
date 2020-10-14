using System;
using System.Linq;

public class SimpleCipher
{
    private enum Direction : int { 
        Left = -1, 
        Right = 1
    };

    const string alphabet = "abcdefghijklmnopqrstuvwxyz";

    private readonly string _key;

    public SimpleCipher() => _key = GenerateRandomKey();

    public SimpleCipher(string key) => _key = key;
    
    public string Key => _key;

    public string Encode(string plaintext) => Substitute(plaintext, Direction.Right);

    public string Decode(string ciphertext) => Substitute(ciphertext, Direction.Left);

    private string Substitute(string input, Direction direction) =>
        new string(input.Select((c, i) => SubstituteChar(c, i, direction)).ToArray());

    private char SubstituteChar(char c, int pos, Direction direction) {
        var offset = alphabet.IndexOf(_key[pos % _key.Length]) * (int) direction;

        // Add alphabet.Length to fix wrapping when going 'back'.
        // This is needed because in C# -1 mod 26 = -1, while mathematically it should be 25.
        return alphabet[(alphabet.IndexOf(c) + offset + alphabet.Length) % alphabet.Length];
    }

    private static string GenerateRandomKey() {
        const int keySize = 100;

        var rnd = new Random();
        var chars = from i in Enumerable.Repeat(alphabet.Length - 1, keySize)
                    select alphabet[rnd.Next(i)];

        return new string(chars.ToArray());
    }
}