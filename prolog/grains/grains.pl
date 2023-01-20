in_range(Square) :- between(1, 64, Square).

square(Square, Value) :-
    in_range(Square),
    Value is 2 ** (Square - 1).

total(Value) :-
    findall(Square, in_range(Square), Squares),
    maplist(square, Squares, Values),
    sum_list(Values, Value).
