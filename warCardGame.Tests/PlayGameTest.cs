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
        private GameService _service;
        private Queue<Card> _playerOneCards;
        private Queue<Card> _playerTwoCards;

        [TestInitialize]
        public void Setup()
        {
            _service = new GameService();
            _playerOneCards = new Queue<Card>();
            _playerTwoCards = new Queue<Card>();
        }

        [TestMethod]
        public void PlayerLosesHandWhenExpectedTest()
        {
            //3 > 2
            _playerOneCards.Enqueue(new Card(2,1));
            Hand playerOneHand = new Hand(_playerOneCards);

            _playerTwoCards.Enqueue(new Card(3,1));
            Hand playerTwoHand = new Hand(_playerTwoCards);

            HandResult result = _service.PlayGame(playerOneHand, playerTwoHand);

            Assert.AreEqual(false, result.DidPlayerWin);
        }

        [TestMethod]
        public void PlayerWinsHandWhenExpectedTest()
        {
            //3 > 2
            _playerOneCards.Enqueue(new Card(3,1));

            Hand playerOneHand = new Hand(_playerOneCards);

            _playerTwoCards.Enqueue(new Card(2,1));
            Hand playerTwoHand = new Hand(_playerTwoCards);

            HandResult result = _service.PlayGame(playerOneHand, playerTwoHand);

            Assert.AreEqual(true, result.DidPlayerWin);
        }

        [TestMethod]
        public void PlayerWinsCardsInWarTest()
        {
            //3 == 3, and 11 > 10
            _playerOneCards.Enqueue(new Card(3,1));
            _playerOneCards.Enqueue(new Card(2,1));
            _playerOneCards.Enqueue(new Card(11,1));
            Hand playerOneHand = new Hand(_playerOneCards);

            _playerTwoCards.Enqueue(new Card(3,1));
            _playerTwoCards.Enqueue(new Card(12,1));
            _playerTwoCards.Enqueue(new Card(10,1));
            Hand playerTwoHand = new Hand(_playerTwoCards);

            HandResult result = _service.PlayGame(playerOneHand, playerTwoHand);

            Queue<Card> expectedWinnerHand = new Queue<Card>();

            //This queue is explicitly too specific, since the rules of war
            //do not necessitate that the won cards need to be in a specific order
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
