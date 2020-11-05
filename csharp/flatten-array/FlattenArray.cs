using System.Collections;
using System.Linq;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input) =>
        input.Cast<object>()
            .SelectMany(obj => obj switch
            {
                null => Enumerable.Empty<object>(),
                IEnumerable enumerable => Flatten(enumerable).Cast<object>(),
                _ => new[] {obj}
            });
}