using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (var a = 0; a < sum / 3; a++)
        {
            for (var b = 0; b < sum / 2; b++)
            {
                var c = sum - b - a;

                if (a < b && a.Squared() + b.Squared() == c.Squared())
                {
                    yield return (a, b, c);
                }
            }
        }
    }
}

internal static class IntExtensions {
    public static int Squared(this int value) => value * value;
}