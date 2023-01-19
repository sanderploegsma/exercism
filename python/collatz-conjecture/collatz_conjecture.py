def steps(n: int) -> int:
    """
    Calculate the number of steps it takes to reach 1
    from the given value using the Collatz Conjecture.

    Args:
        n (int) : value to calculate the number of steps for

    Raises:
        ValueError: raised when the given value is out of bounds

    Returns:
        int: number of steps
    """

    if n <= 0:
        raise ValueError("Only positive integers are allowed")

    if n == 1:
        return 0

    if n % 2 == 0:
        return 1 + steps(n / 2)

    return 1 + steps(3 * n + 1)
