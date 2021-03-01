using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    public static int Prime(int nth)
    {
        if (nth < 1)
            throw new ArgumentOutOfRangeException(nameof(nth), nth, "Parameter should be a positive number");

        return Primes().Skip(nth - 1).First();
    }

    private static IEnumerable<int> Primes()
    {
        var primes = new HashSet<int>();
        
        return Enumerable
            .Range(2, int.MaxValue - 2)
            .Where(IsPrime)
            .Where(primes.Add);

        bool IsPrime(int n) => primes.All(x => n % x != 0);
    }
}