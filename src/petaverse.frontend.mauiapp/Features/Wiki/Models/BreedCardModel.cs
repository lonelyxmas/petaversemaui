namespace petaverse.frontend.mauiapp;

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

    [ObservableProperty]
    WikiPageCoatEnum coat;

    [ObservableProperty]
    WikiPageEnergyEnum energy;

    [ObservableProperty]
    WikiPageSheddingLevelEnum sheddingLevel;

    [ObservableProperty]
    WikiPageSizeEnum size;
}
