collatz_steps(1, 0).

collatz_steps(N, S) :-
    N > 0,
    (0 is mod(N, 2), N1 is N / 2; N1 is 3 * N + 1),
    collatz_steps(N1, S1),
    S is S1 + 1.
