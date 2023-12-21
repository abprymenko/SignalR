namespace Chat.Contracts.Services.Handlers
{
    public interface IMessageHandler
    {
        event Action<string, string>? MessageReceived;
        Task HandleMessage(string? username, string? message);
    }
}