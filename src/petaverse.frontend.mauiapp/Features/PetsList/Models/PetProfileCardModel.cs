namespace petaverse.frontend.mauiapp;

public partial class PetProfileCardModel : BaseModel
{
    [ObservableProperty]
    string name = string.Empty;

    [ObservableProperty]
    string profileUrl = string.Empty;

    [ObservableProperty]
    string bio = string.Empty;

    [ObservableProperty]
    string petColors;

    [ObservableProperty]
    string sixDigitCode = string.Empty;

    [ObservableProperty]
    int mediaCount;

    [ObservableProperty]
    Breed breed;

    [ObservableProperty]
    string breedName;

    [ObservableProperty]
    string breedColors;

    [ObservableProperty]
    string breedDescription;

    [ObservableProperty]
    string speciesName;

    [ObservableProperty]
    string speciesDescription;

    [ObservableProperty]
    SpeciesType speciesType;
}

public enum SpeciesType
{
    Cat = 1, Dog = 2, Bird = 3, Fish = 4
}