module Leap

let leapYear (year: int): bool = match year with
    | _ when year % 400 = 0 -> true
    | _ when year % 100 = 0 -> false
    | _ when year % 4 = 0 -> true
    | _ -> false