﻿namespace petaverse.frontend.mauiapp;

public partial class WalkthroughPageViewModel : NavigationAwareBaseViewModel
{

    #region [Fields]

    private readonly IWelcomeService landingService;

    #endregion

    #region [CTor]

    public WalkthroughPageViewModel(
        IWelcomeService landingService,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.landingService = landingService;
    }

    #endregion

    #region [Properties]

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AllowsToContinue))]
    [NotifyPropertyChangedFor(nameof(AllowsToStart))]
    [NotifyPropertyChangedFor(nameof(AllowsToSkip))]
    ObservableCollection<WalkthroughItemModel> items;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AllowsToGoback))]
    [NotifyPropertyChangedFor(nameof(AllowsToContinue))]
    [NotifyPropertyChangedFor(nameof(AllowsToStart))]
    [NotifyPropertyChangedFor(nameof(AllowsToSkip))]
    int itemPosition;

    [ObservableProperty]
    string deviceState;

    public bool AllowsToGoback => itemPosition > 0;
    public bool AllowsToContinue => itemPosition < items?.Count - 1;
    public bool AllowsToStart => itemPosition == items?.Count - 1;
    public bool AllowsToSkip => AllowsToContinue;

    #endregion

    #region [Overrides]

    protected async override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        var items = await landingService.GetWalkthroughItemsAsync();

        Items = new ObservableCollection<WalkthroughItemModel>(items);
    }

    #endregion

    #region [RelayCommands]

    [RelayCommand]
    void Move(bool goback) => ItemPosition += goback ? -1 : 1;

    [RelayCommand]
    Task StartAsync() => SignInAsync();

    [RelayCommand]
    Task SkipAsync() => SignInAsync();

    Task SignInAsync() => AppNavigator.NavigateAsync(AppRoutes.SignIn);

    #endregion
}

