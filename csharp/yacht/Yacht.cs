using System.Collections.Generic;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    private const int LittleStraight = 1 + 2 + 3 + 4 + 5;
    private const int BigStraight = 2 + 3 + 4 + 5 + 6;

    public static int Score(int[] dice, YachtCategory category)
    {
        var groups = dice.GroupBy(x => x).ToList();
        
        var isYacht = groups.Count == 1;
        var isFullHouse = groups.Count == 2 && groups.Any(x => x.Count() == 3);
        var isLittleStraight = groups.Count == 5 && dice.Sum() == LittleStraight;
        var isBigStraight = groups.Count == 5 && dice.Sum() == BigStraight;

        return category switch
        {
            YachtCategory.Ones => SumCategory(dice, YachtCategory.Ones),  
            YachtCategory.Twos => SumCategory(dice, YachtCategory.Twos), 
            YachtCategory.Threes => SumCategory(dice, YachtCategory.Threes), 
            YachtCategory.Fours => SumCategory(dice, YachtCategory.Fours), 
            YachtCategory.Fives => SumCategory(dice, YachtCategory.Fives), 
            YachtCategory.Sixes => SumCategory(dice, YachtCategory.Sixes),
            YachtCategory.Choice => dice.Sum(),
            YachtCategory.FullHouse when isFullHouse => dice.Sum(),
            YachtCategory.LittleStraight when isLittleStraight => 30,
            YachtCategory.BigStraight when isBigStraight => 30,
            YachtCategory.Yacht when isYacht => 50,
            YachtCategory.FourOfAKind => dice
                .GroupBy(x => x)
                .Where(x => x.Count() >= 4)
                .Select(x => x.Take(4).Sum())
                .FirstOrDefault(),
            _ => 0
        };
    }

    private static int SumCategory(IEnumerable<int> dice, YachtCategory target) =>
        dice.Where(x => x == (int)target).Sum();
}