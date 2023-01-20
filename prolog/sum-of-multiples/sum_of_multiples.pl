multiple(Factors, Limit, N) :-
    Max is Limit - 1,
    between(1, Max, N),
    member(F, Factors),
    N mod F =:= 0.

sum_of_multiples(Factors, Limit, Sum) :-
    findall(N, multiple(Factors, Limit, N), AllMultiples),
    list_to_set(AllMultiples, Multiples),
    sum_list(Multiples, Sum).
