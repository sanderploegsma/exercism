using System;
using System.Collections.Generic;
using System.Linq;

public static class Alphametics
{
    private static readonly int[] Digits = Enumerable.Range(0, 10).ToArray();

    public static IDictionary<char, int> Solve(string equation)
    {
        var (left, right) = Parse(equation);

        if (left.Any(c => c.Length > right.Length))
            throw new ArgumentException("Invalid equation");

        var leftFactors = Factors(left);
        var rightFactors = Factors(new[] {right});

        var letters = leftFactors.Keys.Union(rightFactors.Keys).ToHashSet();
        if (letters.Count > Digits.Length)
            throw new ArgumentException($"Equation may not have more than {Digits.Length} different letters");

        var nonZeroLetters = left.Append(right).Select(term => term[0]).ToHashSet();

        var solutions =
            from solution in GenerateSolutions(letters)
            where nonZeroLetters.All(c => solution[c] != 0L)
            where leftFactors.Sum(solution) == rightFactors.Sum(solution)
            select solution;

        return solutions.FirstOrDefault() ?? throw new ArgumentException("Invalid equation");
    }

    private static (string[] Left, string Right) Parse(string equation)
    {
        var leftAndRight = equation.Split(" == ");
        return (leftAndRight[0].Split(" + "), leftAndRight[1]);
    }

    private static IDictionary<char, long> Factors(IEnumerable<string> terms)
    {
        var factors = new Dictionary<char, long>();

        foreach (var term in terms)
        {
            var termRev = string.Concat(term.Reverse());
            for (int i = 0; i < termRev.Length; i++)
            {
                var letter = termRev[i];
                factors[letter] = factors.GetValueOrDefault(letter, 0L) + (long)Math.Pow(10, i);
            }
        }

        return factors;
    }

    private static long Sum(this IDictionary<char, long> factors, IDictionary<char, int> solution) =>
        factors.Sum(kv => kv.Value * solution[kv.Key]);

    private static IEnumerable<IDictionary<char, int>> GenerateSolutions(IReadOnlyCollection<char> letters) =>
        Digits
            .Permutations(letters.Count)
            .Select(values => letters.Zip(values).ToDictionary(kv => kv.First, kv => kv.Second));

    private static IEnumerable<T[]> Permutations<T>(this T[] input, int length)
    {
        if (length == 1)
            return input.Select(t => new[] {t});

        return input.Permutations(length - 1)
            .SelectMany(t => input.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new[] {t2}).ToArray());
    }
}