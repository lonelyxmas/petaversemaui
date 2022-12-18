namespace PetaverseMAUI;

public partial class PetProfileCardContentView : ContentView
{
    #region [ CTor ]

    public PetProfileCardContentView()
    {
        InitializeComponent();
    }

    #endregion

    #region [ Properties ]

    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(PetProfileCardModel),
        typeof(PetProfileCardContentView),
        default(PetProfileCardModel)
        );
    public PetProfileCardModel ComponentData
    {
        get => (PetProfileCardModel)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    #endregion
}