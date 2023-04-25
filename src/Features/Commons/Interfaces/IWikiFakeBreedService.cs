namespace PetaverseMAUI;

public interface IWikiFakeBreedService
{
    Task<List<Breed>> GetBySpeciesTypeAsync(SpeciesType speciesType);

    Task<Breed> GetByIdAsync(int key);

    Task<List<Breed>> GetAll();
}
