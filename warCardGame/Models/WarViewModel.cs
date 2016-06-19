using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using warCardGame.Classes;

namespace warCardGame.Models
{
    public class WarViewModel
    {
        public Hand PlayerOneHand;
        public Hand PlayerTwoHand;
//        public List<Card> PlayerOneRecentlyPlayed;
//        public List<Card> PlayerTwoRecentlyPlayed;
        public HandResult RecentResults;

        public WarViewModel()
        {
            Random random = new Random();
            PlayerOneHand = new Hand(Hand.generateRandom(26, random));
            PlayerTwoHand = new Hand(Hand.generateRandom(26, random));

            RecentResults = new HandResult();
        }

        public WarViewModel(HandResult result)
        {
            PlayerOneHand = result.PlayerOneHand;
            PlayerTwoHand = result.PlayerTwoHand;

            RecentResults = result;
        }
    }
}