namespace petaverse.frontend.mauiapp;

public partial class AIBreedDetectorPopup
{
    #region [ CTor ]
    public AIBreedDetectorPopup(AIBreedDetectorPopup vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}