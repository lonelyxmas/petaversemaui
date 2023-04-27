namespace petaverse.frontend.mauiapp;

public partial class PetDetailProfilePageViewModel : NavigationAwareBaseViewModel
{
    #region [ Ctor ]
    public PetDetailProfilePageViewModel(
        IPetProfileService petProfileService,
        IAppNavigator appNavigator) : base(appNavigator)
    {
        this.petProfileService = petProfileService;
        this.appNavigator = appNavigator;
    }
    #endregion

    #region [ Fields ]
    [ObservableProperty]
    int span = 1;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    string currentDeviceState;

    [ObservableProperty]
    ObservableCollection<PetaverseMediaThumbnail> fakeThumbnails;
    #endregion

    #region [ Services ]
    private readonly IPetProfileService petProfileService;
    private readonly IAppNavigator appNavigator;
    #endregion

    #region [ RelayCommands ]

    [RelayCommand]
    Task RefreshAsync()
        => LoadDataAsync();
    #endregion

    #region [ Methods ]
    private async Task LoadDataAsync()
    {
        if (IsBusy) return;
        IsBusy = true;

        var items = await this.petProfileService.FakeThumbnails();

        IsBusy = false;

        if (FakeThumbnails == null)
        {
            FakeThumbnails = new ObservableCollection<PetaverseMediaThumbnail>(items);
            return;
        }

        foreach (var item in items)
        {
            FakeThumbnails.Add(item);
        }
    }
    #endregion

    #region [ Override ]
    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        await LoadDataAsync();
    }

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        var pet = query.GetData<CreatePetForm>();
    }
    #endregion
}
