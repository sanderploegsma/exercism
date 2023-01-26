module BankAccount

open System
open System.Collections.Concurrent

let store = ConcurrentDictionary<Guid, decimal>()

let mkBankAccount() = Guid.NewGuid()

let openAccount (account: Guid) =
    store.AddOrUpdate(account, 0m, (fun _ _ -> 0m)) |> ignore
    account

let closeAccount (account: Guid) =
    store.TryRemove(account) |> ignore
    account

let getBalance (account: Guid) =
    let mutable balance = 0m
    if store.TryGetValue(account, &balance) then
        Some balance
    else
        None

let updateBalance change (account: Guid) =
    if store.ContainsKey(account) then
        store.AddOrUpdate(account, change, (fun _ balance -> balance + change)) |> ignore
    account