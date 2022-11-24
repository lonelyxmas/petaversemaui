namespace PetaverseMAUI;

public partial class WalkthroughPage
{
	public WalkthroughPage(WalkthroughPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        // get screen size
        var disp = DeviceDisplay.Current.MainDisplayInfo;

        System.Diagnostics.Debug.WriteLine(Window.Width);
        System.Diagnostics.Debug.WriteLine(Window.Height);
    }
}