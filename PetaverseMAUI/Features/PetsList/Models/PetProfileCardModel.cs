namespace PetaverseMAUI;

public partial class PetProfileCardModel : BaseModel
{
    [ObservableProperty]
    string name = string.Empty;

    [ObservableProperty]
    string profileUrl = string.Empty;

    [ObservableProperty]
    int mediaCount;

    [ObservableProperty]
    Breed breed;

    [ObservableProperty]
    SpeciesType speciesType;
}

public enum SpeciesType
{
    Cat = 1, Dog = 2, Bird = 3, Fish = 4
}

public partial class Breed : BaseModel
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string color;

    [ObservableProperty]
    string breedUrl;

    [ObservableProperty]
    string breedDescription;
}
