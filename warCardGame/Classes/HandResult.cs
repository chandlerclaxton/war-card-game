using System.Collections.Generic;

namespace warCardGame.Classes
{
    public class HandResult
    {
        public Hand PlayerOneHand;
        public Hand PlayerTwoHand;
        public Queue<Card> WinnerCards;
        public bool DidPlayerWin;
    }
}