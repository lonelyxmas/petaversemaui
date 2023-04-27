namespace petaverse.frontend.mauiapp;

public partial class UserProfile : BaseModel
{
    #region [ Properties ]

    [ObservableProperty]
    string guid;

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string userName;

    [ObservableProperty]
    string phoneNumber;

    [ObservableProperty]
    string avatarUrl;

    [ObservableProperty]
    string bio;

    [ObservableProperty]
    bool gender;

    [ObservableProperty]
    string countryName;

    [ObservableProperty]
    string city;

    [ObservableProperty]
    string district;

    [ObservableProperty]
    string ward;

    #endregion
}
