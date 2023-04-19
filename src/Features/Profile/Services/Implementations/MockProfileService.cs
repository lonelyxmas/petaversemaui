using CommunityToolkit.Diagnostics;

namespace PetaverseMAUI;

public class MockProfileService : IProfileService
{
    public Task<UserProfile> GetCurrentUser()
        => Task.Run(() =>
        {
            var userProfile = new Faker<UserProfile>();
            userProfile.RuleFor(up => up.Guid, setter => Guid.NewGuid().ToString());
            userProfile.RuleFor(up => up.AvatarUrl, setter => setter.Person.Avatar);
            userProfile.RuleFor(up => up.UserName, setter => setter.Person.UserName);
            userProfile.RuleFor(up => up.Email, setter => setter.Person.Email);
            userProfile.RuleFor(up => up.PhoneNumber, setter => setter.Person.Phone);
            userProfile.RuleFor(up => up.Bio, setter => setter.Lorem.Paragraph(3));
            userProfile.RuleFor(up => up.Gender, setter => setter.Person.Gender == Bogus.DataSets.Name.Gender.Male
                                                                             ? true
                                                                             : false);

            return userProfile.Generate();
        });

    public Task<UserProfile> GetUserByguid(string guid)
        => Task.Run(() =>
        {
            var userProfile = new Faker<UserProfile>();
            userProfile.RuleFor(up => up.Guid, setter => Guid.NewGuid().ToString());
            userProfile.RuleFor(up => up.AvatarUrl, setter => setter.Person.Avatar);
            userProfile.RuleFor(up => up.UserName, setter => setter.Person.UserName);
            userProfile.RuleFor(up => up.Email, setter => setter.Person.Email);
            userProfile.RuleFor(up => up.PhoneNumber, setter => setter.Person.Phone);
            userProfile.RuleFor(up => up.Bio, setter => setter.Lorem.Paragraph(3));
            userProfile.RuleFor(up => up.Gender, setter => setter.Person.Gender == Bogus.DataSets.Name.Gender.Male
                                                                             ? true
                                                                             : false);

            return userProfile.Generate();
        });

    public Task<UserProfile> GetUserInfo()
        => Task.Run(() =>
        {
            var userProfile = new Faker<UserProfile>();
            userProfile.RuleFor(up => up.Guid, setter => Guid.NewGuid().ToString());
            userProfile.RuleFor(up => up.AvatarUrl, setter => setter.Person.Avatar);
            userProfile.RuleFor(up => up.UserName, setter => setter.Person.UserName);
            userProfile.RuleFor(up => up.Email, setter => setter.Person.Email);
            userProfile.RuleFor(up => up.PhoneNumber, setter => setter.Person.Phone);
            userProfile.RuleFor(up => up.CountryName, setter => setter.Address.Country());
            userProfile.RuleFor(up => up.City, setter => setter.Address.City());
            userProfile.RuleFor(up => up.Bio, setter => setter.Lorem.Paragraph(3));
            userProfile.RuleFor(up => up.Gender, setter => setter.Person.Gender == Bogus.DataSets.Name.Gender.Male
                                                                             ? true
                                                                             : false);

            return userProfile.Generate();
        });

    public Task SaveUserToLocalAsync(UserProfile user)
    {
        Guard.IsNotNull(user);

        return Task.CompletedTask;
    }

    public Task UploadCurrentUserAvatar(FileResult file)
    {
        Guard.IsNotNull(file);

        return Task.CompletedTask;
    }
}
