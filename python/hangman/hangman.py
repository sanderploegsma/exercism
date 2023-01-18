# Game status categories
# Change the values as you see fit
STATUS_WIN = "win"
STATUS_LOSE = "lose"
STATUS_ONGOING = "ongoing"


class Hangman:
    def __init__(self, word):
        self.remaining_guesses = 9
        self.status = STATUS_ONGOING
        self.word = word
        self.guesses = []

    def guess(self, char):
        if self.status != STATUS_ONGOING:
            raise ValueError("The game has already ended.")
        
        if char in self.guesses or char not in self.word:
            self.remaining_guesses -= 1
            
        self.guesses.append(char)

        if self.get_masked_word() == self.word:
            self.status = STATUS_WIN
        
        if self.remaining_guesses < 0:
            self.status = STATUS_LOSE

    def get_masked_word(self):
        return "".join([c if c in self.guesses else '_' for c in self.word])

    def get_status(self):
        return self.status
