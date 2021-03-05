using System;
using System.Collections.Generic;
using System.Linq;

public enum Color { Red, Green, Ivory, Yellow, Blue }

public enum Nationality { Englishman, Spaniard, Ukranian, Japanese, Norwegian }

public enum Pet { Dog, Snails, Fox, Horse, Zebra }

public enum Drink { Coffee, Tea, Milk, OrangeJuice, Water }

public enum Smoke { OldGold, Kools, Chesterfields, LuckyStrike, Parliaments }

public static class ZebraPuzzle
{
    private static House[] _answer;

    public static Nationality DrinksWater()
    {
        _answer ??= Solve();
        var house = _answer.First(x => x.Drink == Drink.Water);
        return house.Nationality;
    }

    public static Nationality OwnsZebra()
    {
        _answer ??= Solve();
        var house = _answer.First(x => x.Pet == Pet.Zebra);
        return house.Nationality;
    }

    private static House[] Solve()
    {
        var answers =
            from colors in Permutations<Color>()
            where Rules.GreenHouseIsRightOfIvoryHouse(colors)
            from nationalities in Permutations<Nationality>()
            where Rules.NorwegianLivesInFirstHouse(nationalities)
            where Rules.NorwegianLivesNextToBlueHouse(nationalities, colors)
            where Rules.EnglishmanLivesInRedHouse(nationalities, colors)
            from pets in Permutations<Pet>()
            where Rules.SpaniardOwnsDog(nationalities, pets)
            from drinks in Permutations<Drink>()
            where Rules.MilkIsDrunkInTheMiddleHouse(drinks)
            where Rules.CoffeeIsDrunkInGreenHouse(colors, drinks)
            where Rules.UkraniansDrinkTea(nationalities, drinks)
            from smokes in Permutations<Smoke>()
            where Rules.KoolsAreSmokedInTheYellowHouse(smokes, colors)
            where Rules.LuckyStrikeSmokerDrinksOrangeJuice(smokes, drinks)
            where Rules.JapaneseSmokesParliaments(nationalities, smokes)
            where Rules.OldGoldSmokerOwnsSnails(smokes, pets)
            where Rules.KoolsAreSmokedNextToHorse(smokes, pets)
            where Rules.ManWhoSmokesChesterFieldsLivesNextToManWithFox(smokes, pets)
            select CreateAnswer(colors, nationalities, pets, drinks, smokes);

        return answers.Single();

        static House[] CreateAnswer(Color[] c, Nationality[] n, Pet[] p, Drink[] d, Smoke[] s) =>
            Enumerable.Range(0, 5).Select(i => new House(c[i], n[i], p[i], d[i], s[i])).ToArray();
    }


    private static IEnumerable<T[]> Permutations<T>() where T : Enum =>
        Enum.GetValues(typeof(T)).Cast<T>().ToArray().Permutations();

    private static IEnumerable<T[]> Permutations<T>(this T[] input) => input.Permutations(input.Length);

    private static IEnumerable<T[]> Permutations<T>(this T[] input, int length)
    {
        if (length == 1)
            return input.Select(t => new[] {t});

        return input.Permutations(length - 1)
            .SelectMany(t => input.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new[] {t2}).ToArray());
    }
}

internal static class Rules
{
    public static bool EnglishmanLivesInRedHouse(Nationality[] nationalities, Color[] colors) =>
        Array.IndexOf(nationalities, Nationality.Englishman) == Array.IndexOf(colors, Color.Red);

    public static bool SpaniardOwnsDog(Nationality[] nationalities, Pet[] pets) =>
        Array.IndexOf(nationalities, Nationality.Spaniard) == Array.IndexOf(pets, Pet.Dog);

    public static bool CoffeeIsDrunkInGreenHouse(Color[] colors, Drink[] drinks) =>
        Array.IndexOf(colors, Color.Green) == Array.IndexOf(drinks, Drink.Coffee);

    public static bool UkraniansDrinkTea(Nationality[] nationalities, Drink[] drinks) =>
        Array.IndexOf(nationalities, Nationality.Ukranian) == Array.IndexOf(drinks, Drink.Tea);

    public static bool GreenHouseIsRightOfIvoryHouse(Color[] colors) =>
        Array.IndexOf(colors, Color.Green) == Array.IndexOf(colors, Color.Ivory) + 1;

    public static bool OldGoldSmokerOwnsSnails(Smoke[] smokes, Pet[] pets) =>
        Array.IndexOf(smokes, Smoke.OldGold) == Array.IndexOf(pets, Pet.Snails);

    public static bool KoolsAreSmokedInTheYellowHouse(Smoke[] smokes, Color[] colors) =>
        Array.IndexOf(smokes, Smoke.Kools) == Array.IndexOf(colors, Color.Yellow);

    public static bool MilkIsDrunkInTheMiddleHouse(Drink[] drinks) =>
        Array.IndexOf(drinks, Drink.Milk) == 2;

    public static bool NorwegianLivesInFirstHouse(Nationality[] nationalities) =>
        Array.IndexOf(nationalities, Nationality.Norwegian) == 0;

    public static bool ManWhoSmokesChesterFieldsLivesNextToManWithFox(Smoke[] smokes, Pet[] pets) =>
        Math.Abs(Array.IndexOf(smokes, Smoke.Chesterfields) - Array.IndexOf(pets, Pet.Fox)) == 1;

    public static bool KoolsAreSmokedNextToHorse(Smoke[] smokes, Pet[] pets) =>
        Math.Abs(Array.IndexOf(smokes, Smoke.Kools) - Array.IndexOf(pets, Pet.Horse)) == 1;

    public static bool LuckyStrikeSmokerDrinksOrangeJuice(Smoke[] smokes, Drink[] drinks) =>
        Array.IndexOf(smokes, Smoke.LuckyStrike) == Array.IndexOf(drinks, Drink.OrangeJuice);

    public static bool JapaneseSmokesParliaments(Nationality[] nationalities, Smoke[] smokes) =>
        Array.IndexOf(nationalities, Nationality.Japanese) == Array.IndexOf(smokes, Smoke.Parliaments);

    public static bool NorwegianLivesNextToBlueHouse(Nationality[] nationalities, Color[] colors) =>
        Math.Abs(Array.IndexOf(nationalities, Nationality.Norwegian) - Array.IndexOf(colors, Color.Blue)) == 1;
}

internal readonly struct House
{
    public House(Color color, Nationality nationality, Pet pet, Drink drink, Smoke smoke)
    {
        Color = color;
        Nationality = nationality;
        Pet = pet;
        Drink = drink;
        Smoke = smoke;
    }

    public Color Color { get; }
    public Nationality Nationality { get; }
    public Pet Pet { get; }
    public Drink Drink { get; }
    public Smoke Smoke { get; }
}