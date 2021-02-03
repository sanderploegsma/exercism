using System.Numerics;
using System.Security.Cryptography;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP) 
    {
        // https://stackoverflow.com/a/17367241/1595197
        var rng = new RNGCryptoServiceProvider();
        var buffer = primeP.ToByteArray();
        BigInteger result;

        do
        {
            rng.GetBytes(buffer);
            result = new BigInteger(buffer);
        } while (result <= 0 || result >= primeP);

        return result;
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) =>
        BigInteger.ModPow(primeG, privateKey, primeP);

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) =>
        BigInteger.ModPow(publicKey, privateKey, primeP);
}