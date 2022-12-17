namespace PetaverseMAUI;

public partial class PetProfileCard : ContentView
{
    #region [ CTor ]

    public PetProfileCard()
    {
        InitializeComponent();
    }

    #endregion

    #region [ Properties ]

    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(PetProfileCardModel),
        typeof(PetProfileCard),
        default(PetProfileCardModel)
        );
    public PetProfileCardModel ComponentData
    {
        get => (PetProfileCardModel)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    #endregion
}