using CommunityToolkit.Diagnostics;

namespace petaverse.frontend.mauiapp;

public partial class SignInPageViewModel : BaseViewModel
{
    #region [ Fields ]

    private readonly IFilePicker filePicker;
    private readonly IProfileService _profileService;
    private readonly IAuthenticationService _authenticationService;
    #endregion

    #region [ CTor ]

    public SignInPageViewModel(IAppNavigator appNavigator,
                               IProfileService profileService,
                               IAuthenticationService authenticationService)
                        : base(appNavigator)
    {
        _profileService = profileService;
        _authenticationService = authenticationService;

        Form = new();
    }

    #endregion

    #region [ Properties ]

    public SignInFormModel Form { get; init; }

    #endregion

    #region [ Relay Commands ]


    [RelayCommand]
    Task SignUpAsync() => AppNavigator.NavigateAsync(AppRoutes.SignUp);

    [RelayCommand]
    Task ForgotPasswordAsync() => AppNavigator.NavigateAsync(AppRoutes.ForgotPassword);

    [RelayCommand]
    Task SignInWithSocialAccountAsync(SocialAccountType socialAccountType)
    {
        return GoHomeAsync(null);
    }

    [RelayCommand]
    async Task SignInAsync()
    {
        var isValid = Form.IsValid();

        if (!isValid)
        {
            await AppNavigator.ShowSnackbarAsync(Form.PasswordInvalidMessage);
        }
        else
        {
            await _authenticationService.AuthenticateWithPhoneNumber(Form.PhoneNumber, Form.Password);

            var userInfo = await _profileService.GetCurrentUser();

            if (userInfo is null)
                await AppNavigator.ShowSnackbarAsync("User is not exist");
            else
                await GoHomeAsync(userInfo);
        }
    }

    #endregion
    Task GoHomeAsync(UserProfile userProfile)
    {
        Guard.IsNotNull(userProfile);
        return AppNavigator.NavigateAsync(AppRoutes.Profile, true, userProfile);
    }
}
