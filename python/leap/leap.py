"""Solution to the Leap exercise."""


def leap_year(year: int) -> bool:
    """Check whether the given ``year`` is a leap year.

    Args:
        year (int): the year to check

    Returns:
        bool: ``True`` if the given ``year`` is a leap year.
    """
    
    return year % 400 == 0 or year % 100 != 0 and year % 4 == 0
