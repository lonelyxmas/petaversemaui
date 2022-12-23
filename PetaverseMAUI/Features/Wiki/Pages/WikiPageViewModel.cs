namespace PetaverseMAUI;

public partial class WikiPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IWikiService wikiService;

    private readonly ISpeciesPivotService speciesPivotService;
    #endregion

    #region [CTor]
    public WikiPageViewModel(
        IWikiService wikiService,
        ISpeciesPivotService speciesPivotService,
        IAppNavigator appNavigator) : base(appNavigator)
	{
        this.wikiService = wikiService;
        this.speciesPivotService = speciesPivotService;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    SpeciesPivotModel selectedItem;

    [ObservableProperty]
    ObservableCollection<SpeciesPivotModel> items;

    [ObservableProperty]
    ObservableCollection<BreedCardModel> fakeBreedCards;
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
    }
    #endregion

    #region [RelayCommands]

    [RelayCommand]
    private void Refresh() => LoadDataAsync()
                                .ContinueWith(x => IsBusy = false)
                                .FireAndForget();
    #endregion

    #region [Methods]
    private async Task LoadDataAsync()
    {
        if (IsBusy) return;

        IsBusy = true;

        if (Items == null)
        {
            Items = new ObservableCollection<SpeciesPivotModel>();
        }

        Items.Clear();

        var items = await speciesPivotService.GetAllSpecies();

        var fakeBreed = await wikiService.GetAll();

        foreach (var item in items)
        {
            Items.Add(item);
        }

        foreach (var item in fakeBreed)
        {
            FakeBreedCards.Add(item);
        }

        IsBusy = false;
    }
    #endregion
}
