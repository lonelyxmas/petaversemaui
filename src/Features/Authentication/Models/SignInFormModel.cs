namespace PetaverseMAUI;

public partial class SignInFormModel : BaseFormModel
{
    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your phone number")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [NotifyPropertyChangedFor(nameof(PhoneNumberValid), nameof(PhoneNumberInvalidMessage))]
    string phoneNumber = "0348164682";

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

    public bool PhoneNumberValid => GetErrors(nameof(PhoneNumber)).Any() == false;
    public string PhoneNumberInvalidMessage => GetErrors(nameof(PhoneNumber)).FirstOrDefault()?.ErrorMessage;

    partial void OnPhoneNumberChanging(string value)
    {
        ValidateProperty(value, nameof(PhoneNumber));
    }

    public bool PasswordValid => GetErrors(nameof(Password)).Any() == false;
    public string PasswordInvalidMessage => GetErrors(nameof(Password)).FirstOrDefault()?.ErrorMessage;

    partial void OnPasswordChanging(string value)
    {
        ValidateProperty(value, nameof(Password));
    }

    protected override string[] ValidatableAndSupportPropertyNames => new[]
    {
        nameof(PhoneNumber),
        nameof(PhoneNumberValid),
        nameof(PhoneNumberInvalidMessage),
        nameof(Password),
        nameof(PasswordValid),
        nameof(PasswordInvalidMessage),
    };
}

