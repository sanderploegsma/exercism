is_letter(C) :- char_type(C, alpha).

isogram(String) :- 
    string_lower(String, Lowered), 
    string_chars(Lowered, Chars),
    include(is_letter, Chars, Letters),
    is_set(Letters).
