using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using warCardGame.Models;
using System.Collections.Generic;
using warCardGame.Classes;

namespace warCardGame.Tests
{
    [TestClass]
    public class RandomHandGeneratorTest
    {
        [TestMethod]
        public void ListOfCardsCanBeGeneratedTest()
        {
            Hand myHand = new Hand(Hand.generateRandom(2, new Random()));
            Assert.AreEqual(myHand.Cards.Count, 2);
        }

        [TestMethod]
        public void ListOfTwoCardsGeneratedAreDifferentTest()
        {
            Hand myHand = new Hand(Hand.generateRandom(2, new Random()));
            CollectionAssert.AllItemsAreUnique(myHand.Cards);
        }
    }
}
