namespace PetaverseMAUI;

public partial class AddPetPopupViewModel : BaseViewModel
{
    #region [Properties]

    [ObservableProperty]
    List<SpeciesPivotModel> speciesPivots;

    [ObservableProperty]
    SpeciesPivotModel selectedSpecies;

    public CreatePetFormModel PetForm { get; init; }

    #endregion

    #region [CTor]
    public AddPetPopupViewModel(IAppNavigator appNavigator) : base(appNavigator)
	{
        PetForm = new();
	}
    #endregion

    #region [Services]

    #endregion

    #region [RelayCommand]

    [RelayCommand]
    async Task Create()
    {
        var isValid = PetForm.IsValid();
        if (!isValid)
        {
            await Task.CompletedTask;
        }

        AppNavigator.NavigateAsync(AppRoutes.PetsProfile, true, args: PetForm)
                    .FireAndForget();
    }

    [RelayCommand]
    Task Cancel() => AppNavigator.GoBackAsync();

    [RelayCommand]
    private Task Retry(object obj) => AppNavigator.GoBackAsync(true);
    #endregion

    #region [Methods]
    private async Task LoadDataAsync()
    {

        if(SpeciesPivots == null)
        {
            SpeciesPivots = new List<SpeciesPivotModel>();
            //return;
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
