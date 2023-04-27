namespace petaverse.frontend.mauiapp;

public interface IWikiService
{
    Task<IEnumerable<SpeciesPivotModel>> GetAllSpecies();
}
