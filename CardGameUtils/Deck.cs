using System;
using System.Collections.ObjectModel;

namespace CardGameUtils
{
    public class Deck : Collection<Card>
    {
        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    this.Add(new Card(rank, suit));
                }
            }
        }
    }
}
