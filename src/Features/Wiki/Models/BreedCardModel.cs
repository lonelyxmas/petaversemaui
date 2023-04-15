namespace PetaverseMAUI;

public partial class BreedCardModel : BaseModel
{
    [ObservableProperty]
    string breedName = string.Empty;

    [ObservableProperty]
    string breedDetail;

    [ObservableProperty]
    ImageSource breedImageUrl;

    [ObservableProperty]
    string color;
}
