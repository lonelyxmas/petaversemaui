namespace PetaverseMAUI;

public partial class SignInPage
{
    public SignInPage(SignInPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}

