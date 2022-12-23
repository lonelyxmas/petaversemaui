namespace PetaverseMAUI;

public interface IWikiService
{
    Task<List<BreedCardModel>> GetAll();
}
