using System;
using System.Linq;

public class DndCharacter
{
    private static readonly Random Rng = new Random();

    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }
    public int Hitpoints => 10 + Modifier(Constitution);

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2d);

    public static int Ability() =>
        new[] {Rng.Next(1, 7), Rng.Next(1, 7), Rng.Next(1, 7), Rng.Next(1, 7)}
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

    public static DndCharacter Generate() => new DndCharacter
    {
        Strength = Ability(),
        Dexterity = Ability(),
        Constitution = Ability(),
        Intelligence = Ability(),
        Wisdom = Ability(),
        Charisma = Ability()
    };
}