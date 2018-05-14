using System;
using System.Collections.Generic;

namespace CardGameUtils
{
    public class Player
    {
        protected HashSet<Card> hand;
        public bool HasTurn { get; set; }

        public Player()
        {
            this.hand = new HashSet<Card>();
        }

        public virtual void ReceiveCard(Card card)
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
