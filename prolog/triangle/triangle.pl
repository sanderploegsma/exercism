triangle(A, B, C) :- 
    A > 0, 
    B > 0, 
    C > 0, 
    A + B >= C, 
    A + C >= B, 
    B + C >= A.

isosceles(A, A, _).
isosceles(A, _, A).
isosceles(_, A, A).

triangle(A, A, A, "equilateral") :- triangle(A, A, A).
triangle(A, B, C, "isosceles") :- triangle(A, B, C), isosceles(A, B, C), !.
triangle(A, B, C, "scalene") :- triangle(A, B, C), A =\= B, A =\= C, B =\= C.
