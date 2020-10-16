module DiffieHellman

open System
open System.Numerics
open System.Security.Cryptography

let privateKey (primeP: bigint) =
    let rng = new RNGCryptoServiceProvider()
    let bytes = primeP.ToByteArray()
    let mutable r = BigInteger(-1)
    while r < 0I || r >= primeP do
        rng.GetBytes(bytes)
        r <- BigInteger(bytes)
    r

let publicKey primeP primeG privateKey = BigInteger.ModPow(primeG, privateKey, primeP)

let secret primeP publicKey privateKey = BigInteger.ModPow(publicKey, privateKey, primeP)