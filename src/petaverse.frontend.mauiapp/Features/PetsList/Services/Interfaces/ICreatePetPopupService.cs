namespace petaverse.frontend.mauiapp;

public interface ICreatePetPopupService
{
    Task<IEnumerable<CreatePetPopupSpeciesModel>> GetSpecies();
}
