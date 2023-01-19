triangle_side(X) :- X > 0.

triangle(A, B, C) :- triangle_side(A), triangle_side(B), triangle_side(C), A + B >= C, A + C >= B, B + C >= A.

triangle(A, A, A, "equilateral") :- triangle(A, A, A).

triangle(A, A, A, "isosceles") :- triangle(A, A, A).
triangle(A, A, B, "isosceles") :- triangle(A, A, B).
triangle(A, B, A, "isosceles") :- triangle(A, B, A).
triangle(B, A, A, "isosceles") :- triangle(B, A, A).

triangle(A, B, C, "scalene") :- triangle(A, B, C), A =\= B, A =\= C, B =\= C.
