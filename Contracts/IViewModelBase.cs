namespace Contracts
{
    public interface IViewModelBase : IDisposable
    {
        string? Login { get; set; }
        string? ErrorMessage { get; set; }
    }
}