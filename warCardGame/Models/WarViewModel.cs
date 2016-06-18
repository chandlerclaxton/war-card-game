using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace warCardGame.Models
{
    public class WarViewModel
    {
        public Hand PlayerOneHand;
        public Hand PlayerTwoHand;

        public WarViewModel()
        {
            Random random = new Random();
            PlayerOneHand = new Hand(Hand.generateRandom(1, random));
            PlayerTwoHand = new Hand(Hand.generateRandom(1, random));
        }
    }

    public class Card
    {
        public enum Suit { Hearts, Clubs, Spades, Diamonds };
        //Hacky hack there's no One card
        public enum Value { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
        public int currentValue;
        public int currentSuit;

        public Card(Random random)
        {
            currentSuit = random.Next(0, 3);
            currentValue = random.Next(1, 13);
        }
    }

    public class Hand
    {
        public List<Card> Cards;
        public Card FirstCard;

        public Hand(List<Card> cards)
        {
            Cards = cards;
            FirstCard = cards.First();
        }

        public static List<Card> generateRandom(int sizeOfHand, Random random)
        {
            List <Card> cards = new List<Card>() {};

            for (var i = 0; i < sizeOfHand; i++)
            {
                cards.Add(new Card(random));
            }

            return cards;
        }
    }
}