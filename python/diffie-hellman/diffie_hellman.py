"""Solution to the Diffie Helman exercise."""

import random


def private_key(p: int) -> int:
    """Generate a new "random" private key between 1 and ``p``.

    Args:
        p (int): the maximum value for the generated key.

    Returns:
        int: the generated private key
    """
    
    return random.randint(2, p - 1)


def public_key(p: int, g: int, private: int) -> int:
    """Calculate the public key from the given private key and primes ``p`` and ``g``.

    Args:
        p (int): a prime number
        g (int): a prime number
        private (int): the private key used to calculate the public key

    Returns:
        int: the calculated public key
    """

    return g ** private % p


def secret(p: int, public: int, private: int) -> int:
    """Calculate a secret from the given public and private keys and prime ``p``.

    Args:
        p (int): a prime number
        public (int): the public key used to calculate the secret
        private (int): the private key used to calculate the secret

    Returns:
        int: the calculated secret
    """
    
    return public ** private % p
