namespace PetaverseMAUI;

public partial class PetsListPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public PetsListPageViewModel(
        IPetsListService petsListService,
        IAppNavigator appNavigator
        ):base(appNavigator)
    {
        this.petsListService = petsListService;
        this.appNavigator = appNavigator;
    }
    #endregion

    #region [Fields]
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<PetProfileCardModel> fakePetProfileCards;
    #endregion

    #region [Services]

    private readonly IPetsListService petsListService;

    private readonly IAppNavigator appNavigator;
    #endregion

    #region [RelayCommands]
    [RelayCommand]
    Task RefreshAsync() => LoadDataAsync()
                           .ContinueWith(x => IsBusy = false);
    #endregion

    #region [ Methods ]
    private async Task LoadDataAsync()
    {
        if (IsBusy) return;

        IsBusy = true;

        var items = await this.petsListService.GetAll();

        if (FakePetProfileCards == null)
        {
            FakePetProfileCards = new ObservableCollection<PetProfileCardModel>(items);
            return;
        }

        foreach (var item in items)
        {
            FakePetProfileCards.Add(item);
        }

        IsBusy = false;
    }
    #endregion

    #region [Override]
    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        await LoadDataAsync();
    }
    #endregion
}
