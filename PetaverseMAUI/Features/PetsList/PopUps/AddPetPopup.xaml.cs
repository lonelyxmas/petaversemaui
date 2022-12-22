namespace PetaverseMAUI;

public partial class AddPetPopup
{
    #region [CTor]

    public AddPetPopup(AddPetPopupViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    #endregion

    #region [Event Handlers]
    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        RadioButton button = default;

        if (sender is Image)
        {
            button = ((Image)sender).Parent.Parent as RadioButton;
        }
        else if (sender is VerticalStackLayout)
        {
            button = ((VerticalStackLayout)sender).Parent as RadioButton;
        }
        else if (sender is Label)
        {
            button = ((Label)sender).Parent.Parent as RadioButton;
        }
        button.IsChecked = true;
    }
    #endregion
}