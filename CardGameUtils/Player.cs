using System;
using System.Collections.Generic;

namespace CardGameUtils
{
    public class Player
    {
        private HashSet<Card> hand;

        public Player()
        {
            this.hand = new HashSet<Card>();
        }


    }
}
