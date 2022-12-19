namespace PetaverseMAUI;

public partial class WikiPageViewModel : NavigationAwareBaseViewModel
{
	#region [CTor]
	public WikiPageViewModel(
        IAppNavigator appNavigator) : base(appNavigator)
	{
		
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

        IsBusy = false;
    }
    #endregion
}
