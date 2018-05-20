using System;
using System.Collections.Generic;

using CardGameUtils;

namespace Blackjack
{
    public class BlackjackPlayer: Player
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        PlayerInGameStatus status;
        public PlayerInGameStatus Status { get { return status; } }

        uint minHandValue;
        uint handScore; //highest possible hand-value without exceeding targetValue
        readonly uint targetValue;
        uint numberOfAces; // needed if target-value is variable

        public BlackjackPlayer()
        {
            targetValue = 21;
        }

        public override void ReceiveCard(Card card)
        {
            base.ReceiveCard(card);
            if (card.rank == Rank.Ace) { numberOfAces++; }
            minHandValue += EvaluateCard(card);
            if (minHandValue > targetValue) { status = PlayerInGameStatus.Bust; }
            else { handScore = BestPossibleHandScore(); }
            if (handScore == targetValue) { status = PlayerInGameStatus.OnTarget; }
        }

        uint EvaluateCard(Card card)
        {
            if ((uint)card.rank > 10)
            {
                return 10;
            }
            return (uint)card.rank;
        }

        /* This can be done much more simply if targetValue is always 21 like in
         * the usual casino version of Blackjack. However, this is not always
         * the case for this version of the game */
        uint BestPossibleHandScore()
        {
            uint score = minHandValue;
            for (int i = 1; i <= numberOfAces; i++)
            {
                if (score + 10 <= targetValue) { score += 10; }
                else { return score; }
            }
            return score;
        }
    }
}
