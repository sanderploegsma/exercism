import math
import random

def modifier(n):
    return math.floor((n - 10) / 2)

class Character:
    def __init__(self):
        self.strength = self.ability()
        self.dexterity = self.ability()
        self.constitution = self.ability()
        self.intelligence = self.ability()
        self.wisdom = self.ability()
        self.charisma = self.ability()
        self.hitpoints = 10 + modifier(self.constitution)

    def ability(self):
        rolls = random.sample(range(1, 7), 4)
        return sum(sorted(rolls, reverse=True)[0:3])
