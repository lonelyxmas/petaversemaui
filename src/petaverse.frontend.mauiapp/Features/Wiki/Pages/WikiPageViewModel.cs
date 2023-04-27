namespace petaverse.frontend.mauiapp;

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
    bool isBusy;

    [ObservableProperty]
    bool isSpeciesFrameInfoVisible;

    [ObservableProperty]
    List<string> sizeEnum;

    [ObservableProperty]
    string? selectedSize;

    [ObservableProperty]
    List<string> coatEnum;

    [ObservableProperty]
    string? selectedCoat;

    [ObservableProperty]
    List<string> sheddingLevelEnum;

    [ObservableProperty]
    string? selectedSheddingLevel;

    [ObservableProperty]
    List<string> energyEnum;

    [ObservableProperty]
    string? selectedEnergy;

    [ObservableProperty]
    SpeciesPivotModel? selectedSpecies;

    [ObservableProperty]
    List<SpeciesPivotModel> species;

    [ObservableProperty]
    int span = 1;

    [ObservableProperty]
    ImageSource aIPredictedBreed;

    #endregion

    #region [Overrides]
    protected async override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        LoadEnums();
        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [RelayCommands]
    [RelayCommand]
    private void Refresh() => LoadDataAsync().ContinueWith(x => IsBusy = false)
                                             .FireAndForget();

    [RelayCommand]
    private void NavigateToBreedDetail(BreedCardModel breedCardModel)
                        => AppNavigator.NavigateAsync(AppRoutes.Wiki, args: breedCardModel);

    [RelayCommand]
    private void ClearFilter()
    {
        SelectedSpecies = Species.FirstOrDefault(x => x.SpeciesId == SelectedSpecies.SpeciesId).Clone();
        SelectedCoat = null;
        SelectedEnergy = null;
        SelectedSize = null;
        SelectedSheddingLevel = null;
    }

    //This cannot turn into a Relay because of the stupid toolkit popup require to init in code behind
    public async Task<Tuple<ImageSource, BreedCardModel>> OpenCameraAsync()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo is null)
                return null;

            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using Stream sourceStream = await photo.OpenReadAsync();
            using FileStream localFileStream = File.OpenWrite(localFilePath);
            await sourceStream.CopyToAsync(localFileStream);

            return new Tuple<ImageSource, BreedCardModel>(ImageSource.FromStream(() => new MemoryStream(File.ReadAllBytes(localFilePath))),
                                                          SelectedSpecies.BreedCards.FirstOrDefault());


        }
        return null;
    }
    #endregion

    #region [Methods]
    private async Task LoadDataAsync()
    {
        if (IsBusy) return;

        IsBusy = true;

        if (Species == null)
        {
            Species = new();
        }

        Species.Clear();

        var result = await wikiService.GetAllSpecies();

        Species = result.ToList();

        SelectedSpecies = Species.FirstOrDefault();

        IsBusy = false;
    }

    void LoadEnums()
    {
        SizeEnum = Enum.GetNames(typeof(WikiPageSizeEnum)).ToList();
        CoatEnum = Enum.GetNames(typeof(WikiPageCoatEnum)).ToList();
        SheddingLevelEnum = Enum.GetNames(typeof(WikiPageSheddingLevelEnum)).ToList();
        EnergyEnum = Enum.GetNames(typeof(WikiPageEnergyEnum)).ToList();
    }

    partial void OnSelectedEnergyChanging(string value)
    {
        SelectedSpecies = Species.FirstOrDefault(x => x.SpeciesId == SelectedSpecies.SpeciesId).Clone();


        SelectedSpecies.BreedCards = SelectedSpecies.BreedCards
                                                    .WhereIf(!string.IsNullOrWhiteSpace(value), card => card.Energy == Enum.Parse<WikiPageEnergyEnum>(value))
                                                    .WhereIf(SelectedSheddingLevel is not null, card => card.SheddingLevel == Enum.Parse<WikiPageSheddingLevelEnum>(SelectedSheddingLevel))
                                                    .WhereIf(SelectedCoat is not null, card => card.Coat == Enum.Parse<WikiPageCoatEnum>(SelectedCoat))
                                                    .ToList();
    }

    partial void OnSelectedSheddingLevelChanging(string value)
    {
        SelectedSpecies = Species.FirstOrDefault(x => x.SpeciesId == SelectedSpecies.SpeciesId).Clone();
        SelectedSpecies.BreedCards = SelectedSpecies.BreedCards
                                                    .WhereIf(!string.IsNullOrWhiteSpace(value), card => card.SheddingLevel == Enum.Parse<WikiPageSheddingLevelEnum>(value))
                                                    .WhereIf(SelectedEnergy is not null, card => card.Energy == Enum.Parse<WikiPageEnergyEnum>(SelectedEnergy))
                                                    .WhereIf(SelectedCoat is not null, card => card.Coat == Enum.Parse<WikiPageCoatEnum>(SelectedCoat))
                                                    .ToList();
    }

    partial void OnSelectedCoatChanging(string value)
    {
        SelectedSpecies = Species.FirstOrDefault(x => x.SpeciesId == SelectedSpecies.SpeciesId).Clone();
        SelectedSpecies.BreedCards = SelectedSpecies.BreedCards
                                                    .WhereIf(!string.IsNullOrWhiteSpace(value), card => card.Coat == Enum.Parse<WikiPageCoatEnum>(value))
                                                    .WhereIf(SelectedSheddingLevel is not null, card => card.SheddingLevel == Enum.Parse<WikiPageSheddingLevelEnum>(SelectedSheddingLevel))
                                                    .WhereIf(SelectedEnergy is not null, card => card.Energy == Enum.Parse<WikiPageEnergyEnum>(SelectedEnergy))
                                                    .WhereIf(SelectedSize is not null, card => card.Size == Enum.Parse<WikiPageSizeEnum>(SelectedSize))
                                                    .ToList();
    }

    partial void OnSelectedSizeChanging(string value)
    {
        SelectedSpecies = Species.FirstOrDefault(x => x.SpeciesId == SelectedSpecies.SpeciesId).Clone();
        SelectedSpecies.BreedCards = SelectedSpecies.BreedCards
                                                    .WhereIf(!string.IsNullOrWhiteSpace(value), card => card.Size == Enum.Parse<WikiPageSizeEnum>(value))
                                                    .WhereIf(SelectedSheddingLevel is not null, card => card.SheddingLevel == Enum.Parse<WikiPageSheddingLevelEnum>(SelectedSheddingLevel))
                                                    .WhereIf(SelectedEnergy is not null, card => card.Energy == Enum.Parse<WikiPageEnergyEnum>(SelectedEnergy))
                                                    .WhereIf(SelectedCoat is not null, card => card.Coat == Enum.Parse<WikiPageCoatEnum>(SelectedCoat))
                                                    .ToList();
    }
    #endregion
}
