namespace PetaverseMAUI;

public partial class SignUpPageViewModel : NavigationAwareBaseViewModel
{
    #region [Ctor]

    public SignUpPageViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        Form = new();
    }

    #endregion

    #region [Properties]

    public SignUpFormModel Form { get; init; }

    #endregion

    #region [Commands]

    [RelayCommand]
    Task SignUpAsync()
    {
        var isValid = Form.IsValid();

        if (!isValid)
        {
            return Task.CompletedTask;
        }

        return AppNavigator.GoBackAsync();
    }

    #endregion
}
