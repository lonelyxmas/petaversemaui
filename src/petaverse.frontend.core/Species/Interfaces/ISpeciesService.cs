namespace petaverse.frontend.core;

public interface ISpeciesService
{
    Task<IEnumerable<Species>> GetSpecies();

    Task<Species> GetSpeciesById(string speciesId);
}
