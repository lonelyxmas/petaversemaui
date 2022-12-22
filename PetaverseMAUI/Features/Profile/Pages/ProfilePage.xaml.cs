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
            if(viewModel is not null)
                viewModel.CurrentDeviceState = "Phone";
        }else if(Window.Width < 900)
        {
            if (viewModel is not null)
                viewModel.CurrentDeviceState = "Tablet";
        }else if (Window.Width < 2000)
        {
            if (viewModel is not null)
                viewModel.CurrentDeviceState = "Desktop";
        }
    }
}