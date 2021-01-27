module RomanNumerals

let roman arabicNumeral =
    let conversions =
        [ ("IIIII", "V")
          ("IIII", "IV")
          ("VV", "X")
          ("VIV", "IX")
          ("XXXXX", "L")
          ("XXXX", "XL")
          ("LL", "C")
          ("LXL", "XC")
          ("CCCCC", "D")
          ("CCCC", "CD")
          ("DD", "M")
          ("DCD", "CM") ]

    let replace (str: string) (oldValue: string, newValue: string) = 
        str.Replace(oldValue, newValue)

    let convert numeral = List.fold replace numeral conversions

    Seq.replicate arabicNumeral 'I'
    |> System.String.Concat
    |> convert