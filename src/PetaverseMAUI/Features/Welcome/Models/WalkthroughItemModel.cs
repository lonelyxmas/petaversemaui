namespace PetaverseMAUI;

public partial class WalkthroughItemModel : BaseModel
{

    [ObservableProperty]
    string title;

    [ObservableProperty]
    string subtitle;

    [ObservableProperty]
    string image;

    [ObservableProperty]
    Thickness imageMargin;
}

