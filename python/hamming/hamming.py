def distance(strand_a, strand_b):
    if len(strand_a) != len(strand_b):
        raise ValueError('Strands should be of equal length')

    diff = [pair for pair in zip(strand_a, strand_b) if pair[0] != pair[1]]
    return len(diff)