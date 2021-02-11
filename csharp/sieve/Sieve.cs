using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), limit, "Invalid limit");
        }
        
        var candidates = Enumerable.Range(2, limit - 1).ToList();
        var primes = new List<int>();

        while (candidates.Any())
        {
            var prime = candidates.First();
            primes.Add(prime);
            candidates.RemoveAll(n => n % prime == 0);
        }

        return primes.ToArray();
    }
}