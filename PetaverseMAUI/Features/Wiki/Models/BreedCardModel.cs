namespace PetaverseMAUI;

public partial class BreedCardModel : BaseModel
{
    [ObservableProperty]
    string breedName;

    [ObservableProperty]
    string breedDetail;

    [ObservableProperty]
    string breedImageUrl;

    [ObservableProperty]
    string color;
}
