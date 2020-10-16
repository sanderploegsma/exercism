module TwelveDays

let nth = [
    "first";
    "second";
    "third";
    "fourth";
    "fifth";
    "sixth";
    "seventh";
    "eighth";
    "ninth";
    "tenth";
    "eleventh";
    "twelfth";
]

let parts = [
    "a Partridge in a Pear Tree";
    "two Turtle Doves";
    "three French Hens";
    "four Calling Birds";
    "five Gold Rings";
    "six Geese-a-Laying";
    "seven Swans-a-Swimming";
    "eight Maids-a-Milking";
    "nine Ladies Dancing";
    "ten Lords-a-Leaping";
    "eleven Pipers Piping";
    "twelve Drummers Drumming";
]

let rec reciteN n = 
    let part = parts.[n - 1]
    match n with
    | 1 -> part
    | 2 -> sprintf "%s, and %s" part (reciteN (n - 1))
    | _ -> sprintf "%s, %s" part (reciteN (n - 1))

let composeN n = sprintf "On the %s day of Christmas my true love gave to me: %s." nth.[n - 1] (reciteN n)

let recite start stop =
    seq { start .. stop }
    |> Seq.map composeN
    |> Seq.toList