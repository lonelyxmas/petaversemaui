namespace PetaverseMAUI;

public partial class ProfilePage
{
    #region [Fields]
    private ProfilePageViewModel viewModel;
    #endregion

    #region [CTor]
    public ProfilePage(ProfilePageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion

    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if(Window.Width < 500)
        {
            viewModel.CurrentDeviceState = "Phone";
        }else if(Window.Width < 900)
        {
            viewModel.CurrentDeviceState = "Tablet";
        }else if (Window.Width < 2000)
        {
            viewModel.CurrentDeviceState = "Desktop";
        }
    }
}