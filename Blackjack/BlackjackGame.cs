using System;
using System.Collections.Generic;

using CardGameUtils;

namespace Blackjack
{
    public class BlackjackGame
    {
        int numberOfPlayers;
        BlackjackPlayer player1;
        BlackjackPlayer player2;
        BlackjackPlayer player3;
        Deck deck;

        List<BlackjackPlayer> players;

        public BlackjackGame()
        {
            numberOfPlayers = 3;
            players = new List<BlackjackPlayer>(numberOfPlayers);
            player1 = new BlackjackPlayer();
            player2 = new BlackjackPlayer();
            player3 = new BlackjackPlayer();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
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
                    if (player.Status == PlayerStatus.Active)
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
                if (player.Status == PlayerStatus.Active)
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