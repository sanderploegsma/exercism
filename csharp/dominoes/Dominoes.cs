using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoValues)
    {
        var dominoes = dominoValues.Select(ToDomino).ToList();

        return !dominoes.Any() || dominoes.Any(domino => CanChain(domino, domino, dominoes.Without(domino)));
    }

    private static bool CanChain(Domino start, Domino current, IReadOnlyCollection<Domino> tail)
    {
        if (!tail.Any())
            return start.Left == current.Right;

        return tail.Any(next => Fits(next) || Fits(next.Flip()));

        bool Fits(Domino next) => current.Right == next.Left && CanChain(start, next, tail.Without(next));
    }

    private static Domino ToDomino((int, int) value, int id) => new Domino(id, value.Item1, value.Item2);

    private static IReadOnlyCollection<Domino> Without(this IEnumerable<Domino> dominoes, Domino domino) =>
        dominoes.Where(d => d.Id != domino.Id).ToList();

    private readonly struct Domino
    {
        public Domino(int id, int left, int right)
        {
            Id = id;
            Left = left;
            Right = right;
        }

        public int Id { get; }
        public int Left { get; }
        public int Right { get; }

        public Domino Flip() => new Domino(Id, Right, Left);
    }
}