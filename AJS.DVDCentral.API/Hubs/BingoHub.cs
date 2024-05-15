using Microsoft.AspNetCore.SignalR;

namespace AJS.DVDCentral.API.Hubs
{
    public class BingoHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
