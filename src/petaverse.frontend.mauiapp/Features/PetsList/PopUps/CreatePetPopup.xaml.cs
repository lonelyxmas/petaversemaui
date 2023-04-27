namespace petaverse.frontend.mauiapp;

public partial class CreatePetPopup
{
    #region [ Fields ]
    private readonly CreatePetPopupViewModel viewModel;
    #endregion

    #region [ CTor ]

    public CreatePetPopup(CreatePetPopupViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }

    #endregion

    #region [ Event Handlers ]
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
        if (button.IsChecked.Equals(true))
        {
            var createPetPopupSpeciesModel = button.Value as CreatePetPopupSpeciesModel;
            if (createPetPopupSpeciesModel is not null)
                viewModel.SelectedPopupSpecies = createPetPopupSpeciesModel;
        }
    }
    #endregion

    //Workaround, stupid framework
    private void PetColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedColors = PetColors.SelectedItems.OfType<Color>().ToList();
        selectedColors.ForEach(color => viewModel.PetSelectedColors.Add(color));
    }
}