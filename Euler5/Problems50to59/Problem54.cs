/*
 * https://projecteuler.net/problem=54
 * Poker hands
 * Ref: http://en.wikipedia.org/wiki/List_of_poker_hands
 * The answer is 376.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems50to59
{
    class Problem54
    {
        public long soln1()
        {
            long p1wins = 0;
            var sw = Stopwatch.StartNew();

            //this.runTests();
            //return 0;

            string[] cards_data = File.ReadAllLines(
            @"C:\Users\ahuey\Documents\Visual Studio 2012\Projects\Euler\Euler5\Problems50to59\p054_poker.txt");            
            Console.WriteLine("Read {0} lines.", cards_data.Length);
            
            foreach (string line in cards_data)
            {
                Console.WriteLine(line);
                p1wins += processRound(line);
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return p1wins;
        }

        private void runTests()
        {
            Hand testHand = new Hand();
            //string sHand = "TC JC QC KC AC";
            //string sHand = "3C 4C 5C 6C 7C";
            string sHand = "3C 2S 5H 4D 6C";
            string[] cards = sHand.Split(' ');
            foreach (string sc in cards)
            {
                Card c = new Card(sc);
                Console.WriteLine(c.ToString());
                testHand.AddCard(c);
            }
            Console.WriteLine("Straight: {0}", testHand.isStraight());

            //Console.WriteLine("Royal flush: {0}", testHand.isRoyalFlush());
            //Console.WriteLine("Straight flush: {0}", testHand.isStraightFlush());
            //Console.WriteLine("Four of a kind: {0}", testHand.isFourOfAKind());
            //Console.WriteLine("Full house: {0}", testHand.isFullHouse());
            //Console.WriteLine("Flush: {0}", testHand.isFlush());
            //Console.WriteLine("Straight: {0}", testHand.isStraight());
            //Console.WriteLine("Three of a kind: {0}", testHand.isThreeOfAKind());
            //Console.WriteLine("Two pair: {0}", testHand.isTwoPair());
            //Console.WriteLine("high card: {0}", testHand.getHighCard());
            //Console.WriteLine("SCORE: {0}", testHand.GetHandValue());
        }

        private int processRound(string line)
        {
            // return 1 if player 1 wins.
            // first, parse out the data and create hands for players 1 & 2.
            string[] cards = line.Split(' ');
            if (cards.Length != 10)
                throw new Exception("input line does not contain 10 cards.");

            Hand p1hand = new Hand();
            for (int i = 0; i < 5; i++)
                p1hand.AddCard(cards[i]);
            Hand p2hand = new Hand();
            for (int i = 5; i < 10; i++)
                p2hand.AddCard(cards[i]);

            // now, compare the hands.
            int p1score = p1hand.GetHandValue();
            int p2score = p2hand.GetHandValue();
            // tiebreaker
            if (p1score == p2score)
            {
                //Console.WriteLine("Initial tie...");
                //Console.WriteLine("P1: {0} - {1}", p1score, p1hand.ToString());
                //Console.WriteLine("P2: {0} - {1}", p2score, p2hand.ToString());
                //Console.ReadLine();
                p1score = p1hand.getHighCard();
                p2score = p2hand.getHighCard();
                //Console.WriteLine("P1: {0} - {1}", p1score, p1hand.ToString());
                //Console.WriteLine("P2: {0} - {1}", p2score, p2hand.ToString());
                //Console.ReadLine();
            }
            // still?
            if (p1score == p2score)
            {
                throw new Exception("Unexpected tie.");
            }

            //if (p1score >= 500 || p2score >= 500)
            //{
            //    Console.WriteLine("P1: {0} - {1}", p1score, p1hand.ToString());
            //    Console.WriteLine("P2: {0} - {1}", p2score, p2hand.ToString());
            //    Console.ReadLine();
            //}

            // p1 wins.
            if (p1score > p2score)
                return 1;
            // p2 wins.
            return 0;
        }
    }

    enum Suits { Spades, Hearts, Diamonds, Clubs }

    class Card
    {
        public int Value { get; private set; }  // 2..14
        public Suits Suit { get; private set; }

        public Card(string code)
        {
            // e.g. "8C" = 8 of clubs.
            if (code.Length != 2)
                throw new ArgumentException("invalid card code.");
            char val = code[0];
            char suit = code[1];
            
            if (val >= '2' && val <= '9')
                this.Value = (int)val - '0';
            else
            {
                switch (val)
                {
                    case 'T': this.Value = 10; break;
                    case 'J': this.Value = 11; break;
                    case 'Q': this.Value = 12; break;
                    case 'K': this.Value = 13; break;
                    case 'A': this.Value = 14; break;
                    default:
                        throw new ArgumentException("invalid card value.");
                }
            }
            switch (suit)
            {
                case 'S': this.Suit = Suits.Spades; break;
                case 'H': this.Suit = Suits.Hearts; break;
                case 'D': this.Suit = Suits.Diamonds; break;
                case 'C': this.Suit = Suits.Clubs; break;
                default:
                    throw new ArgumentException("invalid card suit.");
            }
        }
        
        public override string ToString()
        {
            string s = "";
            if (this.Value >= 2 && this.Value <= 10)
                s = string.Format("{0}", this.Value);
            else
            {
                switch (this.Value)
                {
                    case 11: s = "Jack"; break;
                    case 12: s = "Queen"; break;
                    case 13: s = "King"; break;
                    case 14: s = "Ace"; break;
                }
            }
            s += string.Format(" of {0}", this.Suit);
            return s;
        }
    }

    class Hand
    {
        private List<Card> cards;

        public Hand()
        {
            cards = new List<Card>(5);
        }

        public void AddCard(Card card)
        {
            if (cards.Count >= 5)
                throw new Exception("Too many cards!");
            cards.Add(card);
        }

        public void AddCard(string sCard)
        {
            Card card = new Card(sCard);
            this.AddCard(card);
        }

        public override string ToString()
        {
            return string.Join(", ", cards.Select(x => x.ToString()));
        }

        public int GetHandValue()
        {
            int v;
            if (cards.Count != 5)
                throw new Exception("Hand is not complete.");
            
            if (this.isRoyalFlush())
                return 1000;
            if (this.isStraightFlush())
                return 900;
            v = this.isFourOfAKind();
            if (v > 0)
                return 800 + v;
            v = this.isFullHouse();
            if (v > 0)
                return 700 + v;
            if (this.isFlush())
                return 600;
            if (this.isStraight())
                return 500;
            v = this.isThreeOfAKind();
            if (v > 0)
                return 400 + v;
            v = this.isTwoPair();
            if (v > 0)
                return 300 + v;
            v = this.isOnePair();
            if (v > 0)
                return 200 + v;
            // nothing. just return high card.
            return this.getHighCard();
        }

        public bool isRoyalFlush()
        {
            // Ten, Jack, Queen, King, Ace, in same suit.
            if (!cards.All(x => x.Suit == cards[0].Suit))
                return false;

            int i = 10;
            foreach (Card c in cards.OrderBy(x => x.Value))
                if (c.Value != i++)
                    return false;
            return true;
        }

        public bool isStraightFlush()
        {
            //  All cards are consecutive values of same suit.
            if (!cards.All(x => x.Suit == cards[0].Suit))
                return false;
            int i = cards[0].Value;
            foreach (Card c in cards.OrderBy(x => x.Value))
                if (c.Value != i++)
                    return false;
            return true;
        }

        public int isFourOfAKind()
        {
            // Four cards of the same value.
            var q = cards.GroupBy(x => x.Value).Where(x => x.Count() == 4).OrderByDescending(x => x.Key);
            if (q.Any())
                return q.First().Key;
            else
                return 0;
            //return cards.GroupBy(x => x.Value).Select(x => x.Count()).Max() >= 4;
        }

        public int isFullHouse()
        {
            // Three of a kind and a pair.
            // (Between two full houses, the one with the higher-ranking three cards wins.)
            var q3 = cards.GroupBy(x => x.Value).Where(x => x.Count() == 3);
            var q2 = cards.GroupBy(x => x.Value).Where(x => x.Count() == 2);
            if (q3.Any() && q2.Any())
                return q3.First().Key;
            return 0;
        }

        public bool isFlush()
        {
            // All cards of the same suit.
            return cards.All(x => x.Suit == cards[0].Suit);
        }

        public bool isStraight()
        {
            // All cards are consecutive values.
            int i = cards.Min(x => x.Value);
                //cards[0].Value;
            foreach (Card c in cards.OrderBy(x => x.Value))
                if (c.Value != i++)
                    return false;
            return true;

        }
        
        public int isThreeOfAKind()
        {
            // Three cards of the same value.
            var q = cards.GroupBy(x => x.Value).Where(x => x.Count() >= 3).OrderByDescending(x => x.Key);
            if (q.Any())
                return q.First().Key;
            else
                return 0;
            //return cards.GroupBy(x => x.Value).Select(x => x.Count()).Max() >= 3;
        }

        public int isTwoPair()
        {
            // Two different pairs. (higher pair wins.)
            int va, vb;
            var q2a = cards.GroupBy(x => x.Value).Where(x => x.Count() == 2);
            if (!q2a.Any())
                return 0;
            va = q2a.First().Key;

            var q2b = cards.Where(x => x.Value != va).GroupBy(x => x.Value).Where(x => x.Count() == 2);
            if (!q2b.Any())
                return 0;
            vb = q2b.First().Key;
            return Math.Max(va, vb);
        }
        
        public int isOnePair()
        {
            // Two cards of the same value.
            var q2a = cards.GroupBy(x => x.Value).Where(x => x.Count() == 2);
            if (!q2a.Any())
                return 0;
            return q2a.First().Key;
        }

        public int getHighCard()
        {
            return cards.Max(x => x.Value);
        }

    }

}
