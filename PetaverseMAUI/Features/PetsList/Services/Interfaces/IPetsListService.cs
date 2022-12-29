namespace PetaverseMAUI;

public interface IPetsListService
{
    Task<IEnumerable<PetProfileCardModel>> GetAll();
}
