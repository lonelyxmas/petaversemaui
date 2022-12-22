namespace PetaverseMAUI;

public partial class WikiPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly ISpeciesPivotService speciesPivotService;
    #endregion

    #region [CTor]
    public WikiPageViewModel(
        ISpeciesPivotService speciesPivotService,
        IAppNavigator appNavigator) : base(appNavigator)
	{
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

        foreach (var item in items)
        {
            Items.Add(item);
        }

        IsBusy = false;
    }
    #endregion
}
