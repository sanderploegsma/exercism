module ErrorHandling

let handleErrorByThrowingException () = failwith "Here's your exception"

let handleErrorByReturningOption (input: string) =
    let mutable value = 0

    if System.Int32.TryParse(input, &value) then
        Some value
    else
        None

let handleErrorByReturningResult (input: string) =
    let mutable value = 0

    if System.Int32.TryParse(input, &value) then
        Ok value
    else
        Error "Could not convert input to integer"

let bind = Result.bind

let cleanupDisposablesWhenThrowingException resource =
    use r = resource
    failwith "Oh no!"