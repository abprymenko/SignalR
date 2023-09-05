namespace Contracts
{
    public interface IHubChat
    {
        Task SendMessage(string username, string message);
    }
}
