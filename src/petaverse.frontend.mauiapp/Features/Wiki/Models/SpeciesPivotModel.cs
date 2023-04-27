namespace petaverse.frontend.mauiapp;

public partial class SpeciesPivotModel : BaseModel
{
    [ObservableProperty]
    string speciesId;

    [ObservableProperty]
    string speciesName;

    [ObservableProperty]
    string speciesImageUrl;

    [ObservableProperty]
    List<BreedCardModel> breedCards;

    public SpeciesPivotModel Clone()
      => new SpeciesPivotModel
      {
          speciesId = SpeciesId,
          speciesName = SpeciesName,
          speciesImageUrl = SpeciesImageUrl,
          breedCards = new List<BreedCardModel>(BreedCards)
      };

}
