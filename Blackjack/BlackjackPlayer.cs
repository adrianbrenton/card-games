﻿using System;
using System.Collections.Generic;

using CardGameUtils;

namespace Blackjack
{
    public class BlackjackPlayer: Player
    {
        PlayerStatus status;
        public PlayerStatus Status { get { return status; } }

        uint minHandValue;
        uint handScore; //highest possible hand-value without exceeding targetValue
        uint targetValue; //needed if target-value is variable
        uint numberOfaces; // needed if target-value is variable

        public BlackjackPlayer()
        {
            targetValue = 21;
        }

        public override void ReceiveCard(Card card)
        {
            base.ReceiveCard(card);
            if (card.rank == Rank.Ace) { numberOfaces++; }
            minHandValue += EvaluateCard(card);
            if (minHandValue > targetValue) { status = PlayerStatus.Bust; }
            else { handScore = BestPossibleHandScore(); }
            if (handScore == targetValue) { status = PlayerStatus.OnTarget; }
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
            for (int i = 1; i <= numberOfaces; i++)
            {
                if (score + 10 <= targetValue) { score += 10; }
                else { return score; }
            }
            return score;
        }
    }
}
