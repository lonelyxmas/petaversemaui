namespace petaverse.frontend.mauiapp;

public partial class BreedCardContentView : ContentView
{

    #region [CTor]

    public BreedCardContentView()
    {
        InitializeComponent();
    }

    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(BreedCardModel),
        typeof(BreedCardContentView),
        null
    );
    #endregion

    #region [Properties]
    public BreedCardModel ComponentData
    {
        get => (BreedCardModel)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion

    #region [Event Handlers]

    #endregion
}