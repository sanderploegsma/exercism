using System;

public struct ComplexNumber
{
    private readonly double _a;
    private readonly double _b;

    public ComplexNumber(double real, double imaginary) => (_a, _b) = (real, imaginary);

    public double Real() => _a;

    public double Imaginary() => _b;

    public ComplexNumber Add(ComplexNumber other) => new ComplexNumber(_a + other._a, _b + other._b);

    public ComplexNumber Sub(ComplexNumber other) => new ComplexNumber(_a - other._a, _b - other._b);

    public ComplexNumber Mul(ComplexNumber other)
    {
        var a = _a * other._a - _b * other._b;
        var b = _b * other._a + _a * other._b;
        return new ComplexNumber(a, b);
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        var div = Math.Pow(other._a, 2) + Math.Pow(other._b, 2);
        var a = (_a * other._a + _b * other._b) / div;
        var b = (_b * other._a - _a * other._b) / div;
        return new ComplexNumber(a, b);
    }

    public double Abs() => Math.Sqrt(Math.Pow(_a, 2) + Math.Pow(_b, 2));

    public ComplexNumber Conjugate() => new ComplexNumber(_a, _b * -1);

    public ComplexNumber Exp()
    {
        var a = Math.Pow(Math.E, _a) * Math.Cos(_b);
        var b = Math.Pow(Math.E, _a) * Math.Sin(_b);
        return new ComplexNumber(a, b);
    }
}