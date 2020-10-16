module BankAccount

open System
open System.Collections.Concurrent

let store = ConcurrentDictionary<Guid, Decimal>()

let mkBankAccount() = Guid.NewGuid()

let openAccount account =
    store.AddOrUpdate(account, 0m, (fun _ _ -> 0m)) |> ignore
    account

let closeAccount account =
    store.TryRemove(account) |> ignore
    account

let getBalance account =
    let mutable balance = 0m
    if store.TryGetValue(account, &balance) then
        Some balance
    else
        None

let updateBalance change account =
    if store.ContainsKey(account) then
        store.AddOrUpdate(account, change, (fun _ balance -> balance + change)) |> ignore
    account