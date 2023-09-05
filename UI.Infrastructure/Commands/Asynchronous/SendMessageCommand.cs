namespace UI.Infrastructure.Commands.Asynchronous
{
    #region Usings
    using Contracts;
    #endregion

    #region SendMessageCommand
    internal class SendMessageCommand : BaseAsyncCommand, ISendMessageCommand
    {
        #region Private : Fields
        private readonly IChatMessage _message;
        private IMainWindowViewModel? _viewModel;
        #endregion

        #region Public : Constructor
        public SendMessageCommand(IChatMessage message) 
        {
            _message = message;
        }
        #endregion

        #region Public : Methods
        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                if (parameter is IMainWindowViewModel viewModel && viewModel != null)
                {
                    _viewModel = viewModel;
                    await _message.SendMessage(_viewModel.Login, _viewModel.Message);
                    _viewModel.ErrorMessage = null;
                }
            }
            catch (Exception ex)
            {
                if(_viewModel != null)
                    _viewModel.ErrorMessage = ex.Message;
            }
        }
        #endregion
    }
    #endregion
}