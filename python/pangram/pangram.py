def is_pangram(sentence):
    for c in "abcdefghijklmnopqrstuvwxyz":
        if c not in sentence.lower():
            return False
    return True