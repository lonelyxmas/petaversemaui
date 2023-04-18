using CommunityToolkit.Mvvm.Messaging;

namespace PetaverseMAUI;

public partial class PetProfileCardContentView : ContentView
{
    IConnectivity connectivity;
    #region [ CTor ]

    public PetProfileCardContentView(IConnectivity connectivity)
    {
        InitializeComponent();
        this.connectivity = connectivity;
        //WeakReferenceMessenger.Default.Register<ItemsDetailMessage>();
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

    [RelayCommand]
    void CallBack(string s)
    {
    }

    #endregion
}