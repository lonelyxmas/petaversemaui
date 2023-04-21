namespace PetaverseMAUI;

public partial class BreedDetailModel : BaseModel
{
    [ObservableProperty]
    SpeciesPivotModel species;

    [ObservableProperty]
    string source;

    [ObservableProperty]
    string hairColor;

    [ObservableProperty]
    string hairLength;

    [ObservableProperty]
    WikiPageSizeEnum size;

    [ObservableProperty]
    double weight;

    [ObservableProperty]
    string longevity;

    [ObservableProperty]
    WikiPageSizeEnum energy;

    [ObservableProperty]
    string otherCharacterictics;
}
