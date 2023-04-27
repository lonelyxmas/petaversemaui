namespace petaverse.frontend.mauiapp;

public partial class PetaverseMediaThumbnail : BaseModel
{
    [ObservableProperty]
    string? mediaName = string.Empty;

    [ObservableProperty]
    string? thumbnailUrl = string.Empty;

    [ObservableProperty]
    string? mediaUrl = string.Empty;

    [ObservableProperty]
    MediaType? type = MediaType.Photo;

    [ObservableProperty]
    DateTime? timeUploaded;
}

public enum MediaType
{
    Video, Photo, Avatar
}
