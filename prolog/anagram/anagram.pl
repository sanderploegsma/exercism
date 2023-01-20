is_anagram(Word, Option) :-
    string_lower(Word, WordLowered),
    string_lower(Option, OptionLowered),
    WordLowered \= OptionLowered,
    string_chars(WordLowered, WordChars),
    string_chars(OptionLowered, OptionChars),
    permutation(WordChars, OptionChars).

anagram(Word, Options, Matching) :- include(is_anagram(Word), Options, Matching).
