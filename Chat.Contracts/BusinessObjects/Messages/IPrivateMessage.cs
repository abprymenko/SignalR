namespace Chat.Contracts.BusinessObjects.Messages
{
    public interface IPrivateMessage : IMessage
    {
        public string? Username { get; set; }
    }
}