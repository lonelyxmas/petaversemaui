namespace PetaverseMAUI;

public partial class AddPetPopup
{
    #region [ Fields ]
    private readonly AddPetPopupViewModel viewModel;
    #endregion

    #region [CTor]
    public AddPetPopup(AddPetPopupViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion

    #region [Event Handlers]
    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
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
        if (button.IsChecked.Equals(true))
        {
            if (button.Value.Equals(SpeciesType.Cat.ToString()))
            {
                viewModel.SelectedSpecies = SpeciesType.Cat;
            }
            if (button.Value.Equals(SpeciesType.Dog.ToString()))
            {
                viewModel.SelectedSpecies = SpeciesType.Dog;
            }
            await viewModel.OnAppearingAsync();
        }
    }
    #endregion
}