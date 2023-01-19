def natural_range(number: int) -> list[int]:
    return range(1, number + 1)


def square_of_sum(number: int) -> int:
    return sum(natural_range(number)) ** 2


def sum_of_squares(number: int) -> int:
    return sum([n ** 2 for n in natural_range(number)])


def difference_of_squares(number: int) -> int:
    return square_of_sum(number) - sum_of_squares(number)
