"""Solution to the Palindrome Products exercise."""

from typing import Tuple, Union

Product = Tuple[Union[None, int], list[list[int]]]


def is_palindrome(number: int) -> bool:
    """Check whether the given number is palindrome.

    Args:
        number (int): the number to check

    Returns:
        bool: ``True`` if the number is a palindrome
    """
    digits = str(number)
    return digits == digits[::-1]


def find_palindrome_product(factors: list[int], products: list[int]) -> Product:
    """
    Find the first palindrome product from ``products`` and the corresponding factors.

    Args:
        factors (list[int]): factors to consider
        products (list[int]): products to consider

    Returns:
        Product: the palindrome product and the corresponding factors, if any
    """
    for p in filter(is_palindrome, products):
        factor_list = []
        for f1 in factors:
            f2, rest = divmod(p, f1)
            if rest == 0 and f1 <= f2 and f2 in factors:
                factor_list.append([f1, f2])
        
        if len(factor_list) > 0:
            return p, factor_list

    return None, []


def largest(min_factor: int, max_factor: int) -> Product:
    """Given a range of numbers, find the largest palindromes which
       are products of two numbers within that range.

    :param min_factor: int with a default value of 0
    :param max_factor: int
    :return: tuple of (palindrome, iterable).
             Iterable should contain both factors of the palindrome in an arbitrary order.
    """

    if min_factor > max_factor:
        raise ValueError("min must be <= max")

    factors = range(min_factor, max_factor + 1)
    products = range(max_factor ** 2, min_factor ** 2 - 1, -1)

    return find_palindrome_product(factors, products)


def smallest(min_factor: int, max_factor: int) -> Product:
    """Given a range of numbers, find the smallest palindromes which
    are products of two numbers within that range.

    :param min_factor: int with a default value of 0
    :param max_factor: int
    :return: tuple of (palindrome, iterable).
             Iterable should contain both factors of the palindrome in an arbitrary order.
    """

    if min_factor > max_factor:
        raise ValueError("min must be <= max")

    factors = range(min_factor, max_factor + 1)
    products = range(min_factor ** 2, max_factor ** 2 + 1)

    return find_palindrome_product(factors, products)
