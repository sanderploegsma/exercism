using System.Linq;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3) =>
        IsTriangle(side1, side2, side3) && DistinctSides(side1, side2, side3) == 3;

    public static bool IsIsosceles(double side1, double side2, double side3) =>
        IsTriangle(side1, side2, side3) && DistinctSides(side1, side2, side3) <= 2;

    public static bool IsEquilateral(double side1, double side2, double side3) =>
        IsTriangle(side1, side2, side3) && DistinctSides(side1, side2, side3) == 1;

    private static bool IsTriangle(double side1, double side2, double side3)
    {
        if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            return false;

        return side1 + side2 >= side3 && 
               side1 + side3 >= side2 && 
               side2 + side3 >= side1;
    }

    private static int DistinctSides(double side1, double side2, double side3) =>
        new[] {side1, side2, side3}.Distinct().Count();
}