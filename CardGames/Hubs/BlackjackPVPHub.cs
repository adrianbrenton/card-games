using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blackjack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CardGames.Hubs
{
    [Authorize]
    public class BlackjackPVPHub : Hub
    {

        public Queue<string> ConnectionsToJoin = new Queue<string>();
        BlackjackGame game = new BlackjackGame();
        public override async Task OnConnectedAsync()
        {
            //bool addedUserToGroup;
            //foreach (string groupName in groupList)
            {
                string newConnectionId = Context.ConnectionId;
            }
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "joined");
            //await Groups.AddAsync(Context.ConnectionId, roomId);  needed later when we add groups
        }

        //On pressing the Hit button, clientside calls this method
        public async Task Hit()
        {
            await Clients.Caller.SendAsync("ReceiveCard");

        }
    }
}
