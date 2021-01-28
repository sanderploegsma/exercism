module Sieve

let primes limit =
    let withoutMultiplesOf p numbers = 
        List.except [ p .. p .. limit ] numbers

    let rec find numbers primes =
        match numbers with
        | [] -> primes
        | p :: tail -> find (withoutMultiplesOf p tail) (primes @ [ p ])

    find [ 2 .. limit ] []
