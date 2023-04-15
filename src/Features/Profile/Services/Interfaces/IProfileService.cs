namespace PetaverseMAUI;

public interface IProfileService
{
    Task<UserProfile> GetCurrentUser();

    Task<UserProfile> GetUserByguid(string guid);

    Task<UserProfile> GetUserInfo();

    Task SaveUserToLocalAsync(UserProfile user);

    Task UploadCurrentUserAvatar(FileResult file);
}
