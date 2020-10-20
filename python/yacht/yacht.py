"""
This exercise stub and the test suite contain several enumerated constants.

Since Python 2 does not have the enum module, the idiomatic way to write
enumerated constants has traditionally been a NAME assigned to an arbitrary,
but unique value. An integer is traditionally used because it’s memory
efficient.
It is a common practice to export both constants and functions that work with
those constants (ex. the constants in the os, subprocess and re modules).

You can learn more here: https://en.wikipedia.org/wiki/Enumerated_type
"""

from collections import Counter

# Score categories.
# Change the values as you see fit.
YACHT = "YACHT"
ONES = 1
TWOS = 2
THREES = 3
FOURS = 4
FIVES = 5
SIXES = 6
FULL_HOUSE = "FULL_HOUSE"
FOUR_OF_A_KIND = "FOUR_OF_A_KIND"
LITTLE_STRAIGHT = "LITTLE_STRAIGHT"
BIG_STRAIGHT = "BIG_STRAIGHT"
CHOICE = "CHOICE"


def score(dice, category):
    if category in [ONES, TWOS, THREES, FOURS, FIVES, SIXES]:
        return category * len([die for die in dice if die == category])

    if category == LITTLE_STRAIGHT:
        return 30 if sorted(dice) == [1, 2, 3, 4, 5] else 0

    if category == BIG_STRAIGHT:
        return 30 if sorted(dice) == [2, 3, 4, 5, 6] else 0

    if category == CHOICE:
        return sum(dice)

    counts = Counter(dice)

    if category == FULL_HOUSE:
        return sum(dice) if sorted(counts.values()) == [2, 3] else 0

    if category == FOUR_OF_A_KIND:
        four_or_more = [k for k, v in counts.items() if v >= 4]
        if len(four_or_more) > 0:
            return 4 * four_or_more[0]

    if category == YACHT:
        return 50 if len(counts) == 1 else 0

    return 0
