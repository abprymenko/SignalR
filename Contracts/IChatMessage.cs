namespace Contracts
{
    public interface IChatMessage
    {
        event Action<string, string>? MessageReceived;
        event Func<Exception, Task>? ConnectionClosed;
        Task Connect();
        Task Disconnect();
        Task SendMessage(string? userName, string? message);
    }
}