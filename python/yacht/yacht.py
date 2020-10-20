YACHT = lambda dice: 50 if len(set(dice)) == 1 else 0
ONES = lambda dice: 1 * len([x for x in dice if x == 1])
TWOS = lambda dice: 2 * len([x for x in dice if x == 2])
THREES = lambda dice: 3 * len([x for x in dice if x == 3])
FOURS = lambda dice: 4 * len([x for x in dice if x == 4])
FIVES = lambda dice: 5 * len([x for x in dice if x == 5])
SIXES = lambda dice: 6 * len([x for x in dice if x == 6])
FULL_HOUSE = (
    lambda dice: sum(dice)
    if len(set(dice)) == 2 and any(dice.count(x) == 3 for x in set(dice))
    else 0
)
FOUR_OF_A_KIND = lambda dice: sum(x * 4 for x in set(dice) if dice.count(x) >= 4)
LITTLE_STRAIGHT = lambda dice: 30 if sorted(dice) == [1, 2, 3, 4, 5] else 0
BIG_STRAIGHT = lambda dice: 30 if sorted(dice) == [2, 3, 4, 5, 6] else 0
CHOICE = sum


def score(dice, category):
    return category(dice)
