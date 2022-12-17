namespace PetaverseMAUI;

public partial class PetProfileCardModel : BaseModel
{
    [ObservableProperty]
    string name = string.Empty;

    [ObservableProperty]
    string profileUrl = string.Empty;

    [ObservableProperty]
    int mediaCount;
}
