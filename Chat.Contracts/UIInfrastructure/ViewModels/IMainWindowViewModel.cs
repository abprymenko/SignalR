namespace Chat.Contracts.UIInfrastructure.ViewModels
{
    public interface IMainWindowViewModel : IBaseViewModel
    {
        string? Message { get; set; }
    }
}