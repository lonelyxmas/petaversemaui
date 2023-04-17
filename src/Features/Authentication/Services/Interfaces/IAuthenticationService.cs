namespace PetaverseMAUI;

public interface IAuthenticationService
{
    #region [ Services ]
    Task Authenticate(string username, string password);
    Task AuthenticateWithPhoneNumber(string phonenumber, string password);
    Task SignUp(string phonenumber, string username, string email, string password, string firstname, string lastname, FileResult? profilepicurl);
    #endregion
}
