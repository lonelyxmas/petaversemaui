namespace PetaverseMAUI;

public partial class SignInPage
{
    #region [ CTor ]
    public SignInPage(SignInPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}

