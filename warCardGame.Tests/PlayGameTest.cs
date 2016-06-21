using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using warCardGame.Classes;
using System.Linq;

namespace warCardGame.Tests
{
    [TestClass]
    public class PlayGameTest
    {
        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void PlayerLosesHandWhenExpectedTest()
        {
            //3 > 2
            Random random = new Random();
            Hand justHand = new Hand(Hand.generateRandom(26, random));

            var playerOneCards = new Queue<Card>();
            playerOneCards.Enqueue(new Card(2,1));

            Hand playerOneHand = new Hand(playerOneCards);

            var playerTwoCards = new Queue<Card>();
            playerTwoCards.Enqueue(new Card(3,1));
            Hand playerTwoHand = new Hand(playerTwoCards);

            HandResult result = justHand.PlayGame(playerOneHand, playerTwoHand);

            Assert.AreEqual(false, result.DidPlayerWin);
        }

        [TestMethod]
        public void PlayerWinsHandWhenExpectedTest()
        {
            //3 > 2
            Random random = new Random();
            Hand justHand = new Hand(Hand.generateRandom(26, random));

            var playerOneCards = new Queue<Card>();
            playerOneCards.Enqueue(new Card(3,1));

            Hand playerOneHand = new Hand(playerOneCards);

            var playerTwoCards = new Queue<Card>();
            playerTwoCards.Enqueue(new Card(2,1));
            Hand playerTwoHand = new Hand(playerTwoCards);

            HandResult result = justHand.PlayGame(playerOneHand, playerTwoHand);

            Assert.AreEqual(true, result.DidPlayerWin);
        }

        [TestMethod]
        public void PlayerWinsCardsInWarTest()
        {
            //3 == 3, and 11 > 10
            Random random = new Random();
            Hand justHand = new Hand(Hand.generateRandom(26, random));

            var playerOneCards = new Queue<Card>();
            playerOneCards.Enqueue(new Card(3,1));
            playerOneCards.Enqueue(new Card(2,1));
            playerOneCards.Enqueue(new Card(11,1));

            Hand playerOneHand = new Hand(playerOneCards);

            var playerTwoCards = new Queue<Card>();
            playerTwoCards.Enqueue(new Card(3,1));
            playerTwoCards.Enqueue(new Card(12,1));
            playerTwoCards.Enqueue(new Card(10,1));
            Hand playerTwoHand = new Hand(playerTwoCards);

            HandResult result = justHand.PlayGame(playerOneHand, playerTwoHand);

            Queue<Card> expectedWinnerHand = new Queue<Card>();
            expectedWinnerHand.Enqueue(new Card(3, 1));
            expectedWinnerHand.Enqueue(new Card(3, 1));
            expectedWinnerHand.Enqueue(new Card(11, 1));
            expectedWinnerHand.Enqueue(new Card(10, 1));
            expectedWinnerHand.Enqueue(new Card(2, 1));
            expectedWinnerHand.Enqueue(new Card(12, 1));

            CollectionAssert.AreEqual(expectedWinnerHand, result.PlayerOneHand.Cards);
        }

    }
}
