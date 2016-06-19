﻿using System;
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

        public Hand()
        {
            throw new NotImplementedException();
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

        public HandResult PlayGame(Hand handOne, Hand handtwo)
        {
            Card playerOneTopCard = handOne.Cards.Peek();
            Card playerTwoTopCard = handtwo.Cards.Peek();
            HandResult result;
            Queue<Card> winnerCards = new Queue<Card>();

            if (playerOneTopCard.currentValue > playerTwoTopCard.currentValue)
            {
                handOne.Cards.Enqueue(playerTwoTopCard);
                winnerCards.Enqueue(playerTwoTopCard);
                result = new HandResult()
                {
                    DidPlayerWin = true,
                    PlayerOneHand = handOne,
                    PlayerTwoHand = handtwo,
                    WinnerCards = winnerCards
                };
            }
            else if (playerOneTopCard.currentValue < playerTwoTopCard.currentValue)
            {
                handtwo.Cards.Enqueue(playerOneTopCard);
                winnerCards.Enqueue(playerOneTopCard);
                result = new HandResult()
                {
                    DidPlayerWin = false,
                    PlayerOneHand = handOne,
                    PlayerTwoHand = handtwo,
                    WinnerCards = winnerCards
                };
            }
            else
            {
                result = _startAWar(handOne, handtwo);
            }

            return result;
        }

        private HandResult _startAWar(Hand playerOneHand, Hand playerTwoHand)
        {
            Queue<Card> winnerCards = new Queue<Card>();
            bool didPlayerWin = false;
            bool warIsNotOver = true;
            while (warIsNotOver)
            {
                Card playerOneTopCard = playerOneHand.Cards.Dequeue();
                Card playerTwoTopCard = playerTwoHand.Cards.Dequeue();
                Card playerOneHiddenCard = playerOneHand.Cards.Dequeue();
                Card playerTwoHiddenCard = playerTwoHand.Cards.Dequeue();

                //Put the facedown and face up cards into a winner's pile
                winnerCards.Enqueue(playerOneTopCard);
                winnerCards.Enqueue(playerTwoTopCard);
                winnerCards.Enqueue(playerOneHiddenCard);
                winnerCards.Enqueue(playerTwoHiddenCard);

                if (playerOneTopCard.currentValue > playerTwoTopCard.currentValue)
                {
                    didPlayerWin = true;
                    warIsNotOver = false;
                }
                else if (playerOneTopCard.currentValue < playerTwoTopCard.currentValue)
                {
                    warIsNotOver = false;
                }
                else
                {
                    //It was a tie, go again until it stops
                }
            }

            _putCardsOnBottom(winnerCards, didPlayerWin ? playerOneHand : playerTwoHand);

            return new HandResult()
            {
                DidPlayerWin = didPlayerWin,
                PlayerOneHand = playerOneHand,
                PlayerTwoHand = playerTwoHand,
                WinnerCards = winnerCards
            };
        }

        private Hand _putCardsOnBottom(Queue<Card> winnerCards, Hand hand)
        {
            foreach (Card card in winnerCards)
            {
                hand.Cards.Enqueue(card);
            }
            return hand;
        }
    }
}




