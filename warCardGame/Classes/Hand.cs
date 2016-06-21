using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace warCardGame.Classes
{
    public class Hand
    {
        public Queue<Card> Cards;
        public Card FirstCard;

        public Hand(Queue<Card> cards)
        {
            Cards = cards;
//            FirstCard = cards.Dequeue();
        }

        public static Queue<Card> generateRandom(int sizeOfHand, Random random)
        {
            Queue<Card> cards = new Queue<Card>() { };

            for (var i = 0; i < sizeOfHand; i++)
            {
                cards.Enqueue(new Card(random));
            }

            return cards;
        }

        
    }
}




