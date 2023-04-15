namespace PetaverseMAUI;

public partial class ProfilePageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public ProfilePageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        UserProfile = query.GetData<UserProfile>();
    }
    #endregion

    #region [ Observable Properties ]

    [ObservableProperty]
    string currentDeviceState;

    [ObservableProperty]
    UserProfile userProfile;
    #endregion


    #region [ Relay Commands ]
    [RelayCommand]
    Task Logout() => AppNavigator.NavigateAsync(AppRoutes.SignIn);

    [RelayCommand]
    Task ViewSettings() => AppNavigator.NavigateAsync(AppRoutes.SettingsAndHelp);
    #endregion
}