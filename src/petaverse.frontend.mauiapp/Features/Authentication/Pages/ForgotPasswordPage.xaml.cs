namespace petaverse.frontend.mauiapp;

public partial class ForgotPasswordPage
{
    public ForgotPasswordPage(ForgotPasswordPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}