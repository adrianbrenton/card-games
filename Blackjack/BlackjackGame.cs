using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CardGameUtils;

namespace Blackjack
{
    public class BlackjackGame
    {
        int numberOfPlayers;
        Deck deck;
        bool gameCompleted;

        List<BlackjackPlayer> players;
        public ReadOnlyCollection<BlackjackPlayer> Players
        {
            get { return new ReadOnlyCollection<BlackjackPlayer>(players); }
        }

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

        /* Attempts to add new connectionId to an unused Player instance in
         * players. Returns true if is successful. Returns false if all Player 
         * instances in players already have a connectionIds. */
        public bool AddNewConnection(string connectionId)
        {
            foreach(BlackjackPlayer player in players)
            {
                if (String.IsNullOrEmpty(player.ConnectionId))
                {
                    player.ConnectionId = connectionId;
                    return true;
                }
            }
            return false;
        }

        public void RemoveConnection(string connectionIdToRemove)
        {
            IEnumerable<BlackjackPlayer> playersWithUnwantedId = 
                players.Where(player => player.ConnectionId == connectionIdToRemove);
            foreach (BlackjackPlayer player in playersWithUnwantedId)
            {
                player.ConnectionId = string.Empty;
            }
        }

        public void 

     
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