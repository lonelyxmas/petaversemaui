namespace PetaverseMAUI;

public interface IWelcomeService
{
    Task<IEnumerable<WalkthroughItemModel>> GetWalkthroughItemsAsync();
}