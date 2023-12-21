namespace Chat.Contracts.UIInfrastructure.Commands.Async
{
    #region Usings
    using System.Windows.Input;
    #endregion
    public interface ICommandAsync : ICommand
    {
        bool IsExecuting { get; set; }
        Task ExecuteAsync(object? parameter);
        void OnCanExecuteChanged();
    }
}