namespace petaverse.frontend.mauiapp;

public partial class CreatePetPopupSpeciesModel : BaseModel
{
    [ObservableProperty]
    string speciesName;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    string frontEndIcon;

    [ObservableProperty]
    List<CreatePetPopupBreedModel> breeds;
}
