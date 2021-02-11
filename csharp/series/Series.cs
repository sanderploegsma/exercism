using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength <= 0 || sliceLength > numbers.Length)
        {
            throw new ArgumentException("Invalid slice length", nameof(sliceLength));
        }
        
        return CreateSlices().ToArray();
        
        IEnumerable<string> CreateSlices()
        {
            for (var i = 0; i <= numbers.Length - sliceLength; i++)
            {
                yield return numbers.Substring(i, sliceLength);
            }
        }
    }
}