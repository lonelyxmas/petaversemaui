using AutoMapper;
using CommunityToolkit.Mvvm.Messaging;

namespace petaverse.frontend.mauiapp;

public partial class PetsListPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Services ]
    private readonly IMapper mapper;
    private readonly IPetsListService petsListService;
    #endregion

    #region [ CTor ]
    public PetsListPageViewModel(
        IPetsListService petsListService,
        IAppNavigator appNavigator,
        IMapper mapper
        ) : base(appNavigator)
    {
        this.mapper = mapper;
        this.petsListService = petsListService;
    }
    #endregion

    #region [ Properties ]

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

        LoadDataAsync().FireAndForget();
        SubcribeForNewPetCreation();
    }
    #endregion

    #region [ RelayCommands ]
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
    private void TestCommand()
    {

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
    #endregion

    #region [ Subcribe ]
    void SubcribeForNewPetCreation()
    {
        WeakReferenceMessenger.Default.Register<CreatePetMessageModel>(this, (_, message) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var pet = message;
                var speciesGroupName = pet.speciesName;
                var species = Items.FirstOrDefault(species => species.SpeciesName.Equals(speciesGroupName));
                if (species is not null)
                    species.Add(mapper.Map<PetProfileCardModel>(pet));
            });
        });
    }
    #endregion
}
