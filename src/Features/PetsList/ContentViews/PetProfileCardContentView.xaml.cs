using CommunityToolkit.Mvvm.Messaging;

namespace PetaverseMAUI;

public partial class PetProfileCardContentView : ContentView
{
    #region [ Delegates ]
    public delegate void PetCardTappedEventHandler(PetProfileCardModel petProfileCardModel);
    #endregion

    #region [ Event Handlers ]
    public event PetCardTappedEventHandler PetCardTapped;

    private void Detail_Clicked(object sender, EventArgs e)
        => PetCardTapped?.Invoke(ComponentData);
    #endregion

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