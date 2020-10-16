from string import ascii_lowercase

def is_pangram(sentence):
    for c in ascii_lowercase:
        if c not in sentence.lower():
            return False
    return True