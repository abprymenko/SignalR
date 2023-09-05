namespace Client.ViewModels
{
    #region Usings
    using Contracts;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    #region ViewModelBase
    public class ViewModelBase : IViewModelBase, INotifyPropertyChanged
    {
        #region Private : Fields
        private string? _login;
        private string? _errorMessage;
        #endregion

        #region Public : Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Public : Properties
        public string? Login 
        { 
            get => _login; 
            set => SetProperty(ref _login, value); 
        }
        public string? ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }
        #endregion

        #region Protected : Methods
        protected void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string? propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }
        protected virtual void OnDispose()
        { 
        }
        #endregion

        #region The explicit interface declaration
        void IDisposable.Dispose()
        {
            OnDispose();
        }
        #endregion
    }
    #endregion
}