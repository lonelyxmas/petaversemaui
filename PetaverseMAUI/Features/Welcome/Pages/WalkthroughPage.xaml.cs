namespace PetaverseMAUI;

public partial class WalkthroughPage
{
	public WalkthroughPage(WalkthroughPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}