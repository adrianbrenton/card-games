using System;
using Xunit;
using Xunit.Abstractions;
namespace CardGameUtils.Tests
{
    public class PlayerTests
    {
        Card card;
        Player player;

        public PlayerTests()
        {
            player = new Player();
            card = new Card(Rank.Ace, Suit.Spades);
        }

        [Fact]
        public void PlayCard_CardNotInHand_ShouldThrowException()
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => player.PlayCard(card));
            Assert.StartsWith("Chosen card not in hand", exception.Message);



        }

        [Fact]
        public void PlayCard_CardInHand_ShouldRemoveCard(){
            player.ReceiveCard(card);
            Assert.Equal(card, player.PlayCard(card));
            Assert.Throws<ArgumentOutOfRangeException>(() => player.PlayCard(card));
        }
    }
}
