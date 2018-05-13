using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class BlackjackGame
    {
        int numberOfPlayers;
        BlackjackPlayer player1;
        BlackjackPlayer player2;
        BlackjackPlayer player3;

        Queue<BlackjackPlayer> players;

        public BlackjackGame()
        {
            numberOfPlayers = 3;
            players = new Queue<BlackjackPlayer>(numberOfPlayers);
            player1 = new BlackjackPlayer();
            player2 = new BlackjackPlayer();
            player3 = new BlackjackPlayer();
            players.Enqueue(player1);
            players.Enqueue(player2);
            players.Enqueue(player3);

        }

    
        public void PlayRound()
        {
            

        }

        private  void DealHands()
        {
            
        }
    }
}

/* PLAN:
 * Declare and Instantiate players
 * Create queue of players
 * while (not (all players Stuck OR all players OnTarget) )
 * {
 *      currentPlayer = pop a player off the queue
 *      if currentPlayer.Status = PlayerStatus.Active
 *      {
 *          currentPlayer(ReceiveCard(deck.DealNext())
 *      }
 *      
 */