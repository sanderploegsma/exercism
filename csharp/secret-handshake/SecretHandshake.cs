using System;
using System.Collections.Generic;
using System.Linq;

public static class SecretHandshake
{
    private static readonly IDictionary<int, Func<IEnumerable<string>, IEnumerable<string>>> AllCommands =
        new Dictionary<int, Func<IEnumerable<string>, IEnumerable<string>>>
        {
            {1 << 0, x => x.Append("wink")},
            {1 << 1, x => x.Append("double blink")},
            {1 << 2, x => x.Append("close your eyes")},
            {1 << 3, x => x.Append("jump")},
            {1 << 4, x => x.Reverse()},
        };

    public static string[] Commands(int mask) => AllCommands
        .Aggregate(
            Enumerable.Empty<string>(),
            (state, cmd) => (mask & cmd.Key) != 0 ? cmd.Value.Invoke(state) : state)
        .ToArray();
}