namespace petaverse.frontend.mauiapp;

public partial class PetaverseThumbnailContentView : ContentView
{
    #region [ Ctor ]

    public PetaverseThumbnailContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
            nameof(ComponentData),
            typeof(PetaverseMediaThumbnail),
            typeof(PetaverseThumbnailContentView),
            null
        );
    #endregion

    #region [ Properties ]
    public PetaverseMediaThumbnail ComponentData
    {
        get => (PetaverseMediaThumbnail)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion
}