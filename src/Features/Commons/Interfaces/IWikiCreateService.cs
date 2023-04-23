namespace PetaverseMAUI;

public interface IWikiCreateService
{
    Task<List<Breed>> GetBySpeciesTypeAsync(SpeciesType speciesType);
}
