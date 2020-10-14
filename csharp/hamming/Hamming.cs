using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("DNA strands should be of equal length.");
        }

        return firstStrand.ToCharArray().Zip(secondStrand.ToCharArray()).Count(pair => pair.First != pair.Second);
    }
}