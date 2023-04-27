namespace petaverse.frontend.mauiapp;

public interface IPetsListService
{
    Task<IEnumerable<PetProfileCardModel>> GetAll();
}
