def slices(series, length):
    if length < 1:
        raise ValueError("Length must be higher than 0")
    if length > len(series):
        raise ValueError("Length may not exceed series length")
    return [series[i : i + length] for i in range(len(series) - length + 1)]
