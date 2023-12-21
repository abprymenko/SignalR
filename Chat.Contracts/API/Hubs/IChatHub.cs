namespace Chat.Contracts.API.Hubs
{
    public interface IChatHub
    {
        Task SendMessage(string? username, string? message);
    }
}