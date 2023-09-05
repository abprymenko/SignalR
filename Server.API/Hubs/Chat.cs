namespace Server.API.Hubs
{
    #region Usings
    using Microsoft.AspNetCore.SignalR;
    using Contracts;
    #endregion

    #region Chat
    public class Chat : Hub<IChat>, IHubChat
    {
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.ReceiveMessage(username, message);
        }
    }
    #endregion
}