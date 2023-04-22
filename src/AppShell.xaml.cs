namespace PetaverseMAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //Routing.RegisterRoute("wiki", typeof(WikiPage));
        //Routing.RegisterRoute("signUp", typeof(SignUpPage));
        //Routing.RegisterRoute("forgotPassword", typeof(ForgotPasswordPage));
        //Routing.RegisterRoute("petDetailProfile", typeof(PetDetailProfilePage));
    }
    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
