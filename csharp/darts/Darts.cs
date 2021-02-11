using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var radius = Math.Sqrt(x * x + y * y);

        if (radius <= 1.0)
            return 10;
        if (radius <= 5.0)
            return 5;
        if (radius <= 10.0)
            return 1;
        return 0;
    }
}
