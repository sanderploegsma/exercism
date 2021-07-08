using System;
using System.Collections.Generic;
using System.Linq;

public static class Poker
{
    private const int AceValue = 14;
    private const int KingValue = 13;
    private const int QueenValue = 12;
    private const int JackValue = 11;

    public static IEnumerable<string> BestHands(IEnumerable<string> rawHands)
    {
        var hands = rawHands.Select(x => new Hand(x)).ToList();
        var bestHand = hands.Max();

        return 
            from hand in hands
            where hand.CompareTo(bestHand) == 0
            select hand.RawHand;
    }

    private class Hand : IComparable<Hand>
    {
        public Hand(string rawHand)
        {
            RawHand = rawHand;
            Cards = rawHand.Split(" ").Select(card => new Card(card)).ToList();
            Rank = GetRank(Cards);
        }

        public string RawHand { get; }
        
        public IReadOnlyCollection<Card> Cards { get; }
        
        public Rank Rank { get; }

        public int CompareTo(Hand other)
        {
            if (Rank.CompareTo(other.Rank) != 0)
                return Rank.CompareTo(other.Rank);

            var myCards = Cards
                .GroupBy(x => x.Value)
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .Select(g => g.Key);
            
            var theirCards = other.Cards
                .GroupBy(x => x.Value)
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .Select(g => g.Key);

            foreach (var (mine, theirs) in myCards.Zip(theirCards))
            {
                if (mine.CompareTo(theirs) != 0)
                    return mine.CompareTo(theirs);
            }

            return 0;
        }

        private static Rank GetRank(IReadOnlyCollection<Card> cards)
        {
            var isFlush = cards
                .Select(c => c.Suit)
                .Distinct()
                .Count() == 1;

            var isStraight = IsStraight(cards.Select(c => c.Value));
            var isStraightFiveHigh = IsStraight(cards.Select(c => c.Value == AceValue ? 1 : c.Value));

            if (isFlush && isStraight)
                return Rank.StraightFlush;

            if (isFlush && isStraightFiveHigh)
                return Rank.StraightFlushFiveHigh;

            var cardsByValue = cards.GroupBy(c => c.Value).ToList();

            if (cardsByValue.Any(g => g.Count() == 4))
                return Rank.FourOfAKind;

            var isThreeOfAKind = cardsByValue.Any(g => g.Count() == 3);
            var isPair = cardsByValue.Any(g => g.Count() == 2);
        
            if (isThreeOfAKind && isPair)
                return Rank.FullHouse;

            if (isFlush)
                return Rank.Flush;

            if (isStraight)
                return Rank.Straight;

            if (isStraightFiveHigh)
                return Rank.StraightFiveHigh;

            if (isThreeOfAKind)
                return Rank.ThreeOfAKind;
        
            if (cardsByValue.Count(g => g.Count() == 2) == 2)
                return Rank.TwoPair;

            if (isPair)
                return Rank.OnePair;

            return Rank.HighCard;
        }
        
        private static bool IsStraight(IEnumerable<int> values) => values
            .OrderBy(x => x)
            .Select((x, i) => x - i)
            .Distinct()
            .Count() == 1;
    }

    private class Card : IComparable<Card>
    {
        public Card(string rawCard)
        {
            RawCard = rawCard;
            
            Value = rawCard[..^1] switch
            {
                "A" => AceValue,
                "K" => KingValue,
                "Q" => QueenValue,
                "J" => JackValue,
                var x when int.TryParse(x, out var value) => value,
                _ => throw new ArgumentException($"Invalid card {rawCard}")
            };
            
            Suit = rawCard[^1] switch
            {
                'S' => Suit.Spades,
                'C' => Suit.Clubs,
                'D' => Suit.Diamonds,
                'H' => Suit.Hearts,
                _ => throw new ArgumentException($"Invalid card {rawCard}")
            };
        }

        public string RawCard { get; }
        
        public Suit Suit { get; }
        
        public int Value { get; }

        public int CompareTo(Card other) => Value.CompareTo(other.Value);
    }

    private enum Suit
    {
        Spades,
        Clubs,
        Diamonds,
        Hearts,
    }

    private enum Rank
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        StraightFiveHigh,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlushFiveHigh,
        StraightFlush
    }
}