using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace warCardGame.Classes
{
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
}