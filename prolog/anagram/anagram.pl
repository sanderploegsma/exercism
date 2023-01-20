chars_sorted(Str, Sorted) :-
    string_chars(Str, Chars),
    msort(Chars, Sorted).

is_anagram(Word, Option) :-
    string_lower(Word, WordLowered),
    string_lower(Option, OptionLowered),
    WordLowered \= OptionLowered,
    chars_sorted(WordLowered, WordChars),
    chars_sorted(OptionLowered, OptionChars),
    WordChars == OptionChars.

anagram(Word, Options, Matching) :- include(is_anagram(Word), Options, Matching).
