"""Solution to the Triangle exercise."""


def is_triangle(a: float, b: float, c: float) -> bool:
    """Check whether the given sides form a valid triangle.

    A valid triangle has all sides > 0, 
    and each sum of two sides greater or equal to the third side.

    Args:
        a (float): the first side of the triangle
        b (float): the second side of the triangle
        c (float): the third side of the triangle

    Returns:
        bool: ``True`` if the given sides form a valid triangle.
    """
    return a > 0 and b > 0 and c > 0 and a + b >= c and a + c >= b and b + c >= a


def equilateral(sides: list[float]) -> bool:
    """Check whether the given sides form an equilateral triangle.

    An equilateral triangle is a valid triangle where all sides are equal.

    Args:
        sides (list[float]): a list of 3 sides

    Returns:
        bool: ``True`` if the given sides form an equilateral triangle
    """
    a, b, c = sides
    return is_triangle(a, b, c) and a == b and b == c


def isosceles(sides: list[float]) -> bool:
    """Check whether the given sides form an isosceles triangle.

    An isosceles triangle is a valid triangle where (at least) two sides are equal.

    Args:
        sides (list[float]): a list of 3 sides

    Returns:
        bool: ``True`` if the given sides form an isosceles triangle
    """
    a, b, c = sides
    return is_triangle(a, b, c) and (a == b or a == c or b == c)


def scalene(sides: list[float]) -> bool:
    """Check whether the given sides form an scalene triangle.

    An scalene triangle is a valid triangle where none of the sides are equal.

    Args:
        sides (list[float]): a list of 3 sides

    Returns:
        bool: ``True`` if the given sides form an scalene triangle
    """
    a, b, c = sides
    return is_triangle(a, b, c) and a != b and a != c and b != c
