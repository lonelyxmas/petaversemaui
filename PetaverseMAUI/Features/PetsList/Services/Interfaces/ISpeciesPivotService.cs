namespace PetaverseMAUI;

public interface ISpeciesPivotService
{
    Task<List<SpeciesPivotModel>> GetAllSpecies();
}
