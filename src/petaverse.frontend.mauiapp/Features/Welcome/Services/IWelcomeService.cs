namespace petaverse.frontend.mauiapp;

public interface IWelcomeService
{
    Task<IEnumerable<WalkthroughItemModel>> GetWalkthroughItemsAsync();
}