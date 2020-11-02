from string import ascii_lowercase
from collections import Counter

def is_isogram(string):
    chars = [x for x in string.lower() if x in ascii_lowercase]
    return all([x[1] <= 1 for x in Counter(chars).items()])