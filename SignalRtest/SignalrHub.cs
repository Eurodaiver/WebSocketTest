using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRtest
{
    public class SignalrHub : Hub
    {
        public async Task Send(string message, string userName)
        {
            string connId = Context.ConnectionId;
            string userId = Context.UserIdentifier;
            await Clients.All.SendAsync("Send", message + " - " + connId + " - " + userId, userName);
            //await Clients.Client(Context.)
        }

        public override async Task OnConnectedAsync()
        {
            await this.Clients.All.SendAsync("Send", "У нас новое соединение Id - " + Context.ConnectionId, "Сервер мессангер");

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
           await this.Clients.All.SendAsync("Send", Context.ConnectionId + " отсоединился", "Сервер мессангер");
            
        }
    }

}
