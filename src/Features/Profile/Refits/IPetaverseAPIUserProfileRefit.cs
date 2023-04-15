using Refit;
using System.Net;

namespace PetaverseMAUI;

public interface IPetaverseAPIUserProfileRefit
{
    [Get("/User/GetCurrentUser")]
    Task<RefitUserInfoResponseModel> GetCurrentUser([Authorize("Bearer")] string token);

    [Multipart]
    [Put("/User/UpdateAvatar")]
    Task<ApiResponse<HttpStatusCode>> UpdateAvatar([Authorize("Bearer")] string token,
                                                   [AliasAs("avatar")] StreamPart avatar);
}
