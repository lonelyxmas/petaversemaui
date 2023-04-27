namespace petaverse.frontend.mauiapp;

public partial class ProfilePagePhoneModeContentView : ContentView
{
    #region [ Fields ]
    private ProfilePageViewModel _profilePageViewModel { get; set; }
    #endregion

    #region [ CTor ]
    public ProfilePagePhoneModeContentView()
        => InitializeComponent();
    #endregion

    #region [ Event Handlers ]
    private void ContentView_Loaded(object sender, EventArgs e)
       => _profilePageViewModel = this.BindingContext as ProfilePageViewModel;

    private void Logout_Tapped(object sender, EventArgs e)
    {
        _profilePageViewModel.LogoutCommand.Execute(null);
    }
    #endregion

}