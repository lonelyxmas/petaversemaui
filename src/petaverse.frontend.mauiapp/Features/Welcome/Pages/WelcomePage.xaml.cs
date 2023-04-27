namespace petaverse.frontend.mauiapp;

public partial class WelcomePage
{
	public WelcomePage(WelcomePageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}