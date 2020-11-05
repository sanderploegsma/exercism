nth = [
    "first",
    "second",
    "third",
    "fourth",
    "fifth",
    "sixth",
    "seventh",
    "eighth",
    "ninth",
    "tenth",
    "eleventh",
    "twelfth",
]

items = [
    "a Partridge in a Pear Tree",
    "two Turtle Doves",
    "three French Hens",
    "four Calling Birds",
    "five Gold Rings",
    "six Geese-a-Laying",
    "seven Swans-a-Swimming",
    "eight Maids-a-Milking",
    "nine Ladies Dancing",
    "ten Lords-a-Leaping",
    "eleven Pipers Piping",
    "twelve Drummers Drumming",
]


def build(n):
    item = items[n - 1]
    if n == 1:
        return f"{item}."

    if n == 2:
        return f"{item}, and " + build(n - 1)

    return f"{item}, " + build(n - 1)


def verse(n):
    return f"On the {nth[n - 1]} day of Christmas my true love gave to me: {build(n)}"


def recite(start_verse, end_verse):
    return [verse(n) for n in range(start_verse, end_verse + 1)]
