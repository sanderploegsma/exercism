using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    private const uint BitMask = 0x7Fu;
    private const uint SignBitMask = 0x80u;
    
    public static uint[] Encode(IEnumerable<uint> numbers)
    {
        return numbers.SelectMany(Convert).ToArray();

        static IEnumerable<uint> Convert(uint number)
        {
            var bytes = new List<uint>
            {
                number & BitMask
            };

            number >>= 7;
            while (number > 0)
            {
                bytes.Add(number & BitMask | SignBitMask);
                number >>= 7;
            }

            return bytes.AsEnumerable().Reverse();
        }
    }

    public static uint[] Decode(uint[] bytes)
    {
        if ((bytes.Last() & SignBitMask) != 0) 
            throw new InvalidOperationException();

        var numbers = new List<uint>();
        var value = 0u;
        
        foreach (var b in bytes)
        {
            value <<= 7;
            value |= b & BitMask;

            if ((b & SignBitMask) != 0)
            {
                continue;
            }

            numbers.Add(value);
            value = 0u;
        }

        return numbers.ToArray();
    }
}