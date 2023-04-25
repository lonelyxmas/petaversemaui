using CommunityToolkit.Mvvm.Messaging;

namespace PetaverseMAUI;

public partial class AddPetPopupViewModel : BaseViewModel
{
    #region [Services]
    private readonly IWikiFakeBreedService wikiFakeBreedService;
    #endregion

    #region [CTor]
    public AddPetPopupViewModel(IAppNavigator appNavigator,
                                IWikiFakeBreedService wikiFakeBreedService) : base(appNavigator)
    {
        PetForm = new();
        this.wikiFakeBreedService = wikiFakeBreedService;
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
        PetForm.BreedId = int.Parse(SelectedBreeds.Id);
        PetForm.SpeciesId = (int)SelectedSpecies;
        WeakReferenceMessenger.Default.Send(new PetListCreateMessage(PetForm));
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
        Breeds = await wikiFakeBreedService.GetBySpeciesTypeAsync(speciesType);
        foreach (var breed in Breeds)
        {
            BreedNames.Add(breed.Name);
        }
    }
    #endregion
}