namespace PetaverseMAUI;

public partial class AddPetPopupViewModel : BaseViewModel
{
    #region [Services]
    private readonly IWikiCreateService wikiCreateBreedService;
    #endregion

    #region [CTor]
    public AddPetPopupViewModel(IAppNavigator appNavigator,
                                IWikiCreateService wikiCreateService) : base(appNavigator)
    {
        PetForm = new();
        wikiCreateBreedService = wikiCreateService;
    }
    #endregion

    #region [Properties]

    [ObservableProperty]
    List<SpeciesPivotModel> speciesPivots;

    [ObservableProperty]
    SpeciesType selectedSpecies;

    [ObservableProperty]
    CreatePetFormModel petForm;

    [ObservableProperty]
    List<Breed> breeds;

    [ObservableProperty]
    List<string> breedNames;

    [ObservableProperty]
    Breed selectedBreeds;

    #endregion

    #region [Overrides]
    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        await LoadDataAsync(SelectedSpecies);
    }
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
    private async Task LoadDataAsync(SpeciesType speciesType)
    {
        BreedNames = new();
        Breeds = await wikiCreateBreedService.GetBySpeciesTypeAsync(speciesType);
        foreach (var breed in Breeds)
        {
            BreedNames.Add(breed.Name);
        }
        //BreedNames.Add( Breeds.FirstOrDefault().Name);
    }
    #endregion
}
