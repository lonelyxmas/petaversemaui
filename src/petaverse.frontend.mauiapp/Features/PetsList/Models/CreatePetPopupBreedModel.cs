namespace petaverse.frontend.mauiapp;

public partial class CreatePetPopupBreedModel : BaseModel
{
    [ObservableProperty]
    string breedName;

    [ObservableProperty]
    string breedDescription;

    [ObservableProperty]
    string colors;
}
