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

        public void ReceiveCard(Card card)
        {
            hand.Add(card);
        }

        public Card PlayCard(Card card)
        {
            if (!hand.Remove(card))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(card), "Chosen card not in hand");
            }
            return card;
        }
    }
}