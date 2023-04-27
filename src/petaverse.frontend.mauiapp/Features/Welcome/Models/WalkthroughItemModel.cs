namespace petaverse.frontend.mauiapp;

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

