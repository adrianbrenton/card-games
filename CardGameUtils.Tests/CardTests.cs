using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace CardGameUtils.Tests
{
    public class CardTests
    {
        [Fact]
        public void ToString_KingOfHearts_ShouldGiveAsString()
        {
            Card card = new Card(Rank.King, Suit.Hearts);
            string expectedString = "King of Hearts";
            Assert.Equal(expectedString, card.ToString());
        }
    }
}
