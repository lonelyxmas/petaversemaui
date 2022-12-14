namespace PetaverseMAUI;

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
    DateTime? timeUpload = DateTime.Now;


    //public string? MediaName = string.Empty;


    //public string? ThumbnailUrl = string.Empty;


    //public string? MediaUrl = string.Empty;


    //public MediaType? Type = MediaType.Photo;


    //public DateTime? TimeUpload = DateTime.Now;
}

public enum MediaType
{
    Video, Photo, Avatar
}
