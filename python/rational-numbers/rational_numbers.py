from __future__ import division

def gcd(a, b):
    return a if b == 0 else gcd(b, a % b)

class Rational:
    def __init__(self, numer, denom):
        div = gcd(numer, denom)
        self.numer = int(numer / div)
        self.denom = int(denom / div)

    def __eq__(self, other):
        return self.numer == other.numer and self.denom == other.denom

    def __repr__(self):
        return '{}/{}'.format(self.numer, self.denom)

    def __add__(self, other):
        a = self.numer * other.denom + self.denom * other.numer
        b = self.denom * other.denom
        return Rational(a, b)

    def __sub__(self, other):
        a = self.numer * other.denom - self.denom * other.numer
        b = self.denom * other.denom
        return Rational(a, b)

    def __mul__(self, other):
        a = self.numer * other.numer
        b = self.denom * other.denom
        return Rational(a, b)

    def __truediv__(self, other):
        a = self.numer * other.denom
        b = self.denom * other.numer
        return Rational(a, b)

    def __abs__(self):
        return Rational(abs(self.numer), abs(self.denom))

    def __pow__(self, power):
        if power >= 0:
            return Rational(pow(self.numer, power), pow(self.denom, power))
        
        return Rational(pow(self.denom, abs(power)), pow(self.numer, abs(power)))

    def __rpow__(self, base):
        return pow(pow(base, self.numer), 1 / self.denom)
