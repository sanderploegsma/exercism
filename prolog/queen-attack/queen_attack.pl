in_bounds(N) :- between(0, 7, N).
create((X, Y)) :- in_bounds(X), in_bounds(Y).

attack((X, _), (X, _)) :- !.
attack((_, Y), (_, Y)) :- !.
attack((X1, Y1), (X2, Y2)) :- abs(Y1 - Y2) =:= abs(X1 - X2).
