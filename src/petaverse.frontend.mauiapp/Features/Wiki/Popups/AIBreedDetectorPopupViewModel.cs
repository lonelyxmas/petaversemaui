namespace petaverse.frontend.mauiapp;

public partial class AIBreedDetectorPopupViewModel : BaseViewModel
{
    #region [ CTor ]
    public AIBreedDetectorPopupViewModel(IAppNavigator appNavigator) : base(appNavigator) { }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    ImageSource capturedBreed;

    [ObservableProperty]
    BreedCardModel predictedBreed;
    #endregion
}
