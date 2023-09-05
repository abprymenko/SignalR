namespace Contracts
{
    public interface IChat
    {
        Task ReceiveMessage(string username, string message);
    }
}