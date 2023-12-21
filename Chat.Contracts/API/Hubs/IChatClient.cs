namespace Chat.Contracts.API.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string? username, string? message);
    }
}