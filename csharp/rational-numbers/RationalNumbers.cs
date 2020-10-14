using System;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}

public struct RationalNumber
{
    private readonly int _a;
    private readonly int _b;

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException($"{nameof(denominator)} cannot be 0");
        }

        (_a, _b) = ReduceToLowestTerms(numerator, denominator);
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var a = r1._a * r2._b + r2._a * r1._b;
        var b = r1._b * r2._b;
        return new RationalNumber(a, b);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        var a = r1._a * r2._b - r2._a * r1._b;
        var b = r1._b * r2._b;
        return new RationalNumber(a, b);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        var a = r1._a * r2._a;
        var b = r1._b * r2._b;
        return new RationalNumber(a, b);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        var a = r1._a * r2._b;
        var b = r2._a * r1._b;
        return new RationalNumber(a, b);
    }

    public RationalNumber Abs() => new RationalNumber(Math.Abs(_a), Math.Abs(_b));

    public RationalNumber Reduce() => this;

    public RationalNumber Exprational(int power)
    {
        if (power > 0)
        {
            return new RationalNumber((int)Math.Pow(_a, power), (int)Math.Pow(_b, power));
        }

        if (power < 0)
        {
            return new RationalNumber((int)Math.Pow(_b, -power), (int)Math.Pow(_a, -power));
        }

        return new RationalNumber(1, 1);
    }

    public double Expreal(int baseNumber) => Math.Pow(Math.Pow(baseNumber, _a), 1.0 / _b);

    private static (int, int) ReduceToLowestTerms(int a, int b)
    {
        var gcd = Gcd(a, b);
        return (a / gcd, b / gcd);
    }

    private static int Gcd(int a, int b) => b switch
    {
        0 => a,
        _ => Gcd(b, a % b)
    };
}