using System;
using Xunit;

using CardGameUtils;

namespace Blackjack.Tests
{
    public class BlackjackPlayerTests
    {
        [Fact]
        public void ReceiveCard_BlackjackHand_ShouldCauseStatusOnTarget()
        {
            BlackjackPlayer player = new BlackjackPlayer();
            player.ReceiveCard(new Card(Rank.King, Suit.Hearts));
            player.ReceiveCard(new Card(Rank.Ace, Suit.Spades));
            Assert.Equal(PlayerStatus.OnTarget, player.Status);
        }

        [Fact]
        public void ReceiveCard_SoftSeventeen_ShouldCauseStatusActive()
        {
            BlackjackPlayer player = new BlackjackPlayer();
            player.ReceiveCard(new Card(Rank.Ace, Suit.Hearts));
            player.ReceiveCard(new Card(Rank.Six, Suit.Diamonds));
            Assert.Equal(PlayerStatus.Active, player.Status);
        }

        [Fact]
        public void ReceiveCard_ThreeKings_ShouldCauseStatusBust()
        {
            BlackjackPlayer player = new BlackjackPlayer();
            player.ReceiveCard(new Card(Rank.King, Suit.Hearts));
            player.ReceiveCard(new Card(Rank.King, Suit.Diamonds));
            player.ReceiveCard(new Card(Rank.King, Suit.Spades));
            Assert.Equal(PlayerStatus.Bust, player.Status);
        }
    }
}
