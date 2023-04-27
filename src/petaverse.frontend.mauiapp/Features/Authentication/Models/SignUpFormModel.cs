namespace petaverse.frontend.mauiapp;

public partial class SignUpFormModel : BaseFormModel
{
    #region [ Properties ]
    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your user name")]
    [NotifyPropertyChangedFor(nameof(UserNameValid), nameof(UserNameInvalidMessage))]
    string userName = "viet.to@totechs.com.vn";

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your first name")]
    [NotifyPropertyChangedFor(nameof(FirstNameValid), nameof(FirstNameInvalidMessage))]
    string firstName = "Viet";

    [ObservableProperty]
    string? lastName = "To";

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your phone number")]
    [Phone(ErrorMessage = "Please use a valid phone number")]
    [NotifyPropertyChangedFor(nameof(PhoneNumberValid), nameof(PhoneNumberInvalidMessage))]
    string phoneNumber = "0348164682";

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your phone email")]
    [EmailAddress(ErrorMessage = "Please user a valid email address")]
    [NotifyPropertyChangedFor(nameof(EmailValid), nameof(EmailInvalidMessage))]
    string email = "ocgrb.strypeerjason115@gmail.com";

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter a password")]
    [Password(
        IncludesLower = true,
        IncludesNumber = true,
        IncludesSpecial = true,
        IncludesUpper = true,
        MinimumLength = 6,
        ErrorMessage = "Please enter a strong password: from 8 characters, 1 upper, 1 lower, 1 digit, 1 special character"
    )]
    [NotifyPropertyChangedFor(nameof(PasswordValid), nameof(PasswordInvalidMessage))]
    string password = "Welkom112!!@";

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter a confirm password")]
    [FieldCompare(nameof(Password))]
    [NotifyPropertyChangedFor(nameof(ConfirmPasswordValid), nameof(ConfirmPasswordInvalidMessage))]
    string confirmPassword = "Welkom112!!@";
    #endregion

    #region [ Validations ]
    //User Name
    public bool UserNameValid => GetErrors(nameof(UserName)).Any() == false;
    public string UserNameInvalidMessage => GetErrors(nameof(UserName)).FirstOrDefault()?.ErrorMessage;

    partial void OnUserNameChanging(string value)
    {
        ValidateProperty(value, nameof(UserName));
    }

    //First Name
    public bool FirstNameValid => GetErrors(nameof(FirstName)).Any() == false;
    public string FirstNameInvalidMessage => GetErrors(nameof(FirstName)).FirstOrDefault()?.ErrorMessage;

    partial void OnFirstNameChanging(string value)
    {
        ValidateProperty(value, nameof(FirstName));
    }

    //Phone number
    public bool PhoneNumberValid => GetErrors(nameof(PhoneNumber)).Any() == false;
    public string PhoneNumberInvalidMessage => GetErrors(nameof(PhoneNumber)).FirstOrDefault()?.ErrorMessage;

    partial void OnPhoneNumberChanging(string value)
    {
        ValidateProperty(value, nameof(PhoneNumber));
    }

    //Password
    public bool EmailValid => GetErrors(nameof(Email)).Any() == false;
    public string EmailInvalidMessage => GetErrors(nameof(Email)).FirstOrDefault()?.ErrorMessage;

    partial void OnEmailChanging(string value)
    {
        ValidateProperty(value, nameof(Email));
    }

    //Password
    public bool PasswordValid => GetErrors(nameof(Password)).Any() == false;
    public string PasswordInvalidMessage => GetErrors(nameof(Password)).FirstOrDefault()?.ErrorMessage;

    partial void OnPasswordChanging(string value)
    {
        ValidateProperty(value, nameof(Password));
    }
    #endregion

    public bool ConfirmPasswordValid => GetErrors(nameof(ConfirmPassword)).Any() == false;
    public string ConfirmPasswordInvalidMessage => GetErrors(nameof(ConfirmPassword)).FirstOrDefault()?.ErrorMessage;

    partial void OnConfirmPasswordChanging(string value)
    {
        ValidateProperty(value, nameof(ConfirmPassword));
    }

    protected override string[] ValidatableAndSupportPropertyNames => new[]
    {
        nameof(UserName),
        nameof(UserNameValid),
        nameof(UserNameInvalidMessage),

        nameof(FirstName),
        nameof(FirstNameValid),
        nameof(FirstNameInvalidMessage),

        nameof(PhoneNumber),
        nameof(PhoneNumberValid),
        nameof(PhoneNumberInvalidMessage),

        nameof(Password),
        nameof(PasswordValid),
        nameof(PasswordInvalidMessage),

        nameof(ConfirmPassword),
        nameof(ConfirmPasswordValid),
        nameof(ConfirmPasswordInvalidMessage),
    };
}

