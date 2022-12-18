namespace PetaverseMAUI;

public interface IPetsListService
{
    Task<List<PetProfileCardModel>> GetAll();
}
