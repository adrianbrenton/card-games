using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;


namespace CardGameUtils.Tests
{
    public class DeckTests
    {
        private readonly ITestOutputHelper output;

        public DeckTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        //TODO: add and complete tests

        [Fact]
        public void DealNext_NewDeck_ShouldReturnAndRemoveNextCard()
        {
            Deck deck = new Deck();
            HashSet<Card> hand = new HashSet<Card>();
            for (int i = 0; i < 52; i++)
            {
                Card nextCard = deck.DealNext();
                Assert.DoesNotContain(nextCard, hand);
                hand.Add(nextCard);
            }
        }



        /*
         * This test must be rewritten using Deck.DealNext() method.
         * It cannot work in its current form because Deck.cards is private.
         * 
         * [Fact]
        public void Shuffle_NewDeck_ShouldRandomize()
        {
            
            Deck deck = new Deck();
            deck.Shuffle();

            Assert.Equal(1,1);
            foreach (Card card in deck.cards)
            {
                output.WriteLine(card.rank.ToString());
                output.WriteLine(card.suit.ToString());

            }

            Assert.Equal(2, 2);
        }*/
    }
}
