using System;
using Xunit;
using Xunit.Abstractions;
namespace CardGameUtils.Tests
{
    public class PlayerTests
    {
        public PlayerTests()
        {

        }

        [Fact]
        public void PlayCard_CardNotInHand_ShouldThrowException()
        {
            Player player = new Player();
            Card card = new Card(Rank.Ace, Suit.Spades);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => player.PlayCard(card));
            Assert.StartsWith("Chosen card not in hand", exception.Message);


        }
    }
}
