sum_digits([], 0).
sum_digits(['0'|T], S) :- sum_digits(T, S).
sum_digits(['1'|T], S) :-
    sum_digits(T, S1),
    length(T, N),
    S is 2**N + S1.

binary(Str, Dec) :-
    string_chars(Str, Digits),
    sum_digits(Digits, Dec).
