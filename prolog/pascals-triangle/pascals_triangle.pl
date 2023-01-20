bin_coeff(_, 0, 1) :- !.
bin_coeff(N, N, 1) :- !.
bin_coeff(N, K, R) :-
    N >= K,
    K > 0,
    N1 is N - 1,
    K1 is K - 1,
    bin_coeff(N1, K, R1),
    bin_coeff(N1, K1, R2),
    R is R1 + R2.

pascal_row(N, T) :-
    numlist(0, N, KS),
    maplist(bin_coeff(N), KS, T).

pascal(0, []) :- !.
pascal(N, Triangle) :-
    Limit is N - 1,
    numlist(0, Limit, Rows),
    maplist(pascal_row, Rows, Triangle).
