using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CardGameUtils
{
    public class Deck
    {

        //TODO: method to add card to the deck. Maybe Add(Card card) signature.
        //TODO: consider alternative data structure options
        private List<Card> cards; 
        private RNGCryptoServiceProvider CryptoRNG = new RNGCryptoServiceProvider();
        public Deck()
        {
            this.cards = new List<Card>(); 
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        // modern Fisher-Yates algorithm
        public void Shuffle()
        {
            byte[] randomNumber = new byte[1];
            for (int i = cards.Count - 1; i > 0; i--)
            {
                byte cardsLeft = (byte)(i + 1);
                do
                {
                    CryptoRNG.GetBytes(randomNumber);
                }
                while (!IsFairChoice(randomNumber[0], cardsLeft));
                // Choose position as the random number mod the number
                // of remaining cards.
                byte chosenIndex = (byte)(randomNumber[0] % cardsLeft);
                Card temp = cards[i];
                cards[i] = cards[chosenIndex];
                cards[chosenIndex] = temp;
            }
            }

        //Checks if v%cardsLeft gives an even (uniform) distribution of choices
        private bool IsFairChoice(byte v, int cardsLeft)
        {
            //TODO: Implement IsFairChoice()
            return true;
            throw new NotImplementedException();
        }

        // Removes next card from the deck and returns it to the caller
        public Card DealNext()
        {
            Card nextCard = cards.Last();
            cards.RemoveAt(cards.Count - 1);
            return nextCard;
        }
    }

}
