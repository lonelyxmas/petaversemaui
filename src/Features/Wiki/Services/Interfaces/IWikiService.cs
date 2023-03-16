namespace PetaverseMAUI;

public interface IWikiService
{
    Task<IEnumerable<SpeciesPivotModel>> GetAllSpecies();
}
