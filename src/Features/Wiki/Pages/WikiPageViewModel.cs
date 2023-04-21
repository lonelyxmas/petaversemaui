namespace PetaverseMAUI;

public partial class WikiPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IWikiService wikiService;
    #endregion

    #region [CTor]
    public WikiPageViewModel(
        IWikiService wikiService,
        IAppNavigator appNavigator) : base(appNavigator)
    {
        this.wikiService = wikiService;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    List<string> sizeEnum;

    [ObservableProperty]
    List<string> coatEnum;

    [ObservableProperty]
    List<string> sheddingLevelEnum;

    [ObservableProperty]
    List<string> energyEnum;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    bool isSpeciesFrameInfoVisible;

    [ObservableProperty]
    SpeciesPivotModel selectedSpecies;

    [ObservableProperty]
    ObservableCollection<SpeciesPivotModel> species;

    [ObservableProperty]
    ObservableCollection<BreedCardModel> fakeBreedCards;

    [ObservableProperty]
    int span = 1;
    #endregion

    #region [Overrides]
    protected async override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        LoadDataAsync().FireAndForget();
        LoadEnumAsync();

    }
    #endregion

    #region [RelayCommands]
    [RelayCommand]
    private void Refresh() => LoadDataAsync().ContinueWith(x => IsBusy = false)
                                             .FireAndForget();

    [RelayCommand]
    private void NavigateToBreedDetail(BreedCardModel breedCardModel)
                        => AppNavigator.NavigateAsync(AppRoutes.Wiki, args: breedCardModel);
    #endregion

    #region [Methods]
    private async Task LoadDataAsync()
    {
        if (IsBusy) return;

        IsBusy = true;

        if (Species == null)
        {
            Species = new ObservableCollection<SpeciesPivotModel>();
        }

        Species.Clear();

        var items = await wikiService.GetAllSpecies();

        foreach (var item in items)
        {
            Species.Add(item);
        }

        SelectedSpecies = Species.FirstOrDefault();

        IsBusy = false;
    }

    private void LoadEnumAsync()
    {
        SizeEnum = Enum.GetNames(typeof(WikiPageSizeEnum)).ToList();
        CoatEnum = Enum.GetNames(typeof(WikiPageCoatEnum)).ToList();
        SheddingLevelEnum = Enum.GetNames(typeof(WikiPageSheddingLevelEnum)).ToList();
        EnergyEnum = Enum.GetNames(typeof(WikiPageSheddingLevelEnum)).ToList();
    }
    #endregion
}
