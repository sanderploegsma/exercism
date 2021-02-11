using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) =>
        old
            .SelectMany(kv => kv.Value.Select(value => new Tuple<string, int>(value.ToLower(), kv.Key)))
            .ToDictionary(kv => kv.Item1, kv => kv.Item2);
}