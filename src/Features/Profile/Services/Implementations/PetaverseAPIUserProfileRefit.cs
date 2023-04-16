using CommunityToolkit.Diagnostics;
using Refit;

namespace PetaverseMAUI;

public class PetaverseAPIUserProfileRefit : IProfileService
{
    #region [ Fields ]
    private readonly IAppNavigator _appNavigator;
    private readonly ISecureStorageService _secureStorageService;
    private readonly IPetaverseAPIUserProfileRefit _petaverseAPIUserProfileRefit;
    #endregion

    #region [ CTor ]
    public PetaverseAPIUserProfileRefit(IAppNavigator appNavigator,
                                        ISecureStorageService secureStorageService,
                                        IPetaverseAPIUserProfileRefit petaverseAPIUserProfileRefit)
    {
        _appNavigator = appNavigator;
        _secureStorageService = secureStorageService;
        _petaverseAPIUserProfileRefit = petaverseAPIUserProfileRefit;
    }
    #endregion

    #region [ Services ]

    public async Task<UserProfile> GetCurrentUser()
    {
        var accessToken = await _secureStorageService.ReadValueAsync("accesstoken");
        Guard.IsNotNullOrEmpty(accessToken);

        var refitUserInfoDTO = await _petaverseAPIUserProfileRefit.GetCurrentUser(accessToken);
        Guard.IsNotNull(refitUserInfoDTO);

        return new UserProfile()
        {
            UserName = refitUserInfoDTO.userName,
            Email = refitUserInfoDTO.email,
            PhoneNumber = refitUserInfoDTO.phoneNumber,
            AvatarUrl = refitUserInfoDTO.petaverseProfileImageUrl
        };
    }

    public Task<UserProfile> GetUserByguid(string guid)
    {
        throw new NotImplementedException();
    }

    public async Task<UserProfile> GetUserInfo()
    {
        var accessToken = await _secureStorageService.ReadValueAsync("accesstoken");
        Guard.IsNotNullOrEmpty(accessToken);

        var refitUserInfoDTO = await _petaverseAPIUserProfileRefit.GetCurrentUser(accessToken);
        Guard.IsNotNull(refitUserInfoDTO);

        return new UserProfile()
        {
            UserName = refitUserInfoDTO.userName,
            Email = refitUserInfoDTO.email,
            PhoneNumber = refitUserInfoDTO.phoneNumber,
            AvatarUrl = refitUserInfoDTO.petaverseProfileImageUrl
        };
    }

    public Task SaveUserToLocalAsync(UserProfile user)
    {
        return Task.Run(() => null);
    }

    public async Task UploadCurrentUserAvatar(FileResult file)
    {
        Guard.IsNotNull(file);

        var accessToken = await _secureStorageService.ReadValueAsync("accesstoken");

        Guard.IsNotNullOrEmpty(accessToken);

        using var fileStream = File.OpenRead(file.FullPath);

        var stream = new StreamPart(fileStream, file.FileName, file.ContentType);

        try
        {
            var result = await _petaverseAPIUserProfileRefit.UpdateAvatar(accessToken, stream);
            if (result.IsSuccessStatusCode)
            {
                await _appNavigator.ShowSnackbarAsync("Save success !!!");
            }
            else
            {
                await _appNavigator.ShowSnackbarAsync($"Something wrong !!! {result.StatusCode}");
            }
        }
        catch (ApiException ex)
        {

            throw;
        }
    }
    #endregion
}
