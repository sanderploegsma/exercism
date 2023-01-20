real((A, _), A).
imaginary((_, B), B).

conjugate((A, B), (A, -B)).
abs((A, B), sqrt(A**2 + B**2)).

add((A, B), (C, D), (A+C, B+D)).
sub((A, B), (C, D), (A-C, B-D)).

mul((A, B), (C, D), (A*C-B*D, B*C+A*D)).
div((A, B), (C, D), ((A*C+B*D)/(C**2 + D**2), (B*C-A*D)/(C**2 + D**2))).
