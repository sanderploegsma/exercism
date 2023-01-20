hamming_distance(Str1, Str2, Dist) :-
    string_chars(Str1, Chars1),
    string_chars(Str2, Chars2),
    hamming_distance_list(Chars1, Chars2, Dist).

hamming_distance_list([], [], 0).

hamming_distance_list([H|T1], [H|T2], D) :- 
    hamming_distance_list(T1, T2, D), 
    !.

hamming_distance_list([_|T1],[_|T2], D) :-
    hamming_distance_list(T1, T2, D1),
    D is D1 + 1.