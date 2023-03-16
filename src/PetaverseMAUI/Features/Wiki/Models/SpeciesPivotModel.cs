namespace PetaverseMAUI;

public partial class SpeciesPivotModel : BaseModel
{
    [ObservableProperty]
    string speciesName;

    [ObservableProperty]
    string speciesImageUrl;

    [ObservableProperty]
    ObservableCollection<BreedCardModel> breedCards;
}
