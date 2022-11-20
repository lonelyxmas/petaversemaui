namespace PetaverseMAUI;

public partial class WelcomePage
{
	public WelcomePage(WelcomePageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}