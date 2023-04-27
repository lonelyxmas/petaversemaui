namespace petaverse.frontend.mauiapp;

public class PetProfileCardsGroupModel : List<PetProfileCardModel>
{
    public string SpeciesName { get; private set; }

	public PetProfileCardsGroupModel(string speciesName, List<PetProfileCardModel> petProfileCardModels) : base(petProfileCardModels)
	{
		SpeciesName = speciesName;
	}
}
