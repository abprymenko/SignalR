namespace Services.Messages
{
    #region Usings
    using Contracts;
    using Microsoft.AspNetCore.SignalR.Client;
    #endregion

    #region ChatMessage
    internal class ChatMessage : IChatMessage
    {
        #region Private : Fields
        private readonly HubConnection _connection;
        #endregion

        #region Public : Events
        public event Action<string, string>? MessageReceived;
        public event Func<Exception, Task>? ConnectionClosed;
        #endregion

        #region Public : Constructor
        public ChatMessage(HubConnection connection)
        {
            _connection = connection;
            _connection.Closed += OnConnectionClosed;
            _connection.On<string, string>(nameof(IChat.ReceiveMessage), (user, message) => MessageReceived?.Invoke(user, message));
        }
        #endregion

        #region The explicit interface declaration
        async Task IChatMessage.Connect()
        {
            try
            {
                if (_connection.State != HubConnectionState.Connected)
                    await _connection.StartAsync();
                if (_connection.State != HubConnectionState.Connected)
                    throw new Exception("No connection with the hub!");
            }
            catch (Exception)
            {
                throw;
            }
        }
        async Task IChatMessage.Disconnect()
        {
            try
            {
                if (_connection.State == HubConnectionState.Connected)
                    await _connection.StopAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        async Task IChatMessage.SendMessage(string? userName, string? message)
        {
            try
            {
                await _connection.InvokeAsync(nameof(IHubChat.SendMessage), userName, message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Private : Methods
        private Task OnConnectionClosed(Exception? arg)
        {
            ConnectionClosed?.Invoke(arg);
            return Task.CompletedTask;
        }
        #endregion
    }
    #endregion
}