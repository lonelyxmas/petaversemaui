namespace PetaverseMAUI;

public class FakePetListService : IPetsListService
{
    public Task<List<PetProfileCardModel>> GetAll()
    {
        return Task.Run(() =>
        {
            var faker = new Faker<PetProfileCardModel>();
            faker.RuleFor(x => x.Name, setter => setter.Person.FirstName);
            faker.RuleFor(x => x.MediaCount, setter => setter.Random.Number(1000));
            faker.RuleFor(x => x.ProfileUrl, setter => setter.Image.LoremFlickrUrl(120, 120, "cat"));
            return faker.Generate(10).ToList();
        });
    }
}
