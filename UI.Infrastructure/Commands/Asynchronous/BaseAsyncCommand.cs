namespace UI.Infrastructure.Commands.Asynchronous
{
    #region Usings
    using Contracts;
    #endregion

    #region BaseAsyncCommand
    internal abstract class BaseAsyncCommand : IAsyncCommand
    {
        #region Private : Fields
        private bool _isExecuting;
        #endregion

        #region Public : Events
        public virtual event EventHandler? CanExecuteChanged;
        #endregion

        #region Public : Properties
        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }
        #endregion
 
        #region Public : Methods 
        public virtual bool CanExecute(object? parameter) => !IsExecuting;
        public async void Execute(object? parameter)
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
        }
        public virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public abstract Task ExecuteAsync(object? parameter);
        #endregion
    }
    #endregion
}