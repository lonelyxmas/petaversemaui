namespace petaverse.frontend.mauiapp;

public partial class SignUpPage
{
    #region [ CTor ]
    public SignUpPage(SignUpPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}

