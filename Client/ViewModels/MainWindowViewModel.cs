namespace Client.ViewModels
{
    #region Usings
    using Contracts;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    #endregion

    #region MainWindowViewModel
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        #region Private : Fields
        private string? _message;
        private readonly IChatMessage _chatMessage;
        private ObservableCollection<string>? _messages;
        #endregion

        #region Public : Constructor
        public MainWindowViewModel(IChatMessage chatMessage, ISendMessageCommand sendMessageCommand)
        {
            _messages = new ObservableCollection<string>();
            _chatMessage = chatMessage;
            _chatMessage.MessageReceived += ChatMessage_MessageReceived;
            _chatMessage.ConnectionClosed += ChatConnectionClosed;
            SendMessageCommand = sendMessageCommand;
        }
        #endregion

        #region Public : Properties
        public ISendMessageCommand SendMessageCommand { get; set; }
        public string? Message 
        { 
            get => _message; 
            set => SetProperty(ref _message, value); 
        }
        public ObservableCollection<string>? Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }
        #endregion

        #region Protected : Methods
        protected override void OnDispose()
        {
            _chatMessage.Disconnect();
            base.OnDispose();
        }
        #endregion

        #region Private : Methods
        private void ChatMessage_MessageReceived(string userName, string message)
        {
            App.Current.Dispatcher.BeginInvoke(() => 
            {
                Messages?.Add($"{userName} : {message}");
            });
        }
        private async Task ChatConnectionClosed(Exception arg)
        {
            await _chatMessage.Connect()
                              .ContinueWith(task =>
                              {
                                  if (task.Exception != null)
                                  {
                                      ErrorMessage = task.Exception.InnerException?.Message;
                                  }
                              });
        }
        #endregion
    }
    #endregion
}
