namespace PetaverseMAUI;

public partial class WalkthroughPage
{
    private WalkthroughPageViewModel viewModel;
	public WalkthroughPage(WalkthroughPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = viewModel = vm;
	}

    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (Window.Width < 500)
        {

            viewModel.DeviceState = "Phone";
        }
        else if (Window.Width < 900)
        {

            viewModel.DeviceState = "Tablet";
        }
        else if (Window.Width < 2000)
        {

            viewModel.DeviceState = "Desktop";
        }
    }
}