using Refit;
using System.Net;

namespace petaverse.frontend.mauiapp;

public interface IPetaverseAPIAuthenticationRefit
{
    [Multipart]
    [Post("/Authentication/Register")]
    Task<ApiResponse<HttpStatusCode>> Register([AliasAs("UserName")] string username,
                                               [AliasAs("FirstName")] string firstname,
                                               [AliasAs("LastName")] string lastname,
                                               [AliasAs("PhoneNumber")] string phonenumber,
                                               [AliasAs("Email")] string email,
                                               [AliasAs("Password")] string password,
                                               [AliasAs("AvatarFile")] StreamPart avatarfile);

    [Post("/Authentication/Login")]
    Task<AuthenticationResponseDTO> Login(UserNameLoginDTO dto);

    [Post("/Authentication/LoginWithPhoneNumber")]
    Task<AuthenticationResponseDTO> LoginWithPhoneNumber(PhoneNumberLoginDTO dto);
}
