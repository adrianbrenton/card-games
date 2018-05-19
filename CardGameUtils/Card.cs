using System;
namespace CardGameUtils
{
    public struct Card
    {
        public Rank rank { get; }
        public Suit suit { get; }

        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

		public override string ToString()
		{
            return rank.ToString() + " of " + suit.ToString();
		}
	}
}
