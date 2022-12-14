namespace PetaverseMAUI;

public partial class PetProfilePageViewModel : NavigationAwareBaseViewModel
{
    #region [ Ctor ]
    public PetProfilePageViewModel(
        IPetProfileService petProfileService,
        IAppNavigator appNavigator) : base(appNavigator)
    {
        this.petProfileService = petProfileService;
        this.appNavigator = appNavigator;
    }
    #endregion

    #region [ Fields ]
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<PetaverseMediaThumbnail> fakeThumbnails;
    #endregion

    #region [ Services ]
    private readonly IPetProfileService petProfileService;
    private readonly IAppNavigator appNavigator;
    #endregion

    #region [ RelayCommands ]

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
    #endregion
}
