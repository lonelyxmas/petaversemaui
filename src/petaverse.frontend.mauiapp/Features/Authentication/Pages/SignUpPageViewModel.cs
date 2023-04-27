namespace petaverse.frontend.mauiapp;

public partial class SignUpPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IFilePicker _filePicker;
    private readonly IProfileService _profileService;
    private readonly IAuthenticationService _authenticationService;
    #endregion

    #region [ CTor ]
    public SignUpPageViewModel(IAppNavigator appNavigator,
                               IFilePicker filePicker,
                               IProfileService profileService,
                               IAuthenticationService authenticationService)
                               : base(appNavigator)
    {
        Form = new();

        _filePicker = filePicker;
        _profileService = profileService;
        _authenticationService = authenticationService;
    }

    #endregion

    #region [ Properties ]

    [ObservableProperty]
    FileResult file;

    [ObservableProperty]
    ImageSource avatarImageSource;
    public SignUpFormModel Form { get; init; }

    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    async Task SignUpAsync()
    {
        await _authenticationService.SignUp(Form.PhoneNumber,
                                            Form.UserName,
                                            Form.Email,
                                            Form.ConfirmPassword,
                                            Form.FirstName,
                                            Form.LastName,
                                            File);
    }


    [RelayCommand]
    private async Task OpenFileAsync()
    {
        File = await _filePicker.OpenMediaPickerAsync();
        var imagefile = await _filePicker.UploadImageFile(File);
        AvatarImageSource = ImageSource.FromStream(() =>
            _filePicker.ByteArrayToStream(_filePicker.StringToByteBase64(imagefile?.byteBase64))
        );
    }

    #endregion
}

