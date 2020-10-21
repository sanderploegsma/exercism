def classify(number):
    if number <= 0:
        raise ValueError("Input must be a positive number")

    factors = [x for x in range(1, int(number)) if number % x == 0]
    aliquot_sum = sum(factors)

    if aliquot_sum == number:
        return "perfect"
    elif aliquot_sum < number:
        return "deficient"
    else:
        return "abundant"
