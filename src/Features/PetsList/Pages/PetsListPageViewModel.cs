using CommunityToolkit.Mvvm.Messaging;

namespace PetaverseMAUI;

public partial class PetsListPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IPetsListService petsListService;
    private readonly IWikiFakeBreedService wikiFakeBreedService;
    #endregion

    #region [CTor]
    public PetsListPageViewModel(
        IWikiFakeBreedService wikiFakeBreedService,
        IPetsListService petsListService,
        IAppNavigator appNavigator
        ):base(appNavigator)
    {
        this.petsListService = petsListService;
        this.wikiFakeBreedService = wikiFakeBreedService;
    }
    #endregion

    #region [Fields]

    [ObservableProperty]
    int span = 1;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    string currentDeviceState;

    [ObservableProperty]
    ObservableCollection<PetProfileCardsGroupModel> items;


    [ObservableProperty]
    PetProfileCardsGroupModel selectedItem;
    #endregion

    #region [Overrides]
    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        SubcribeToCreateMessage();
        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [RelayCommands]
    [RelayCommand]
    private void Refresh() => LoadDataAsync()
                                .ContinueWith(x => IsBusy = false)
                                .FireAndForget();

    [RelayCommand]
    private void NavigateToProfileDetail(PetProfileCardModel petProfileCardModel)
    {
        AppNavigator.NavigateAsync(AppRoutes.PetDetailProfile, args: petProfileCardModel);
    }


    [RelayCommand]
    private Task AddPetAsync() => AppNavigator.NavigateAsync(AppRoutes.AddPetPopup);
    #endregion

    #region [Methods]
    private async Task LoadDataAsync()
    {
        IsBusy = true;

        var items = await this.petsListService.GetAll();

        if (Items == null)
        {
            Items = new ObservableCollection<PetProfileCardsGroupModel>();
            return;
        }

        foreach (var item in items)
        {
            if (!Items.SelectMany(x => x).Any(y => y.SpeciesType == item.SpeciesType))
            {
                Items.Add(new PetProfileCardsGroupModel(item.SpeciesType.ToString(),
                                                        items.Where(x => x.SpeciesType == item.SpeciesType).ToList()));
            };
        }

        IsBusy = false;
    }

    private void SubcribeToCreateMessage()
    {
        WeakReferenceMessenger.Default.Register<PetListCreateMessage>(this, (register, message) =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {

                var petProfile = message.Value;
                var newCardModel = new PetProfileCardModel
                {
                    Name = petProfile.PetName,
                    ProfileUrl = string.Empty,
                    MediaCount = new int(),
                    Breed = await wikiFakeBreedService.GetByIdAsync(petProfile.BreedId),
                    SpeciesType = Enum.Parse<SpeciesType>(petProfile.SpeciesId.ToString())
                };
                Items.ToList().ForEach(x => 
                {
                    x.Where(x => x.SpeciesType.Equals(newCardModel.SpeciesType));
                    //x.SpeciesName.Equals(newCardModel.SpeciesType.ToString());
                });

                foreach (var item in Items.Where(x => x.SpeciesName.Equals(newCardModel.SpeciesType.ToString())))
                {
                    item.Add(newCardModel);
                }

                //Items.Add(new PetProfileCardModel()
                //{


                //});
            });
        });
    }
    #endregion
}
