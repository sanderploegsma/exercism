module InterestIsInteresting

let interestRate (balance: decimal) : single =
    match balance with
    | x when x >= 5000m -> 2.475f
    | x when x >= 1000m -> 1.621f
    | x when x >= 0m -> 0.5f
    | _ -> 3.213f

let interest (balance: decimal) : decimal =
    balance * (interestRate balance |> decimal) * 0.01m

let annualBalanceUpdate (balance: decimal) : decimal = balance + (interest balance)

let amountToDonate (balance: decimal) (taxFreePercentage: float) : int =
    if balance < 0m then
        0
    else
        balance * (decimal taxFreePercentage * 0.01m) * 2m |> int
