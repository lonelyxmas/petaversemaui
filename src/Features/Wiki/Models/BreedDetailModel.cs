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
    string hairLength; //WikiPageCoatEnum

    [ObservableProperty]
    string size; //WikiPageSizeEnum

    [ObservableProperty]
    double weight;

    [ObservableProperty]
    string shedding; //WikiPageSheddingLevel

    [ObservableProperty]
    int longevity;

    [ObservableProperty]
    string energy; //WikiPageEnergyEnum

    [ObservableProperty]
    string otherCharacterictics;
}
