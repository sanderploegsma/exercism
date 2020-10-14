using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number < 1)
        {
            throw new ArgumentOutOfRangeException("Only positive numbers are allowed");
        }

        return Steps(number, 0);
    }

    private static int Steps(int number, int steps)
    {
        if (number == 1)
        {
            return steps;
        }

        if (number % 2 == 0)
        {
            return Steps(number / 2, steps + 1);
        }

        return Steps(3 * number + 1, steps + 1);
    }
}