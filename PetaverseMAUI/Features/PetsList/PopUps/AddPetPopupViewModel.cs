namespace PetaverseMAUI;

public partial class AddPetPopupViewModel : BaseViewModel
{
    #region [Properties]

    [ObservableProperty]
    List<SpeciesPivotModel> speciesPivots;

    [ObservableProperty]
    SpeciesPivotModel selectedSpecies;

    #endregion

    #region [CTor]
    public AddPetPopupViewModel(ISpeciesPivotService speciesPivotService, 
                                IAppNavigator appNavigator) : base(appNavigator)
	{
        this.speciesPivotService = speciesPivotService;
	}
    #endregion

    #region [Services]

    private readonly ISpeciesPivotService speciesPivotService;
    #endregion

    #region [RelayCommand]

    [RelayCommand]
    private Task Done(object obj) => AppNavigator.NavigateAsync(AppRoutes.PetsProfile);

    [RelayCommand]
    private Task Retry(object obj) => AppNavigator.GoBackAsync(true);
    #endregion

    #region [Methods]
    private async Task LoadDataAsync()
    {
        var items = await this.speciesPivotService.GetAllSpecies();

        if(SpeciesPivots == null)
        {
            SpeciesPivots = new List<SpeciesPivotModel>();
            //return;
        }

        foreach (var item in items)
        {
            SpeciesPivots.Add(item);
        }
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
