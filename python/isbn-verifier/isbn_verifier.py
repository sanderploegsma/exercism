"""Solution to the ISBN Verifier exercise."""


def is_valid(isbn: str) -> bool:
    """Check whether the given ``isbn`` is valid.

    Args:
        isbn (str): the isbn number to check

    Returns:
        bool: ``True`` if the given ``isbn`` is valid.
    """
    
    digits = [x.replace('X', '10') for x in list(isbn.replace('-', ''))]

    if len(digits) != 10 or any(not d.isdigit() for d in digits) or any(d == '10' for d in digits[:-1]):
        return False

    checksum = sum((10 - i) * int(d) for i, d in enumerate(digits))

    return checksum % 11 == 0
