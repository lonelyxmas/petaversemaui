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
    }
    #endregion

    #region [Fields]
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<PetProfileCardsGroupModel> fakePetProfileCards;
    #endregion

    #region [Services]

    private readonly IPetsListService petsListService;
    #endregion

    #region [RelayCommands]
    [RelayCommand]
    private void Refresh() => LoadDataAsync()
                                .ContinueWith(x => IsBusy = false)
                                .FireAndForget();

    [RelayCommand]
    private void NavigateToProfileDetail(PetProfileCardModel petProfileCardModel)
                            => AppNavigator.NavigateAsync(AppRoutes.PetDetailProfile, args: petProfileCardModel);

    [RelayCommand]
    private Task AddPetAsync() => AppNavigator.NavigateAsync(AppRoutes.AddPetPopup);
    #endregion

    #region [Methods]
    private async Task LoadDataAsync()
    {
        IsBusy = true;

        var items = await this.petsListService.GetAll();

        if (FakePetProfileCards == null)
        {
            FakePetProfileCards = new ObservableCollection<PetProfileCardsGroupModel>();
            return;
        }

        foreach (var item in items)
        {
            if (!FakePetProfileCards.SelectMany(x => x).Any(y => y.SpeciesType == item.SpeciesType))
            {
                FakePetProfileCards.Add(new PetProfileCardsGroupModel(item.SpeciesType.ToString(),
                                                                      items.Where(x => x.SpeciesType == item.SpeciesType).ToList()));
            };
        }

        IsBusy = false;
    }
    #endregion

    #region [Overrides]
    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        LoadDataAsync().FireAndForget();
    }
    #endregion
}
