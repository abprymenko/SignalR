namespace Chat.Contracts.UIInfrastructure.ViewModels
{
    public interface IBaseViewModel : IDisposable
    {
        string? Login { get; set; }
        string? ErrorMessage { get; set; }
    }
}