using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Blackjack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CardGames.Hubs
{
    [Authorize]
    public class BlackjackPVPHub : Hub
    {
        Queue<string> connectionsToJoin = new Queue<string>();
        BlackjackGame game = new BlackjackGame();
        public override async Task OnConnectedAsync()
        {
            //bool addedUserToGroup;
            //foreach (string groupName in groupList)
            connectionsToJoin.Enqueue(Context.ConnectionId);
            AddNextConnectionToGame();
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "joined");
            //await Groups.AddAsync(Context.ConnectionId, roomId);  needed later when we add groups
        }



        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string IdToRemove = Context.ConnectionId;
            if (connectionsToJoin.Contains(IdToRemove))
            {
                /*Removing from Queue is O(n), but it is still worth using a 
                 * queue because this should happen rarely compared to the 
                 * number of enqueue and dequeue calls. Perhaps consider using
                 * LinkedList */
                connectionsToJoin = new Queue<string>(connectionsToJoin.Where(
                    connection => connection != IdToRemove));
            }
            //Remove this Id from BlackjackPlayer Instances.
            game.RemoveConnection(IdToRemove);
        }
		//On pressing the Hit button, clientside calls this method
		public async Task Hit()
        {
            await Clients.Caller.SendAsync("ReceiveCard");

        }

        void AddNextConnectionToGame()
        {
            if (game.AddNewConnection(connectionsToJoin.Peek()))
            {
                connectionsToJoin.Dequeue();
                Debug.WriteLine("Connection added");
            }
            Debug.WriteLine("Could not find unused BlackjackPlayer instance");
        }
    }
}
