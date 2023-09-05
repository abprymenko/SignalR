using System.Windows.Input;

namespace Contracts
{
    public interface IAsyncCommand : ICommand
    {
        bool IsExecuting { get; set; }
        Task ExecuteAsync(object? parameter);
        void OnCanExecuteChanged();
    }
}