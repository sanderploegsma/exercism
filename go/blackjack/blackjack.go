package blackjack

const (
	Stand            = "S"
	Hit              = "H"
	Split            = "P"
	AutomaticallyWin = "W"
)

// ParseCard returns the integer value of a card following blackjack ruleset.
func ParseCard(card string) int {
	switch card {
	case "two":
		return 2
	case "three":
		return 3
	case "four":
		return 4
	case "five":
		return 5
	case "six":
		return 6
	case "seven":
		return 7
	case "eight":
		return 8
	case "nine":
		return 9
	case "ten", "jack", "queen", "king":
		return 10
	case "ace":
		return 11
	}

	return 0
}

// FirstTurn returns the decision for the first turn, given two cards of the
// player and one card of the dealer.
func FirstTurn(card1, card2, dealerCard string) string {
	card1Value := ParseCard(card1)
	card2Value := ParseCard(card2)
	dealerCardValue := ParseCard(dealerCard)
	sum := card1Value + card2Value

	switch {
	case card1Value == 11 && card2Value == 11:
		return Split
	case sum == 21 && dealerCardValue < 10:
		return AutomaticallyWin
	case sum == 21:
		return Stand
	case sum >= 17 && sum <= 20:
		return Stand
	case sum >= 12 && sum <= 16 && dealerCardValue < 7:
		return Stand
	default:
		return Hit
	}
}
