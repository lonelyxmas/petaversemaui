namespace PetaverseMAUI;

public class FakeWikiService : IWikiService
{
    public Task<List<BreedCardModel>> GetAll()
    {
        return Task.Run(() =>
        {
            var faker = new Faker<BreedCardModel>();
            faker.RuleFor(x => x.BreedName, setter => "Tabby");
            faker.RuleFor(x => x.BreedDetail, setter => setter.Lorem.Text());


            return faker.Generate(10).ToList();
        });
    }
}
