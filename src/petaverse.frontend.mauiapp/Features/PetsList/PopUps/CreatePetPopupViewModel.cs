using CommunityToolkit.Mvvm.Messaging;

namespace petaverse.frontend.mauiapp;

public partial class CreatePetPopupViewModel : BaseViewModel
{
    #region [Properties]
    [ObservableProperty]
    ImageSource avatar;

    [ObservableProperty]
    List<CreatePetPopupSpeciesModel> popupSpecies;

    [ObservableProperty]
    CreatePetPopupBreedModel selectedPopupBreed;

    [ObservableProperty]
    CreatePetPopupSpeciesModel selectedPopupSpecies;

    [ObservableProperty]
    List<Color> petSelectedColors;
    public CreatePetForm PetForm { get; init; }

    #endregion

    #region [CTor]
    public CreatePetPopupViewModel(IAppNavigator appNavigator,
                                   ICreatePetPopupService createPetPopupService)
                            : base(appNavigator)
    {
        PetForm = new();
        PetSelectedColors = new();

        _createPetPopupService = createPetPopupService;
    }
    #endregion

    #region [Overrides]
    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [Services]
    private readonly ICreatePetPopupService _createPetPopupService;
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

        //Mock data
        var sixDigitCode = "652389";

        //string.Join(", ", PetForm.SelectedColors)
        WeakReferenceMessenger.Default.Send(new CreatePetMessageModel(PetForm.PetName,
                                                                      "https://i.imgur.com/BhXNGWm.png",
                                                                      PetForm.Bio,
                                                                      PetSelectedColors.Any() ? string.Join(", ", PetSelectedColors.Select(color => color.ToHex())) : string.Empty,
                                                                      sixDigitCode,
                                                                      PetForm.Gender,
                                                                      1,
                                                                      PetForm.DateOfBirth,
                                                                      SelectedPopupBreed.BreedName,
                                                                      SelectedPopupBreed.BreedDescription,
                                                                      SelectedPopupBreed.Colors,
                                                                      SelectedPopupSpecies.SpeciesName,
                                                                      SelectedPopupSpecies.Description));

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
        if (PopupSpecies is null)
        {
            PopupSpecies = new();
            //return;
        }

        var result = await _createPetPopupService.GetSpecies();
        PopupSpecies = result.ToList();
    }
    #endregion

}
