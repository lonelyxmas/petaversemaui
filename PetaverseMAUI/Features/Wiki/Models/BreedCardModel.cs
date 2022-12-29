namespace PetaverseMAUI;

public partial class BreedCardModel : BaseModel
{
    [ObservableProperty]
    string breedName;

    [ObservableProperty]
    string breedDetail;

    [ObservableProperty]
    ImageSource breedImageUrl;

    [ObservableProperty]
    string color;
}
