public class Blackjack {
    private static final int BLACKJACK = 21;
    private static final String STAND = "S";
    private static final String HIT = "H";
    private static final String SPLIT = "P";
    private static final String AUTOMATICALLY_WIN = "W";

    public int parseCard(String card) {
        return switch (card) {
            case "two" -> 2;
            case "three" -> 3;
            case "four" -> 4;
            case "five" -> 5;
            case "six" -> 6;
            case "seven" -> 7;
            case "eight" -> 8;
            case "nine" -> 9;
            case "ten", "jack", "queen", "king" -> 10;
            case "ace" -> 11;
            default -> 0;
        };
    }

    public boolean isBlackjack(String card1, String card2) {
        return parseCard(card1) + parseCard(card2) == BLACKJACK;
    }

    public String largeHand(boolean isBlackjack, int dealerScore) {
        if (isBlackjack && dealerScore < 10) {
            return AUTOMATICALLY_WIN;
        }

        return isBlackjack ? STAND : SPLIT;
    }

    public String smallHand(int handScore, int dealerScore) {
        if (handScore >= 17) {
            return STAND;
        }

        if (handScore <= 11) {
            return HIT;
        }

        return (dealerScore >= 7) ? HIT : STAND;
    }

    // FirstTurn returns the semi-optimal decision for the first turn, given the cards of the player and the dealer.
    // This function is already implemented and does not need to be edited. It pulls the other functions together in a
    // complete decision tree for the first turn.
    public String firstTurn(String card1, String card2, String dealerCard) {
        int handScore = parseCard(card1) + parseCard(card2);
        int dealerScore = parseCard(dealerCard);

        if (20 < handScore) {
            return largeHand(isBlackjack(card1, card2), dealerScore);
        } else {
            return smallHand(handScore, dealerScore);
        }
    }
}
