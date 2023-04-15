using CommunityToolkit.Diagnostics;
using Newtonsoft.Json;
using Refit;

namespace PetaverseMAUI;

public class PetaverseAPIAuthenticationRefit : IAuthenticationService
{

    #region [ Fields ]
    private readonly IPetaverseAPIAuthenticationRefit _petaverseAPIAuthenticationRefit;
    private readonly ISecureStorageService _secureStorageService;
    private readonly IProfileService _profileService;
    private readonly IAppNavigator _appNavigator;
    #endregion

    #region [ CTor ]
    public PetaverseAPIAuthenticationRefit(IPetaverseAPIAuthenticationRefit petaverseAPIAuthenticationRefit,
                                      ISecureStorageService secureStorageService,
                                      IProfileService profileService,
                                      IAppNavigator appNavigator)
    {
        _petaverseAPIAuthenticationRefit = petaverseAPIAuthenticationRefit;
        _secureStorageService = secureStorageService;
        _profileService = profileService;
        _appNavigator = appNavigator;
    }
    #endregion

    #region [ Services ]

    public async Task Authenticate(string username, string password)
    {
        Guard.IsNotNullOrEmpty(username);
        Guard.IsNotNullOrEmpty(password);

        try
        {
            var authenticationResponseDTO = await _petaverseAPIAuthenticationRefit.Login(new UserNameLoginDTO(username, password));

            Guard.IsNotNull(authenticationResponseDTO);

            await SaveToSecureStorageAsync(authenticationResponseDTO);
        }
        catch (ApiException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task AuthenticateWithPhoneNumber(string phonenumber, string password)
    {
        Guard.IsNotNullOrEmpty(phonenumber);
        Guard.IsNotNullOrEmpty(password);

        try
        {
            var authenticationResponseDTO = await _petaverseAPIAuthenticationRefit.LoginWithPhoneNumber(new PhoneNumberLoginDTO(phonenumber, password));

            Guard.IsNotNull(authenticationResponseDTO);

            await SaveToSecureStorageAsync(authenticationResponseDTO);
        }
        catch (ApiException ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task SignUp(string phonenumber, string username, string email, string password, string firstname, string lastname, FileResult profilepicurl)
    {
        Guard.IsNotNullOrEmpty(phonenumber);
        Guard.IsNotNullOrEmpty(username);
        Guard.IsNotNullOrEmpty(email);
        Guard.IsNotNullOrEmpty(password);
        Guard.IsNotNullOrEmpty(firstname);
        //Guard.IsNotNull(profilePicUrl);

        StreamPart stream = null;

        if (profilepicurl is not null)
        {
            using var fileStream = File.OpenRead(profilepicurl.FullPath);

            stream = new StreamPart(fileStream, profilepicurl.FileName, profilepicurl.ContentType);
        }

        try
        {
            var response = await _petaverseAPIAuthenticationRefit.Register(username,
                                                                           firstname,
                                                                           lastname,
                                                                           phonenumber,
                                                                           email,
                                                                           password,
                                                                           stream ?? null);
            if (!response.IsSuccessStatusCode)
            {
                var errorContentJson = JsonConvert.DeserializeObject<RefitErrorMessageModel>(response.Error.Content);
                throw new Exception(errorContentJson.title);
            }
        }
        catch (ApiException ex)
        {
            throw new Exception(ex.Message);
        }
    }


    #endregion

    #region [Private methods]
    async Task SaveToSecureStorageAsync(AuthenticationResponseDTO dto)
    {
        await _secureStorageService.RemoveAllValueAsync();
        await _secureStorageService.WriteValueAsync("accesstoken", dto.accessToken);
        await _secureStorageService.WriteValueAsync("requestat", dto.requestAt.ToString());
        await _secureStorageService.WriteValueAsync("expirein", dto.expireIn.ToString());
        await _secureStorageService.WriteValueAsync("guid", dto.userGuid);
    }
    #endregion
}
