nucleotide('A', 1, 0, 0, 0).
nucleotide('C', 0, 1, 0, 0).
nucleotide('G', 0, 0, 1, 0).
nucleotide('T', 0, 0, 0, 1).

nucleotide_count([], A, C, G, T, [('A', A), ('C', C), ('G', G), ('T', T)]).
nucleotide_count([H|Tail], A, C, G, T, Total) :-
    nucleotide(H, A1, C1, G1, T1),
    A2 is A + A1,
    C2 is C + C1,
    G2 is G + G1,
    T2 is T + T1,
    nucleotide_count(Tail, A2, C2, G2, T2, Total).

nucleotide_count(Dna, Count) :-
    string_chars(Dna, Chars),
    nucleotide_count(Chars, 0, 0, 0, 0, Count).
