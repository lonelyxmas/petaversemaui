using CommunityToolkit.Diagnostics;

namespace PetaverseMAUI;
public class MockAuthenticationService : IAuthenticationService
{
    public Task Authenticate(string username, string password)
    {
        Guard.IsNotEmpty(username);
        Guard.IsNotEmpty(password);

        return Task.CompletedTask;
    }

    public Task AuthenticateWithPhoneNumber(string phonenumber, string password)
    {
        Guard.IsNotEmpty(phonenumber);
        Guard.IsNotEmpty(password);

        return Task.CompletedTask;
    }

    public Task SignUp(string phonenumber, string username, string email, string password, string firstname, string lastname, FileResult profilepicurl)
    {
        Guard.IsNotEmpty(username);
        Guard.IsNotEmpty(phonenumber);
        Guard.IsNotEmpty(email);
        Guard.IsNotEmpty(password);
        Guard.IsNotEmpty(lastname);

        return Task.CompletedTask;
    }
}
