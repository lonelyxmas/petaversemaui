namespace PetaverseMAUI;

public partial class SignInPageViewModel : BaseViewModel
{
    #region [ Ctor ]

    public SignInPageViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        Form = new();
    }

    #endregion

    #region [ Properties ]

    public SignInFormModel Form { get; init; }

    #endregion

    #region [ Commands ]


    [RelayCommand]
    Task SignUpAsync() => AppNavigator.NavigateAsync(AppRoutes.SignUp);

    [RelayCommand]
    Task ForgotPasswordAsync() => AppNavigator.NavigateAsync(AppRoutes.ForgotPassword);

    [RelayCommand]
    Task SignInWithSocialAccountAsync(SocialAccountType socialAccountType)
    {
        return GoHomeAsync();
    }

    [RelayCommand]
    Task SignInAsync()
    {
        var isValid = Form.IsValid();

        if (!isValid)
        {
            return Task.CompletedTask;
        }

        return GoHomeAsync();
    }

    #endregion


    Task GoHomeAsync() => AppNavigator.NavigateAsync(AppRoutes.PetsProfile);
}
