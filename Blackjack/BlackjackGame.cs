using System;
using System.Collections.Generic;

using CardGameUtils;

namespace Blackjack
{
    public class BlackjackGame
    {
        int numberOfPlayers;
        Deck deck;

        List<BlackjackPlayer> players;

        public BlackjackGame(int numberOfPlayers = 3)
        {
            this.numberOfPlayers = numberOfPlayers;
            players = new List<BlackjackPlayer>(numberOfPlayers);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new BlackjackPlayer());
            }
            deck = new Deck();
            deck.Shuffle();

        }

    
        public void PlayOneGame()
        {
            DealHands();
            while(PlayersActive())
            {
                foreach (BlackjackPlayer player in players)
                {
                    if (player.Status == PlayerInGameStatus.Active)
                    {
                        OfferCard(player);
                    }
                }
            }

        }

        void DealHands()
        {
            foreach (BlackjackPlayer player in players)
            {
                player.ReceiveCard(deck.DealNext());
                player.ReceiveCard(deck.DealNext());
            }
        }

        bool PlayersActive()
        {
            foreach (BlackjackPlayer player in players)
            {
                if (player.Status == PlayerInGameStatus.Active)
                {
                    return true;
                }
            }
            return false;
        }

        void OfferCard(BlackjackPlayer player)
        {
            
        }

     
    }
}

/* PLAN:
 * Declare and Instantiate players
 * Create list of players
 * while (not (all players Stuck OR all players OnTarget) )
 * {
 *      currentPlayer = pop a player off the queue
 *      if currentPlayer.Status = PlayerStatus.Active
 *      {
 *          currentPlayer(ReceiveCard(deck.DealNext())
 *      }
 *      
 */