namespace PetaverseMAUI;

public partial class ProfilePageViewModel : NavigationAwareBaseViewModel
{
    public ProfilePageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    [ObservableProperty]
    string phoneNumber;

    [ObservableProperty]
    string currentDeviceState = "Phone";

    [RelayCommand]
    private Task ViewSettings() => AppNavigator.NavigateAsync(AppRoutes.SettingsAndHelp);
}